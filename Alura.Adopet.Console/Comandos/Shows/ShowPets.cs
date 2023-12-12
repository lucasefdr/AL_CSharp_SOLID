namespace Alura.Adopet.Console.Comandos.Shows;

using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Util;
using FluentResults;
using System;
using System.Threading.Tasks;

[DocComando(instrucao: "show-pets", documentacao: "adopet show-pets <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class ShowPets(ILeitorDeArquivos<Pet> leitorDeArquivo) : IComando
{
    public Task<Result> ExecutarAsync()
    {
        return ExibeConteudoDoArquivo();
    }

    private Task<Result> ExibeConteudoDoArquivo()
    {
        try
        {
            var listaDePets = leitorDeArquivo.RealizaLeitura()!;
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Exibição realizada com sucesso!")));
        }
        catch (Exception excpetion)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição falhou!").CausedBy(excpetion)));
        }
    }
}
