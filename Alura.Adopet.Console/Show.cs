namespace Alura.Adopet.Console;
using System;

internal class Show
{
    public void MostrarDadosDeImportacao(string caminhoDoArquivoASerExibido)
    {
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
        {
            Console.WriteLine("----- Serão importados os dados abaixo -----");
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');

                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]), propriedades[1], TipoPet.Cachorro);
                Console.WriteLine(pet);
            }
        }
    }
}
