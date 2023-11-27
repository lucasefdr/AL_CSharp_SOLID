using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Console.Util;

public static class LeitorDeArquivosFactory
{
    public static ILeitorDeArquivos? CreatePetFrom(string? argumento)
    {
        // Obtem a extensão do arquivo
        var extensao = Path.GetExtension(argumento);

        // Retorna o leitor de arquivo de acordo com a extensão
        return extensao switch
        {
            ".csv" => new LeitorDeArquivosCSV(argumento),
            ".json" => new LeitorDeArquivosJSON(argumento),
            _ => null
        };
    }
}
