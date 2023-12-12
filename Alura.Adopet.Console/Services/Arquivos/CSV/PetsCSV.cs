using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Modelos.Enums;

namespace Alura.Adopet.Console.Services.Arquivos.CSV;

public class PetsCSV(string? caminhoDoArquivo) : LeitorDeArquivosCSV<Pet>(caminhoDoArquivo)
{
    public override Pet CriarDaLinhaCSV(string linha)
    {
        var propriedades = linha.Split(';');

        return new Pet(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            tipo: propriedades[2] == "1" ? TipoPet.Gato : TipoPet.Cachorro
            );
    }


}
