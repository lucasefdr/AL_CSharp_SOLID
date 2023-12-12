using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Imports;

[DocComando(instrucao: "import-pets", documentacao: "adopet import-pets <arquivo> comando que realiza a importação do arquivo de pets.")]
public class ImportPets(IAPIService<Pet> httpClientPet, ILeitorDeArquivos<Pet> leitorDeArquivo) : IComando, IAfterExecution
{
    public event Action<Result>? AfterExecution;

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
                await httpClientPet.CreateAsync(pet);
            }

            var result = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação realizada com sucesso!"));

            // Dispara o evento de AfterExecution
            AfterExecution?.Invoke(result);

            return result;
        }
        catch (Exception excpetion)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(excpetion));
        }
    }
}

