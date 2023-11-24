using Alura.Adopet.Console;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;
using Moq;

namespace Alura.Adopet.Testes.UnitTests;

public class ShowTest
{
    [Fact]
    public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
    {
        // Arrange
        var listaDePets = new List<Pet> { PetBuilder.GetPet() };
        var leitorDeArquivos = LeitorDeArquivoBuilder.GetMock(listaDePets);
        leitorDeArquivos.Setup(_ => _.RealizaLeitura());

        var show = new Show(leitorDeArquivos.Object);

        // Act
        var resultado = await show.ExecutarAsync();
        var success = resultado.Successes.First() as SuccessWithPets;

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("Exibição realizada com sucesso!", success!.Message);
    }
}
