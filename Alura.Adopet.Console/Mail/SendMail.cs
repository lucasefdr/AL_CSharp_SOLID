using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Settings;
using Alura.Adopet.Console.Util;
using FluentResults;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Mail;

public static class SendMail
{
    private static IMailService CreateMailService()
    {
        MailSettings settings = Configurations.MailSettings;
        SmtpClient smtp = new()
        {
            Host = settings.Server,
            Port = settings.Port,
            Credentials = new NetworkCredential(userName: settings.User, password: settings.Password),
            EnableSsl = true,
            UseDefaultCredentials = false
        };

        return new SmtpClientMailService(smtp);
    }

    public static void Send(Result result)
    {
        ISuccess? success = result.Successes.FirstOrDefault();
        if (success is null) return;
        if (success is SuccessWithPets successWithPets)
        {
            var emailService = CreateMailService();

            emailService.SendMailAsync(
                sender: "no-reply@adopet.com.br",
                recipient: "lucas.eferreira@totvs.com.br",
                subject: "Adopet - Novos pets para adoção",
                body: $"Foram importados {successWithPets.Data.Count()} pets."
                );
        }
    }
}
