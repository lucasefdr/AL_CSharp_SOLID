using Alura.Adopet.Console.Services.Abstractions;

namespace Alura.Adopet.Console.Services.Arquivos.JSON;

public abstract class LeitorDeArquivosJSON<T>(string? caminhoDoArquivo) : ILeitorDeArquivos<T>
{
    public virtual IEnumerable<T>? RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivo)) return null;
        return CriarDaLinhaJSON();
    }

    public abstract IEnumerable<T>? CriarDaLinhaJSON();
}
