using Alura.Adopet.Console.Services.Abstractions;

namespace Alura.Adopet.Console.Services.Arquivos;

public class LeitorDeArquivosCSV : ILeitorDeArquivos
{
    private string? _caminhoDoArquivo;

    public LeitorDeArquivosCSV(string? caminhoDoArquivo)
    {
        _caminhoDoArquivo = caminhoDoArquivo;
    }

    public virtual IEnumerable<Pet> RealizaLeitura()
    {

        if (string.IsNullOrEmpty(_caminhoDoArquivo)) return null;

        var listaDePets = new List<Pet>();

        // Cria uma instância de StreamReader para ler o arquivo
        using StreamReader sr = new(_caminhoDoArquivo);

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
