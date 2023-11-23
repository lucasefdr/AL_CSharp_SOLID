
namespace Alura.Adopet.Console.Util;

public static class PetCSV
{
    public static Pet ConverteCSV(this string linha)
    {
        string[] propriedades = linha.Split(';');

        return new Pet(Guid.Parse(propriedades[0]),
                                  propriedades[1],
                                  int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);
    }
}
