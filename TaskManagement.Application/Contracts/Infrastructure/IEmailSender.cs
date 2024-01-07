using TaskManagement.Application.Models.Mail;

namespace TaskManagement.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendTemplatedEmailAsync(TemplatedEmailModel request);
    }
}
