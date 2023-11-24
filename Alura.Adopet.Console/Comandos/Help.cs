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
    private readonly Dictionary<string, DocComandoAttribute> docs;
    private string? comando;

    public Help(string comando)
    {
        docs = DocumentacaoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        this.comando = comando;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return Task.FromResult(Result.Ok()
                .WithSuccess(new SuccessWithDocs(GeraDocumentacao())));
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Ajuda falhou!").CausedBy(exception)));
        }
    }

    private IEnumerable<string> GeraDocumentacao()
    {
        var resultado = new List<string>();

        // Se não passou mais nenhum argumento mostra help de todos os comandos
        if (comando is null)
        {
            foreach (var doc in docs.Values)
            {
                resultado.Add(doc.Documentacao);
            }
        }
        else
        {
            if (docs.TryGetValue(comando, out DocComandoAttribute? value))
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
