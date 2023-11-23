namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;

[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly HttpClientPet _httpClientPet;
    private readonly LeitorDeArquivo _leitorDeArquivo;

    public Import(HttpClientPet httpClientPet, LeitorDeArquivo leitorDeArquivo)
    {
        _httpClientPet = httpClientPet;
        _leitorDeArquivo = leitorDeArquivo;
    }

    public async Task ExecutarAsync(string[] args)
    {
        await ImportacaoArquivoPetAsync(args[1]);
    }

    private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        var listaDePet = _leitorDeArquivo.RealizaLeitura();

        foreach (var pet in listaDePet)
        {
            Console.WriteLine("Importando: " + pet);
            try
            {
                await _httpClientPet.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Importação concluída!");
    }
}

