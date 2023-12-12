using Alura.Adopet.Console.Services;
using FluentResults;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Comandos.Interfaces;

namespace Alura.Adopet.Console.Comandos.Lists;

[DocComando(instrucao: "list-pets", documentacao: "adopet list-pets comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
public class ListPets(IAPIService<Pet> httpClientPet) : IComando // Primary Constructor
{
    public async Task<Result> ExecutarAsync()
    {
        return await ListaPetsAsync();
    }

    private async Task<Result> ListaPetsAsync()
    {
        try
        {
            var listaDePets = await httpClientPet.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets!, "Listagem realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}


