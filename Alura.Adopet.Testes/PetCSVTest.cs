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

    [Fact]
    public void QuandoStringForNullDeveLancarArgumentNullException()
    {
        // Arrange
        string? linha = null;

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => linha.ConverteCSV());
    }

    [Fact]
    public void QuandoStringForVaziaDeveLancarArgumentException()
    {
        // Arrange
        string? linha = string.Empty;

        // Act + Assert
        Assert.Throws<ArgumentException>(() => linha?.ConverteCSV());
    }

    [Fact]
    public void QuandoCamposInsuficienteDeCamposDeveLancarArgumentException()
    {
        // Arrange
        // Linha com apenas dois campos
        var linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

        // Act + Assert
        Assert.ThrowsAny<ArgumentException>(() => linha.ConverteCSV());
    }

    [Fact]
    public void QuandoGuidInvalidoDeveLancarArgumentException()
    {
        // Arrange
        // Linha com apenas dois campos
        var linha = "123-123-123;Lima Limão;1";

        // Act + Assert
        Assert.ThrowsAny<ArgumentException>(() => linha.ConverteCSV());
    }

    [Fact]
    public void QuandoTipoInvalidoDeveLancarArgumentException()
    {
        // Arrange
        var linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;2";

        // Act + Assert
        Assert.ThrowsAny<ArgumentException>(() => linha.ConverteCSV());
    }
}
