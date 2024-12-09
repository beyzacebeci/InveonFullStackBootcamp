using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class BeforeDIP
    {
        public class EmailService
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"email sent {message}");
            }
        }

        public class Notification
        {
            private readonly EmailService _emailService;

            public Notification()
            {
                _emailService = new EmailService();
            }

            public void Send(string message)
            {
                _emailService.SendEmail(message);
            }
        }

    }
}
