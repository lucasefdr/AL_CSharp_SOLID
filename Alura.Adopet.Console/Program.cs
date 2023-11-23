using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;

Console.ForegroundColor = ConsoleColor.Green;

var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));

var comandosDoSistema = new Dictionary<string, IComando>()
{
    {"help", new Help()},
    {"import", new Import(httpClientPet)},
    {"show", new Show()},
    {"list", new List(httpClientPet)}
};

try
{
    var comando = args[0].Trim();

    if (!comandosDoSistema.ContainsKey(comando)) Console.WriteLine("Comando inválido.");

    var comandoDeEntrada = comandosDoSistema[comando];

    await comandoDeEntrada.ExercutarAsync(args);
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}