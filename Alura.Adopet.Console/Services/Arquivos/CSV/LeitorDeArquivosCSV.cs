using Alura.Adopet.Console.Services.Abstractions;

namespace Alura.Adopet.Console.Services.Arquivos.CSV;

public abstract class LeitorDeArquivosCSV<T>(string? caminhoDoArquivo) : ILeitorDeArquivos<T>
{
    public virtual IEnumerable<T>? RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivo)) return null;

        var lista = new List<T>();

        // Cria uma instância de StreamReader para ler o arquivo
        using StreamReader sr = new(caminhoDoArquivo);

        while (!sr.EndOfStream)
        {
            string? linha = sr.ReadLine();
            if (linha is not null)
            {
                var objeto = CriarDaLinhaCSV(linha);
                lista.Add(objeto);
            }
        }

        return lista;
    }

    public abstract T CriarDaLinhaCSV(string linha);
}