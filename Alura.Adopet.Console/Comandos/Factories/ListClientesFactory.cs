using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.Lists;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.Factories;

public class ListClientesFactory : IComandoFactory
{
    public bool ConsegueCriarTipo(Type? tipoComando) => tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;

    public IComando? CriarComando(string? argumento)
    {
        // Instancia o serviço de Cliente
        var clienteService = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
        return new ListClientes(clienteService);
    }
}
