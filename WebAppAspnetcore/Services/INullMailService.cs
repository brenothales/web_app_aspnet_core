using Microsoft.Extensions.Logging;

namespace WebAppAspnetcore.Services
{
    public interface IMailService
    {


        void SendMessage(string to, string subject, string body);
    }
}