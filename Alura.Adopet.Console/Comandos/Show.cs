namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Comandos;
using System;
using System.Threading.Tasks;

[DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    public Task ExercutarAsync(string[] args)
    {
        ExibeConteudoDoArquivo(args[1]);
        return Task.CompletedTask;
    }

    private void ExibeConteudoDoArquivo(string caminhoDoArquivoASerExibido)
    {
        LeitorDeArquivo leitor = new LeitorDeArquivo();
        var listaDePets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

        Console.WriteLine("----- Serão importados os dados abaixo -----");
        listaDePets.ForEach(Console.WriteLine);
    }
}
