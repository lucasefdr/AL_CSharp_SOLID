using Alura.Adopet.Console.Services.Abstractions;
using System.Net.Mail;

namespace Alura.Adopet.Console.Mail;

public class SmtpClientMailService(SmtpClient smtp) : IMailService
{
    public Task SendMailAsync(string sender, string recipient, string subject, string body)
    {
        // Create a new mail message
        MailMessage message = new()
        {
            From = new MailAddress(sender),
            Subject = subject,
            Body = body,
        };

        // Add recipient to mail
        message.To.Add(recipient);

        // Send mail
        smtp.Send(message);

        return Task.CompletedTask;
    }
}
