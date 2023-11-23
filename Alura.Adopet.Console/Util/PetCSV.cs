
namespace Alura.Adopet.Console.Util;

public static class PetCSV
{
    public static Pet ConverteCSV(this string? linha)
    {

        string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser null.");

        if (linha == string.Empty) throw new ArgumentException("Texto não pode ser vazio.");

        if (propriedades.Length != 3) throw new ArgumentException("Quantidade inválida de campos.");

        if (!Guid.TryParse(propriedades[0], out var petGuid)) throw new ArgumentException("Guid inválido.");

        if (!int.TryParse(propriedades[2], out var tipoPet)) throw new ArgumentException("Tipo de pet inválido.");

        if (tipoPet != 0 && tipoPet != 1) throw new ArgumentException("Tipo de pet inválido.");

        return new Pet(petGuid,
                       propriedades[1],
                       tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro);
    }
}
