using Alura.Adopet.Console.Comandos.Interfaces;

namespace Alura.Adopet.Console.Comandos.Factories;

public class HelpFactory : IComandoFactory
{
    public bool ConsegueCriarTipo(Type? tipoComando) => tipoComando?.IsAssignableTo(typeof(Help)) ?? false;

    public IComando? CriarComando(string? argumento) => new Help(argumento);
}
