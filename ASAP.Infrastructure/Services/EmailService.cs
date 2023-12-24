using ASAP.Domain.Services;
using System.Net.Mail;
using System.Net;

namespace ASAP.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public void SendMail(string Email)
        {
            // SMTP server settings
            string smtpServer = "your_smtp_server"; // e.g., smtp.example.com
            int smtpPort = 587; // Port number (587 is commonly used for TLS)
            string smtpUsername = "your_email@example.com"; // Your email address
            string smtpPassword = "your_password"; // Your email password or app-specific password

            // Sender and recipient email addresses
            string senderEmail = "your_email@example.com";
            string recipientEmail = "recipient@example.com";

            // Create a MailMessage object
            var mailMessage = new MailMessage(senderEmail, recipientEmail)
            {
                Subject = "Subject of the email",
                Body = "Body of the email"
            };

            // Create an instance of SmtpClient
            var smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                EnableSsl = true, // Enable SSL/TLS
                Credentials = new NetworkCredential(smtpUsername, smtpPassword)
            };

            // Send the email
            smtpClient.Send(mailMessage);

        }

        public void SendMails(List<string> Emails)
        {
            try
            {
                // SMTP server settings
                string smtpServer = "your_smtp_server"; // e.g., smtp.example.com
                int smtpPort = 587; // Port number (587 is commonly used for TLS)
                string smtpUsername = "your_email@example.com"; // Your email address
                string smtpPassword = "your_password"; // Your email password or app-specific password

                // Sender's email address
                string senderEmail = "your_email@example.com";

                // Create a MailMessage object
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail)
                };

                foreach (string recipientEmail in Emails)
                {
                    mailMessage.To.Add(recipientEmail);
                }

                mailMessage.Subject = "Subject of the email";
                mailMessage.Body = "Body of the email";

                // Create an instance of SmtpClient
                var smtpClient = new SmtpClient(smtpServer, smtpPort)
                {
                    EnableSsl = true, // Enable SSL/TLS
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword)
                };

                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
