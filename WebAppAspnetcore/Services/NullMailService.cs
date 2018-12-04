using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebAppAspnetcore.Services
{
    public class NullMailService : IMailService
    {
        public ILogger<NullMailService> _Logger { get; }


        public NullMailService(ILogger<NullMailService> _logger)
        {
            _Logger = _logger;
        }



        public void SendMessage(string to, string subject, string body )
        {
            _Logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
