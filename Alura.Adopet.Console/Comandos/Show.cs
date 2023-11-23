namespace Alura.Adopet.Console;
using System;

[DocComando(instrucao: "show", documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show
{
    public void ExibeConteudoDoArquivo(string caminhoDoArquivoASerExibido)
    {
        LeitorDeArquivo leitor = new LeitorDeArquivo();
        var listaDePets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

        Console.WriteLine("----- Serão importados os dados abaixo -----");
        listaDePets.ForEach(Console.WriteLine);
    }
}
