using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.Lists;
using Alura.Adopet.Console.Comandos.Shows;
using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Console.Comandos.Factories;

public class ShowClientesFactory : IComandoFactory
{
    public bool ConsegueCriarTipo(Type? tipoComando) => tipoComando?.IsAssignableTo(typeof(ShowClientes)) ?? false;

    public IComando? CriarComando(string? argumento)
    {
        var leitorDeArquivos = LeitorDeArquivosFactory.CreateClienteFrom(argumento);
        return leitorDeArquivos is not null ? new ShowClientes(leitorDeArquivos) : null;
    }
}
