using Alura.Adopet.Console.Services.Http;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Comandos.Lists;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.Factories;

public class ListPetsFactory : IComandoFactory
{
    public bool ConsegueCriarTipo(Type? tipoComando) => tipoComando?.IsAssignableTo(typeof(ListPets)) ?? false;

    public IComando? CriarComando(string? argumento)
    {
        var petService = new PetService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
        return new ListPets(petService);
    }
}
