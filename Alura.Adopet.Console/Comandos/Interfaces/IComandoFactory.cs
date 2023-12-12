namespace Alura.Adopet.Console.Comandos.Interfaces;

public interface IComandoFactory
{
    IComando? CriarComando(string? argumento);
    bool ConsegueCriarTipo(Type? tipoComando);
}
