using Alura.Adopet.Console;
using Alura.Adopet.Console.Services;
using Moq;

namespace Alura.Adopet.Testes.UnitTests;

public class ImportTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
    {
        // Arrange
        // Mock LeitorDeArquivo
        var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default,
            It.IsAny<string>());

        var listaDePet = new List<Pet>();

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

        // Mock para simular conexão
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
            It.IsAny<HttpClient>());

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        string[] args = { "import", "lista.csv" };

        // Act
        await import.ExecutarAsync(args);

        // Assert
        httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
    }
}
