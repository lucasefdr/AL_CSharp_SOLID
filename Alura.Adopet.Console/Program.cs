using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;
Console.ForegroundColor = ConsoleColor.Green;

var comandosDoSistema = new Dictionary<string, IComando>()
{
    {"help", new Help()},
    {"import", new Import()},
    {"show", new Show()},
    {"list", new List()}
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