namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;

[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
internal class Import : IComando
{

    public async Task ExercutarAsync(string[] args)
    {
        await ImportacaoArquivoPetAsync(args[1]);
    }

    private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        LeitorDeArquivo leitor = new();
        var listaDePet = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);

        foreach (var pet in listaDePet)
        {
            Console.WriteLine("Importando: " + pet);
            try
            {
                var httpCreatePet = new HttpClientPet();
                await httpCreatePet.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Importação concluída!");
    }
}

