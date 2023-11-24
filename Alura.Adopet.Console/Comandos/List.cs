using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using FluentResults;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
public class List(HttpClientPet httpClientPet) : IComando // Primary Constructor
{
    private readonly HttpClientPet _httpClientPet = httpClientPet;

    public async Task<Result> ExecutarAsync()
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


