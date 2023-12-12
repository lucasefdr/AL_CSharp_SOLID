using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.UI;

public static class ConsoleUI
{
    public static void ExibeResultado(Result result)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;

        try
        {
            if (result.IsFailed)
            {
                ExibeFalha(result);
            }
            else
            {
                ExibeSucesso(result);
            }
        }
        finally
        {
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private static void ExibeSucesso(Result result)
    {
        var sucesso = result.Successes.First();

        switch (sucesso)
        {
            case SuccessWithPets successWithPets:
                ExibePets(successWithPets);
                break;
            case SuccessWithDocs successWithDocs:
                ExibeDocs(successWithDocs);
                break;
            case SuccessWithClientes successWithClientes:
                ExibeClientes(successWithClientes);
                break;
        }
    }

    private static void ExibeDocs(SuccessWithDocs successWithDocs)
    {
        System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
        System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");

        foreach (var doc in successWithDocs.Documentacao) System.Console.WriteLine(doc);
    }

    private static void ExibePets(SuccessWithPets successWithPets)
    {
        foreach (var pet in successWithPets.Data) System.Console.WriteLine(pet);
        System.Console.WriteLine(successWithPets.Message);
    }

    private static void ExibeClientes(SuccessWithClientes successWithClientes)
    {
        foreach (var cliente in successWithClientes.Data) System.Console.WriteLine(cliente);
        System.Console.WriteLine(successWithClientes.Message);
    }

    private static void ExibeFalha(Result result)
    {
        System.Console.ForegroundColor = ConsoleColor.Red;

        var error = result.Errors.First();

        System.Console.WriteLine($"Aconteceu uma exceção: {error.Message}");
    }
}
