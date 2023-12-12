using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{
    private static IConfiguration BuildConfiguration()
        => new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()) // This is the default path
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // This is the default file
        .AddUserSecrets("9300e478-7035-4f11-a4af-b5c331b2bff0") // This is the default user secret
        .Build(); // This is the default builder

    public static ApiSettings ApiSettings
    {
        get
        {
            var _config = BuildConfiguration();
            return _config.GetSection(ApiSettings.Section).Get<ApiSettings>() ?? throw new ArgumentException("API section config not found.");
        }
    }

    public static MailSettings MailSettings
    {
        get
        {
            var _config = BuildConfiguration();
            return _config.GetSection(MailSettings.Section).Get<MailSettings>() ?? throw new ArgumentException("Mail section config not found.");
        }
    }
}

