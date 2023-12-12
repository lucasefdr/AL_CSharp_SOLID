using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Imports;


[DocComando(instrucao: "import-clientes", documentacao: "adopet import-clientes <arquivo> comando que realiza a importação do arquivo de clientes.")]
public class ImportClientes(IAPIService<Cliente> httpClientCliente, ILeitorDeArquivos<Cliente> leitorDeArquivo) : IComando
{
    public async Task<Result> ExecutarAsync()
    {
        return await ImportacaoArquivoClientesAsync();
    }

    private async Task<Result> ImportacaoArquivoClientesAsync()
    {
        try
        {
            var listaDeClientes = leitorDeArquivo.RealizaLeitura()!;

            foreach (var cliente in listaDeClientes) await httpClientCliente.CreateAsync(cliente);

            return Result.Ok().WithSuccess(new SuccessWithClientes(listaDeClientes, "Importação realizada com sucesso!"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
        }
    }
}
