using Alura.Adopet.Console;

namespace Alura.Adopet.Testes.Builder;

public class PetBuilder
{
    public static Pet GetPet()
    {
        return new Pet(new Guid("01303089-833f-46ff-9f06-77f9d4f89f1d"), "Romeu", TipoPet.Cachorro);
    }
}