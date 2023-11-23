using System.Reflection;

namespace Alura.Adopet.Console.Util;

public static class DocumentacaoSistema
{
    public static Dictionary<string, DocComandoAttribute> ToDictionary(Assembly assembly)
        => assembly.GetTypes()
        .Where(t => t.GetCustomAttributes<DocComandoAttribute>().Any())
        .Select(t => t.GetCustomAttribute<DocComandoAttribute>()!)
        .ToDictionary(d => d.Instrucao, d => d);
}
