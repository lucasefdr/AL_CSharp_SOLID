namespace Alura.Adopet.Console;

using Alura.Adopet.Console.Util;
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
            var propriedades = sr.ReadLine()!.Split(';');

            var pet = new Pet(Guid.Parse(propriedades[0]),
                              propriedades[1],
                              int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);

            listaDePets.Add(pet);
        }

        return listaDePets;
    }
}
