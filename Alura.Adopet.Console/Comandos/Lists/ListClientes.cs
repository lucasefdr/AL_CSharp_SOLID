using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Lists;

[DocComando(instrucao: "list-clientes", documentacao: "adopet list-clientes comando que exibe no terminal o conteúdo cadastrado na base de dados do AdoPet.")]
public class ListClientes(IAPIService<Cliente> httpClientCliente) : IComando
{
    public async Task<Result> ExecutarAsync() => await ListaClientesAsync();

    private async Task<Result> ListaClientesAsync()
    {
        try
        {
            var listaDeClientes = await httpClientCliente.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClientes(listaDeClientes!, "Listagem realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}
