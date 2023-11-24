using Alura.Adopet.Console;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;
using Moq;

namespace Alura.Adopet.Testes.UnitTests;

public class ImportTest
{
    private readonly string[] args = { "import", "lista.csv" };

    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
    {
        // Arrange
        var listaDePets = new List<Pet>();

        // Mock LeitorDeArquivo
        var leitorDeArquivo = LeitorDeArquivoBuilder.GetMock(listaDePets);

        // Mock para simular conexão
        var httpClientPet = HttpClientPetBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        // Act
        await import.ExecutarAsync();

        // Assert
        httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async void QuandoArquivoNaoExistirDeveLancarFileNotFoundException()
    {
        /* Arrange */
        var listaDePets = new List<Pet>();
        var leitorDeArquivo = LeitorDeArquivoBuilder.GetMock(listaDePets);

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

        var httpClientPet = HttpClientPetBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        /* Act */
        //await Assert.ThrowsAnyAsync<FileNotFoundException>(() => import.ExecutarAsync(args));
        var resultado = await import.ExecutarAsync();

        /* Assert */
        Assert.True(resultado.IsFailed);
    }

    [Fact]
    public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
    {
        // Arrange
        var listaDePets = new List<Pet> { PetBuilder.GetPet() };

        var leitorDeArquivo = LeitorDeArquivoBuilder.GetMock(listaDePets);

        var httpClientPet = HttpClientPetBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        // Act 
        var resultado = await import.ExecutarAsync();

        // Assert
        Assert.True(resultado.IsSuccess);

        var success = resultado.Successes.First() as SuccessWithPets;
        Assert.Equal("Romeu", success!.Data.First().Nome);
    }
}
