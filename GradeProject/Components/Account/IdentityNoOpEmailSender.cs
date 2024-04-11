using System.Threading.Tasks;
using GradeProject.Data;
using Microsoft.Extensions.Configuration;
using GradeProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GradeProject.Components.Account
{
    internal sealed class IdentityNoOpEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IEmailSender _emailSender;

        public IdentityNoOpEmailSender(IConfiguration config)
        {
            _emailSender = new EmailSender(config);
        }

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            string subject = "Potvr�te svoj email";
            string body = $"Pros�m, potvr�te svoj ��et kliknut�m <a href='{confirmationLink}'>sem</a>.";
            return _emailSender.SendEmailAsync(email, subject, body);
        }

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            string subject = "Obnovenie hesla";
            string body = $"Pros�m, obnovte svoje heslo kliknut�m <a href='{resetLink}'>sem</a>.";
            return _emailSender.SendEmailAsync(email, subject, body);
        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            string subject = "Obnovenie hesla";
            string body = $"Pros�m, obnovte svoje heslo pomocou nasleduj�ceho k�du: {resetCode}";
            return _emailSender.SendEmailAsync(email, subject, body);
        }
    }
}       