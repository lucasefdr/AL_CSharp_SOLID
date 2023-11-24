using Alura.Adopet.Console;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Testes.Builder;
using Moq;

namespace Alura.Adopet.Testes.UnitTests;

public class ImportTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
    {
        // Arrange
        var listaDePets = new List<Pet>();

        // Mock LeitorDeArquivo
        var leitorDeArquivo = LeitorDeArquivoBuilder.CriaMock(listaDePets);

        // Mock para simular conexão
        var httpClientPet = HttpClientPetBuilder.CriaMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        string[] args = { "import", "lista.csv" };

        // Act
        await import.ExecutarAsync(args);

        // Assert
        httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async void QuandoArquivoNaoExistirDeveLancarFileNotFoundException()
    {
        /* Arrange */
        var listaDePets = new List<Pet>();
        var leitorDeArquivo = LeitorDeArquivoBuilder.CriaMock(listaDePets);

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

        var httpClientPet = HttpClientPetBuilder.CriaMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        string[] args = { "import", "lista.csv" };

        /* Act + Assert */
        await Assert.ThrowsAnyAsync<FileNotFoundException>(() => import.ExecutarAsync(args));
    }
}
