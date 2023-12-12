using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Comandos.Shows;
using Alura.Adopet.Console.Services.Abstractions;
using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Console.Comandos.Factories;

public class ShowPetsFactory : IComandoFactory
{
    public bool ConsegueCriarTipo(Type? tipoComando) => tipoComando?.IsAssignableTo(typeof(ShowPets)) ?? false;

    public IComando? CriarComando(string? argumento)
    {
        var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumento);
        return leitorDeArquivos is not null ? new ShowPets(leitorDeArquivos) : null;
    }
}
