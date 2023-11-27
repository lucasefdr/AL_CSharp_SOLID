
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using System.Text.Json;

namespace Alura.Adopet.Console.Services.Arquivos;

public class LeitorDeArquivosJSON(string? caminhoArquivo) : ILeitorDeArquivos
{
    public IEnumerable<Pet>? RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoArquivo)) return null;

        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);

        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream) ?? Enumerable.Empty<Pet>();
    }
}
