using Alura.Adopet.Console;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Modelos.Enums;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Http;
using Alura.Adopet.Testes.Builder;
using Moq;

namespace Alura.Adopet.Testes.IntegrationTests;

public class ImportIntegrationTest
{
    // Teste de integração (depende de integração de outros processos)
    [Fact]
    public async void QuandoAPIEstiverNoArDeveRetornarListaDePet()
    {
        // Arrange
        // Mock LeitorDeArquivo
        var listaDePets = new List<Pet>()
        {
            new(new Guid("01303089-833f-46ff-9f06-77f9d4f89f1d"), "Romeu", TipoPet.Cachorro)
        };

        var leitorDeArquivo = LeitorDeArquivoBuilder.GetMock(listaDePets);

        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));

        var import = new Import(httpClientPet, leitorDeArquivo.Object);

        string[] args = { "import", "lista.csv" };

        // Act
        await import.ExecutarAsync();

        // Assert
        var listaPet = await httpClientPet.ListAsync();
        Assert.NotNull(listaPet);
    }


}
