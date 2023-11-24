namespace Alura.Adopet.Console;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using FluentResults;
using Alura.Adopet.Console.Util;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
internal class List : IComando
{
    private readonly HttpClientPet _httpClientPet;

    public List(HttpClientPet httpClientPet)
    {
        _httpClientPet = httpClientPet;
    }

    public async Task<Result> ExecutarAsync(string[] args)
    {
        return await ListaPetsAsync();
    }

    private async Task<Result> ListaPetsAsync()
    {
        try
        {
            var listaDePets = await _httpClientPet.ListPetsAsync();
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets!, "Listagem realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}


