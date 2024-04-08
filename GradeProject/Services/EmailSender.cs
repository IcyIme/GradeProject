using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace GradeProject.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Create a new MimeMessage
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("IcyIme", "icyime8@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            // Create the body part of the email
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlMessage;

            // Attach the body to the message
            message.Body = bodyBuilder.ToMessageBody();

            // Set up the SMTP client
            using (var client = new SmtpClient())
            {
                // Connect to the SMTP server
                await client.ConnectAsync(_config.GetSection("EmailHost").Value, 587, false);

                // Authenticate with the SMTP server
                await client.AuthenticateAsync(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

                // Send the email
                await client.SendAsync(message);

                // Disconnect from the SMTP server
                await client.DisconnectAsync(true);
            }
        }
    }
}
