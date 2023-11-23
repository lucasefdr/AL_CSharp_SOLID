namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Comandos;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;

[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
internal class Import : IComando
{
    HttpClient client;
    public async Task ExercutarAsync(string[] args)
    {
        await ImportacaoArquivoPetAsync(args[1]);
    }

    public Import()
    {
        client = ConfiguraHttpClient("http://localhost:5057");
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
                var resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Importação concluída!");
    }

    Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }
    }

    HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}
