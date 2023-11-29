using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Http;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? Create(string[] entrada)
    {
        if (entrada is null || entrada.Length == 0) return null;

        // Valida se há segundo argumento
        string? argumento = entrada.Length == 2 ? entrada[1] : null;

        // Instancia o HttpClientPet
        var httpClientPet = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));

        // Instancia o leitor de arquivo
        var leitorDeArquivo = LeitorDeArquivosFactory.CreatePetFrom(argumento);

        return entrada[0] switch
        {
            "help" => new Help(argumento!),
            "import" => new Import(httpClientPet, leitorDeArquivo!),
            "show" => new Show(leitorDeArquivo!),
            "list" => new List(httpClientPet),
            _ => null
        };
    }
}
