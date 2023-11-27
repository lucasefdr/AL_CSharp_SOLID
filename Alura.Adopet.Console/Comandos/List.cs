using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using FluentResults;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
public class List(IAPIService<Pet> httpClientPet) : IComando // Primary Constructor
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


