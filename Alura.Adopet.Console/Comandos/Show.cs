namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Comandos;
using System;
using System.Threading.Tasks;

[DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    private readonly LeitorDeArquivo _leitorDeArquivo;
    public Show(LeitorDeArquivo leitorDeArquivo)
    {
        _leitorDeArquivo = leitorDeArquivo;
    }

    public Task ExecutarAsync(string[] args)
    {
        ExibeConteudoDoArquivo(args[1]);
        return Task.CompletedTask;
    }

    private void ExibeConteudoDoArquivo(string caminhoDoArquivoASerExibido)
    {
        var listaDePets = _leitorDeArquivo.RealizaLeitura();

        Console.WriteLine("----- Serão importados os dados abaixo -----");
        listaDePets!.ForEach(Console.WriteLine);
    }
}
