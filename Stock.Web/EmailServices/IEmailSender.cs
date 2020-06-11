using System.Threading.Tasks;

namespace Stock.Web.EmailServices
{
    public interface IEmailSender
    {

        Task SendEmailAsync(string email, string subject, string htmlMessage);

    }
}
