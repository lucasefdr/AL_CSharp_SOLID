using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Shows;

[DocComando(instrucao: "show-clientes", documentacao: "adopet show-clientes <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class ShowClientes(ILeitorDeArquivos<Cliente> leitorDeArquivos) : IComando
{
    public Task<Result> ExecutarAsync()
    {
        return ExibeConteudoDoArquivo();
    }

    private Task<Result> ExibeConteudoDoArquivo()
    {
        try
        {
            var listaDeClientes = leitorDeArquivos.RealizaLeitura()!;
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithClientes(listaDeClientes, "Exibição realizada com sucesso!")));
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição falhou!").CausedBy(exception)));
        }
    }
}
