using System.Net.Mail;
using System.Net;
using Desafio.NotificacaoService.Models;

namespace Desafio.NotificacaoService.Services
{
    public static class EmailServices
    {
        public static void SendEmail(NotificationMessage message, string username,string password)
        {
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(username),
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(message.To);

            smtpClient.Send(mailMessage);
        }
    }
}
