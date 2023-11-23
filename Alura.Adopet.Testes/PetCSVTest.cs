using Alura.Adopet.Console;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes;

public class PetCSVTest
{
    [Fact]
    public void QuandoStringForValidaDeveRetornarUmPet()
    {
        // Arrange
        var linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

        // Act
        Pet pet = linha.ConverteCSV();

        // Assert
        Assert.NotNull(pet);
    }
}
