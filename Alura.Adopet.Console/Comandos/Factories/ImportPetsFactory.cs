using Alura.Adopet.Console.Comandos.Imports;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Mail;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Http;
using Alura.Adopet.Console.Settings;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos.Factories;

public class ImportPetsFactory : IComandoFactory
{
    public bool ConsegueCriarTipo(Type? tipoComando) => tipoComando?.IsAssignableTo(typeof(ImportPets)) ?? false;

    public IComando? CriarComando(string? argumento)
    {
        var petService = new PetService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
        var leitorDeArquivoPet = LeitorDeArquivosFactory<Pet>.CreatePetFrom(argumento);
        var import = new ImportPets(petService, leitorDeArquivoPet!);

        // Registra o evento de AfterExecution disparando o método Send da classe SendMail
        import.AfterExecution += SendMail.Send;

        return import;
    }
}
