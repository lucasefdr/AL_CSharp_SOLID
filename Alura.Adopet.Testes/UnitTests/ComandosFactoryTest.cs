using Alura.Adopet.Console.Comandos.Factories;
using Alura.Adopet.Console.Comandos.Imports;
using Alura.Adopet.Console.Comandos.Lists;

namespace Alura.Adopet.Testes.UnitTests;

public class ComandosFactoryTest
{
    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoImportPet()
    {
        // Arrange
        string[] args = ["import", "lista.csv"];

        // Act
        var resultado = ComandosFactory.Create(args);

        // Assert
        Assert.IsType<ImportPets>(resultado);
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

    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoList()
    {
        // Arrange
        string[] args = ["list", "lista.csv"];

        // Act
        var resultado = ComandosFactory.Create(args);

        // Assert
        Assert.IsType<ListPets>(resultado);
    }

    [Theory]
    [InlineData("import", "Import")]
    [InlineData("import-clientes", "ImportClientes")]
    [InlineData("show", "Show")]
    [InlineData("list", "List")]
    [InlineData("help", "Help")]
    public void DadoParametroValidoDeveRetornarObjetoNaoNulo(string instrucao, string nomeTipo)
    {
        // arrange
        string[] args = new[] { instrucao, "lista.csv" };
        // act
        var comando = ComandosFactory.Create(args);
        // assert
        Assert.NotNull(comando);
        Assert.Equal(nomeTipo, comando.GetType().Name);
    }

}
