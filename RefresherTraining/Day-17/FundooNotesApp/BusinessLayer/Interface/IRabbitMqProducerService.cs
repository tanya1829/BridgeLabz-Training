using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.DTOs.Response;

namespace FundooNotesApp.Business.Interface
{
    public interface IRabbitMqProducerService
    {
        Task PublishReminderAsync(ReminderMessageDto message);
    }
}