using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Services.Arquivos.CSV;
using Alura.Adopet.Console.Services.Arquivos.JSON;

namespace Alura.Adopet.Console.Util;

public static class LeitorDeArquivosFactory<T>
{
    public static ILeitorDeArquivos<Pet>? CreatePetFrom(string? argumento)
    {
        // Obtem a extensão do arquivo
        var extensao = Path.GetExtension(argumento);

        // Retorna o leitor de arquivo de acordo com a extensão
        return extensao switch
        {
            ".csv" => new PetsCSV(argumento),
            ".json" => new PetsJSON(argumento),
            _ => null
        };
    }

    public static ILeitorDeArquivos<Cliente>? CreateClienteFrom(string? argumento)
    {
        // Obtem a extensão do arquivo
        var extensao = Path.GetExtension(argumento);

        // Retorna o leitor de arquivo de acordo com a extensão
        return extensao switch
        {
            ".csv" => new ClientesCSV(argumento),
            ".json" => new ClientesJSON(argumento),
            _ => null
        };
    }
}
