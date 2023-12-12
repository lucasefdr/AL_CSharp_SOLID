using Alura.Adopet.Console.Comandos.Interfaces;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions;

public static class ComandosExtensions
{
    // Extension Method da classe Assembly
    public static Type? GetTipoComando(this Assembly assembly, string instrucao)
        => assembly.GetTypes() // Lista os tipos do assembly
        .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando))) // Filtra os tipos que implementam IComando
        .FirstOrDefault(t => t.GetCustomAttributes<DocComandoAttribute>() // Filtra os tipos que possuem o atributo DocComandoAttribute 
        .Any(d => d.Instrucao.Equals(instrucao))); // Filtra os tipos que possuem o atributo DocComandoAttribute com a instrução informada

    public static IEnumerable<IComandoFactory?> GetFactories(this Assembly assembly)
        => assembly.GetTypes() // Lista os tipos do assembly
        .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory))) // Filtra os tipos que implementam IComandoFactory
        .Select(f => Activator.CreateInstance(f) as IComandoFactory); // Cria uma instância de cada tipo que implementa IComandoFactory
}