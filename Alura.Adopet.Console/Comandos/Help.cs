namespace Alura.Adopet.Console;
using System.Reflection;
using System;
using Alura.Adopet.Console.Comandos;
using System.Threading.Tasks;
using Alura.Adopet.Console.Util;
using FluentResults;

[DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informaçãoes de ajuda.\n" +
                                             "aodnet help <NOME_COMANDO> para acessar a ajuda de um comando específico")]
public class Help : IComando
{
    public Help()
    {
        docs = DocumentacaoSistema.ToDictionary(Assembly.GetExecutingAssembly());
    }

    public Task<Result> ExecutarAsync(string[] args)
    {
        try
        {
            return Task.FromResult(Result.Ok()
                .WithSuccess(new SuccessWithDocs(GeraDocumentacao(args))));
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Ajuda falhou!").CausedBy(exception)));
        }
    }

    private readonly Dictionary<string, DocComandoAttribute> docs;

    private IEnumerable<string> GeraDocumentacao(string[] entrada)
    {
        var resultado = new List<string>();
        Console.WriteLine("Lista de comandos");

        // Se não passou mais nenhum argumento mostra help de todos os comandos
        if (entrada.Length == 1)
        {
            foreach (var doc in docs.Values)
            {
                resultado.Add(doc.Documentacao);
            }
        }
        else if (entrada.Length == 2)
        {
            var comandoASerExibido = entrada[1];

            if (docs.TryGetValue(comandoASerExibido, out DocComandoAttribute? value))
            {
                var comando = value;
                resultado.Add(comando.Documentacao);
            }
            else
            {
                resultado.Add("Comando não encontrado!");
            }
        }
        return resultado;
    }
}
