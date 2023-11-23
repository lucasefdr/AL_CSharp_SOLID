using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Testes;

public class HttpClientPetTest
{
    [Fact]
    public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
    {
        // Arrange
        var httpClientPet = new HttpClientPet();

        // Act
        var lista = await httpClientPet.ListPetsAsync();

        // Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }

    [Fact]
    public async Task APIForaDeveRetornarUmaExcecao()
    {
        // Arrange
        var httpClientPet = new HttpClientPet("http://localhost:1010");

        // Act + Assert
        // Valida se retorna qualquer exceção do tipo HttpRequestException
        await Assert.ThrowsAnyAsync<HttpRequestException>(async () => await httpClientPet.ListPetsAsync());
    }
}