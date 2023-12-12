using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Services.Arquivos.CSV;
using Alura.Adopet.Console.Services.Arquivos.JSON;

namespace Alura.Adopet.Console.Services.Arquivos;

public static class LeitorDeArquivosFactory
{
    public static ILeitorDeArquivos<Pet>? CreatePetFrom(string? caminhoDoArquivo)
    {
        var extensao = Path.GetExtension(caminhoDoArquivo);

        return extensao switch
        {
            ".csv" => new PetsCSV(caminhoDoArquivo),
            ".json" => new PetsJSON(caminhoDoArquivo),
            _ => null
        };
    }

    public static ILeitorDeArquivos<Cliente>? CreateClienteFrom(string? caminhoDoArquivo)
    {
        var extensao = Path.GetExtension(caminhoDoArquivo);

        return extensao switch
        {
            ".csv" => new ClientesCSV(caminhoDoArquivo),
            ".json" => new ClientesJSON(caminhoDoArquivo),
            _ => null
        };
    }
}
