namespace Alura.Adopet.Console.Settings;

public class MailSettings
{
    public const string Section = "AdopetEmailConfiguration";
    public string? Server { get; set; }
    public int Port { get; set; }
    public string? User { get; set; }
    public string? Password { get; set; }
}
