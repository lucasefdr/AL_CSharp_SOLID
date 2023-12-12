using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Services.Arquivos.JSON;

public class PetsJSON(string? caminhoDoArquivo) : LeitorDeArquivosJSON<Pet>(caminhoDoArquivo)
{
    public override IEnumerable<Pet>? CriarDaLinhaJSON()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivo)) return null;

        using FileStream stream = new(caminhoDoArquivo, FileMode.Open, FileAccess.Read);

        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream, jsonOptions) ?? Enumerable.Empty<Pet>();
    }

}
