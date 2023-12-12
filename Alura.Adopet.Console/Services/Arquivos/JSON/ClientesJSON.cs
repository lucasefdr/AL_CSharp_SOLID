using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Services.Arquivos.JSON;

public class ClientesJSON(string? caminhoDoArquivo) : LeitorDeArquivosJSON<Cliente>(caminhoDoArquivo)
{
    public override IEnumerable<Cliente>? CriarDaLinhaJSON()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivo)) return null;

        using FileStream stream = new(caminhoDoArquivo, FileMode.Open, FileAccess.Read);

        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<IEnumerable<Cliente>>(stream, jsonOptions) ?? Enumerable.Empty<Cliente>();
    }
}
