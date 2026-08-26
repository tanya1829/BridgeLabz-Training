using System.Threading.Tasks;

namespace FundooNotesApp.Business.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}