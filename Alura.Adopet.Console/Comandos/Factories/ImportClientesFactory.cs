using Alura.Adopet.Console.Comandos.Imports;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Http;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.Factories;

public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarTipo(Type? tipoComando) => tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;

    public IComando? CriarComando(string? argumento)
    {
        var clienteService = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
        var leitorDeArquivoCliente = LeitorDeArquivosFactory<Cliente>.CreateClienteFrom(argumento);
        return new ImportClientes(clienteService, leitorDeArquivoCliente!);
    }
}

