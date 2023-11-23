namespace Alura.Adopet.Console.Comandos;

internal interface IComando
{
    Task ExercutarAsync(string[] args);
}
