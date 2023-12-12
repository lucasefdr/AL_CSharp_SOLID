using Alura.Adopet.Console.Comandos.Imports;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Http;
using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos.Factories;

public static class ComandosFactory
{
    public static IComando? Create(string[] entrada)
    {
        // Valida se há argumentos
        if (entrada is null || entrada.Length == 0) return null;

        // Primeiro argumento é o comando. Ex: "import-pets"
        var comando = entrada[0];

        // Valida se há segundo argumento. Ex: "import-pets arquivo.csv"
        var argumento = entrada.Length == 2 ? entrada[1] : null;

        // Cria o comando com Reflection
        var tipoComando = Assembly.GetExecutingAssembly().GetTipoComando(comando); // Extension Method da classe Assembly

        // Cria o comando com Reflection
        var listaDeFactories = Assembly.GetExecutingAssembly().GetFactories(); // Extension Method da classe Assembly

        // Valida se o comando existe
        var factory = listaDeFactories.FirstOrDefault(f => f!.ConsegueCriarTipo(tipoComando));

        if (factory is null) return null;

        return factory.CriarComando(argumento);
    }
}
