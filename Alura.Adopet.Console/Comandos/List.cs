namespace Alura.Adopet.Console;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
internal class List : IComando
{
    private readonly HttpClientPet _httpClientPet;

    public List(HttpClientPet httpClientPet)
    {
        _httpClientPet = httpClientPet;
    }

    public async Task ExecutarAsync(string[] args)
    {
        await ListaPetsAsync();
    }

    private async Task ListaPetsAsync()
    {
        var pets = await _httpClientPet.ListPetsAsync();

        if (pets != null)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
        }
    }
}


