using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes.UnitTests;

public class ComandosFactoryTest
{
    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoImport()
    {
        // Arrange
        string[] args = ["import", "lista.csv"];

        // Act
        var resultado = ComandosFactory.Create(args);

        // Assert
        Assert.IsType<Import>(resultado);
    }

    [Fact]
    public void DadoUmParametroInvalidoDeveRetornarNull()
    {
        // Arrange
        string[] args = ["inválido", "lista.csv"];

        // Act
        var resultado = ComandosFactory.Create(args);

        // Assert
        Assert.Null(resultado);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosDeveRetornarNull()
    {
        // Arrange + Act
        var resultado = ComandosFactory.Create(null!);

        // Assert
        Assert.Null(resultado);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosVazioRetornarNull()
    {
        // Act
        var resultado = ComandosFactory.Create(["", ""]);

        // Assert
        Assert.Null(resultado);
    }
}
