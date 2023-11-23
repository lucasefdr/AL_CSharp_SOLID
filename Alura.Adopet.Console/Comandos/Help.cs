namespace Alura.Adopet.Console;
using System.Reflection;
using System;
using Alura.Adopet.Console.Comandos;
using System.Threading.Tasks;
using Alura.Adopet.Console.Util;

[DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informaçãoes de ajuda.\n" +
                                             "aodnet help <NOME_COMANDO> para acessar a ajuda de um comando específico")]
internal class Help : IComando
{
    public Help()
    {
        docs = DocumentacaoSistema.ToDictionary(Assembly.GetExecutingAssembly());
    }

    public Task ExercutarAsync(string[] args)
    {
        ExibeInformacoesDeAjuda(args);
        return Task.CompletedTask;
    }

    private Dictionary<string, DocComandoAttribute> docs;

    private void ExibeInformacoesDeAjuda(string[] entrada)
    {
        Console.WriteLine("Lista de comandos");

        // Se não passou mais nenhum argumento mostra help de todos os comandos
        if (entrada.Length == 1)
        {
            Console.WriteLine("adopet help <parametro> ou simplemente adopet help  " +
                              "comando que exibe informações de ajuda dos comandos.");
            Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            Console.WriteLine("Comando possíveis: ");

            foreach (var doc in docs.Values)
            {
                Console.WriteLine(doc.Documentacao);
            }
        }
        else if (entrada.Length == 2)
        {
            var comandoASerExibido = entrada[1];
            var comando = docs[comandoASerExibido];

            if (docs.ContainsKey(comandoASerExibido)) Console.WriteLine(comando.Documentacao);
            else Console.WriteLine("Comando inválido.");
        }
    }
}
