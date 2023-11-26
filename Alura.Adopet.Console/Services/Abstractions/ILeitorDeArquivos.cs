namespace Alura.Adopet.Console.Services.Abstractions;

public interface ILeitorDeArquivos
{
    IEnumerable<Pet> RealizaLeitura();
}
