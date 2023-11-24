using Alura.Adopet.Console;

namespace Alura.Adopet.Testes.UnitTests;

public class HelpTest
{
    [Fact]
    public async Task QuandoComandoNaoExistirDeveRetornarFalha()
    {
        // Arrange  
        var help = new Help("invalid");

        // Act  
        var resultado = await help.ExecutarAsync();

        // Assert   
        Assert.NotNull(resultado);
        Assert.True(resultado.IsFailed);
    }

    [Theory]
    [InlineData("help")]
    [InlineData("show")]
    [InlineData("list")]
    [InlineData("import")]
    public async Task QuandoComandoExistirDeveRetornarSucesso(string comando)
    {
        // Arrange  
        var help = new Help(comando);

        // Act  
        var resultado = await help.ExecutarAsync();

        // Assert   
        Assert.NotNull(resultado);
        Assert.True(resultado.IsSuccess);

    }
}
