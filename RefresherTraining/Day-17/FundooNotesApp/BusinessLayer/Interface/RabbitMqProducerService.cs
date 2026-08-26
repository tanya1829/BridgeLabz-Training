using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;
using FundooNotesApp.ModelLayer.DTOs.Response;
using FundooNotesApp.Business.Interface;

namespace FundooNotesApp.Business.Service
{
    // Publishes reminder messages to the RabbitMQ queue - doesn't send notifications itself,
    // just hands off the work so the API doesn't block waiting for it
    public class RabbitMqProducerService : IRabbitMqProducerService
    {
        private const string QueueName = "reminder_queue";

        public async Task PublishReminderAsync(ReminderMessageDto message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // Declare the queue - creates it if it doesn't exist yet (safe to call every time)
            await channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,      // survives RabbitMQ restart
                exclusive: false,
                autoDelete: false
            );

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: QueueName,
                body: body
            );
        }
    }
}