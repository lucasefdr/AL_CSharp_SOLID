using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console;
[DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import(IAPIService httpClientPet, ILeitorDeArquivos leitorDeArquivo) : IComando
{
    public async Task<Result> ExecutarAsync()
    {
        return await ImportacaoArquivoPetAsync();

    }

    private async Task<Result> ImportacaoArquivoPetAsync()
    {
        try
        {
            var listaDePet = leitorDeArquivo.RealizaLeitura()!;

            foreach (var pet in listaDePet)
            {
                await httpClientPet.CreatePetAsync(pet);
            }

            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação realizada com sucesso!"));
        }
        catch (Exception excpetion)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(excpetion));
        }
    }
}

