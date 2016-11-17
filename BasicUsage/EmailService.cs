using System;

namespace BasicUsage
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string message);
    }

    public class ConsoleEmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string message)
        {
            Console.WriteLine($"Sending email to '{to}', with subject '{subject}' and with message: '{message}'");
        }
    }
}
