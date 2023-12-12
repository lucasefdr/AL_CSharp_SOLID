using FluentResults;

namespace Alura.Adopet.Console.Comandos.Interfaces;

public interface IComando
{
    Task<Result> ExecutarAsync();
}
