using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class AfterDIP
    {
        public interface IMessageService
        {
            void SendMessage(string message);
        }

        public class EmailService : IMessageService
        {
            public void SendMessage(string message)
            {

                Console.WriteLine($"Email sent: {message}");
            }
        }

        public class SmsService : IMessageService
        {
            public void SendMessage(string message)
            {
                Console.WriteLine($"Sms sent: {message}");
            }
        }

        public class Notification
        {
            private readonly IMessageService _messageService;

            public Notification(IMessageService messageService)
            {
                _messageService = messageService;
            }

            public void Send(string message)
            {
                _messageService.SendMessage(message);
            }
        }

    }
}
