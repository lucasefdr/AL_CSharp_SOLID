namespace Alura.Adopet.Console;
using System;

internal class Help
{
    public void ExibeInformacoesDeAjuda(string[] entrada)
    {
        Console.WriteLine("Lista de comandos");

        // Se não passou mais nenhum argumento mostra help de todos os comandos
        if (entrada.Length == 1)
        {
            Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                 "comando que exibe informações de ajuda dos comandos.");
            Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            Console.WriteLine("Comando possíveis: ");
            Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
            Console.WriteLine($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
            Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");
        }
        else if (entrada.Length == 2)
        {
            var comandoASerExibido = entrada[1];

            if (comandoASerExibido.Equals("import"))
            {
                Console.WriteLine(" adopet import <arquivo> " +
                    "comando que realiza a importação do arquivo de pets.");
            }
            if (comandoASerExibido.Equals("show"))
            {
                Console.WriteLine(" adopet show <arquivo> " +
                    "comando que exibe no terminal o conteúdo do arquivo importado.");
            }
            if (comandoASerExibido.Equals("list"))
            {
                Console.WriteLine(" adopet list " +
                    "comando que exibe no terminal o conteúdo do arquivo importado.");
            }
        }
    }
}
