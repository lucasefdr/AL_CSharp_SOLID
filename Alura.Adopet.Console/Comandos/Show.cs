namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;
using FluentResults;
using System;
using System.Threading.Tasks;

[DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    private readonly LeitorDeArquivo _leitorDeArquivo;

    public Show(LeitorDeArquivo leitorDeArquivo)
    {
        _leitorDeArquivo = leitorDeArquivo;
    }

    public Task<Result> ExecutarAsync()
    {
        return ExibeConteudoDoArquivo();
    }

    private Task<Result> ExibeConteudoDoArquivo()
    {
        try
        {
            var listaDePets = _leitorDeArquivo.RealizaLeitura()!;
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Exibição realizada com sucesso!")));
        }
        catch (Exception excpetion)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição falhou!").CausedBy(excpetion)));
        }
    }
}
