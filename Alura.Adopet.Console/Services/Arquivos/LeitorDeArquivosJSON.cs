
using Alura.Adopet.Console.Services.Abstractions;
using System.Text.Json;

namespace Alura.Adopet.Console.Services.Arquivos;

public class LeitorDeArquivosJSON(string caminhoArquivo) : ILeitorDeArquivos
{
    private readonly string _caminhoArquivo = caminhoArquivo;

    public IEnumerable<Pet> RealizaLeitura()
    {
        using var stream = new FileStream(_caminhoArquivo, FileMode.Open, FileAccess.Read);

        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream) ?? Enumerable.Empty<Pet>();
    }
}
