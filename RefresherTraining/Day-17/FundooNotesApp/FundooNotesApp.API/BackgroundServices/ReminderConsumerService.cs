using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FundooNotesApp.ModelLayer.DTOs.Response;
using FundooNotesApp.Repository;
using FundooNotesApp.Business.Interface;

namespace FundooNotesApp.API.BackgroundServices
{
    // Runs continuously in the background - listens to the RabbitMQ queue,
    // marks the reminder as "sent" in the database, and emails the user
    public class ReminderConsumerService : BackgroundService
    {
        private const string QueueName = "reminder_queue";
        private readonly IServiceProvider _serviceProvider;

        public ReminderConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = await factory.CreateConnectionAsync(stoppingToken);
            using var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

            await channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                cancellationToken: stoppingToken
            );

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var reminderMessage = JsonSerializer.Deserialize<ReminderMessageDto>(json);

                // Wait until the actual reminder time arrives before processing
                var delay = reminderMessage.ReminderDateTime - DateTime.Now;
                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, stoppingToken);
                }

                // DbContext and other Scoped services need a fresh scope here
                // since this background service itself is a Singleton
                using var scope = _serviceProvider.CreateScope();
                var noteRepository = scope.ServiceProvider.GetRequiredService<INoteRepository>();
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                var note = await noteRepository.GetNoteByIdAsync(reminderMessage.NoteId);
                if (note != null && !note.IsReminderSent)
                {
                    note.IsReminderSent = true;
                    await noteRepository.UpdateNoteAsync(note);

                    // Look up the user's email and send the reminder
                    var user = await userRepository.GetUserByIdAsync(reminderMessage.UserId);
                    if (user != null)
                    {
                        var subject = $"Reminder: {reminderMessage.Title}";
                        var emailBody = $"This is your reminder for the note: \"{reminderMessage.Title}\"";

                        try
                        {
                            await emailService.SendEmailAsync(user.Email, subject, emailBody);
                            Console.WriteLine($"✅ Email sent successfully to {user.Email}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Failed to send email: {ex.Message}");
                        }
                    }
                }

                await channel.BasicAckAsync(ea.DeliveryTag, multiple: false, cancellationToken: stoppingToken);
            };

            await channel.BasicConsumeAsync(
                queue: QueueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken
            );

            // Keep this background service alive until the app shuts down
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}