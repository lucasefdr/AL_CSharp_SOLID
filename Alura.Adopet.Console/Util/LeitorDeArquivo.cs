namespace Alura.Adopet.Console;
using System;

internal class LeitorDeArquivo
{
    public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    {
        var listaDePets = new List<Pet>();

        // Cria uma instância de StreamReader para ler o arquivo
        using StreamReader sr = new(caminhoDoArquivoASerLido);

        while (!sr.EndOfStream)
        {
            // Separa linha usando ponto e vírgula
            string[] propriedades = sr.ReadLine()!.Split(';');

            // Cria objeto Pet a partir da separação
            Pet pet = new Pet(Guid.Parse(propriedades[0]),
                propriedades[1],
                int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);

            // Adiciona o pet na lista
            listaDePets.Add(pet);
        }

        return listaDePets;
    }
}
