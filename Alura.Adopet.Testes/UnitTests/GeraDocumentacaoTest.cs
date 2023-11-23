using Alura.Adopet.Console;
using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Testes.UnitTests;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistirComandosNaoDeveRetornarDicionarioVazio()
    {
        // Arrange
        var assembly = Assembly.GetAssembly(typeof(DocComandoAttribute));

        // Act
        var dicionario = DocumentacaoSistema.ToDictionary(assembly!);

        // Assert
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
    }
}
