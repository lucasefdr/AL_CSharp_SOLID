namespace Alura.Adopet.Console;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System;
using Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
internal class List : IComando
{
    public async Task ExercutarAsync(string[] args)
    {
        await ListaPetsAsync();
    }

    HttpClient client;

    public List()
    {
        client = ConfiguraHttpClient("http://localhost:5057");
    }

    private async Task ListaPetsAsync()
    {
        var pets = await ListPetsAsync();

        if (pets != null)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
        }
    }

    private async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }

    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}


