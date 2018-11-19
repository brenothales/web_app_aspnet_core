using System;
using Microsoft.Extensions.Logging;

namespace WebAppAspnetcore.Services
{
    public class NullMailService(ILogger<NullMailService> logger)
    {
        
        public void SendMessage(string to, string subject, string body )
        {

        }
    }
}
