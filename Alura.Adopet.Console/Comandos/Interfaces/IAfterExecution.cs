using FluentResults;

namespace Alura.Adopet.Console.Comandos.Interfaces;

public interface IAfterExecution
{
    event Action<Result>? AfterExecution;
}
