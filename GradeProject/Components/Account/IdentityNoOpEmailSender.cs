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
            string subject = "Potvrïte svoj email";
            string body = $"Prosím, potvrïte svoj úèet kliknutím <a href='{confirmationLink}'>sem</a>.";
            return _emailSender.SendEmailAsync(email, subject, body);
        }

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            string subject = "Obnovenie hesla";
            string body = $"Prosím, obnovte svoje heslo kliknutím <a href='{resetLink}'>sem</a>.";
            return _emailSender.SendEmailAsync(email, subject, body);
        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            string subject = "Obnovenie hesla";
            string body = $"Prosím, obnovte svoje heslo pomocou nasledujúceho kódu: {resetCode}";
            return _emailSender.SendEmailAsync(email, subject, body);
        }
    }
}       