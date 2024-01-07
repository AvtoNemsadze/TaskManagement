using SendGrid;
using SendGrid.Helpers.Mail;
using TaskManagement.Application.Models.Mail;
using TaskManagement.Application.Contracts.Infrastructure;

namespace TaskManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings;
        public EmailSender(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings ?? throw new ArgumentNullException(nameof(emailSettings));
        }

        public async Task<bool> SendTemplatedEmailAsync(TemplatedEmailModel request)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            
            SendGridMessage message = MailHelper.CreateSingleEmail(new EmailAddress(_emailSettings.Email), new EmailAddress(request.Receiver), request.Subject, request.Body, request.Body);
            
            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
