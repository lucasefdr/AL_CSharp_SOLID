namespace Alura.Adopet.Console.Services.Abstractions;

public interface IMailService
{
    Task SendMailAsync(string sender, string recipient, string subject, string body);
}
