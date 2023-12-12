namespace Alura.Adopet.Console.Services.Abstractions;

public interface ILeitorDeArquivos<T>
{
    IEnumerable<T>? RealizaLeitura();
}
