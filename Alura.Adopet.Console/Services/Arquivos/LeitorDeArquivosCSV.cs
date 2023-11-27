using Alura.Adopet.Console.Services.Abstractions;

namespace Alura.Adopet.Console.Services.Arquivos;

public class LeitorDeArquivosCSV(string? caminhoDoArquivo) : ILeitorDeArquivos
{
    public virtual IEnumerable<Pet>? RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoDoArquivo)) return null;

        var listaDePets = new List<Pet>();

        // Cria uma instância de StreamReader para ler o arquivo
        using StreamReader sr = new(caminhoDoArquivo);

        while (!sr.EndOfStream)
        {
            var propriedades = sr.ReadLine()!.Split(';');

            var pet = new Pet(Guid.Parse(propriedades[0]),
                              propriedades[1],
                              int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);

            listaDePets.Add(pet);
        }

        return listaDePets;
    }
}
