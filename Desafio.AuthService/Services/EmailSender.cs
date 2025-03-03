using Desafio.AuthService.Models;
using Microsoft.AspNetCore.Identity;

namespace Desafio.AuthService.Services;
public class EmailSender : IEmailSender<User>
{
    public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailAsync(User user, string subject, string htmlMessage)
    {
        // Não faz nada
        return Task.CompletedTask;
    }

    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        throw new NotImplementedException();
    }

    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        throw new NotImplementedException();
    }
}
