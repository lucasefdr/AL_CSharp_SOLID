﻿using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? Create(string[] entrada)
    {
        // Valida se há segundo argumento
        string? argumento = entrada.Length == 2 ? entrada[1] : null;

        // Instancia o HttpClientPet
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));

        // Instancia o leitor de arquivo
        var leitorDeArquivo = new LeitorDeArquivo(argumento);

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
