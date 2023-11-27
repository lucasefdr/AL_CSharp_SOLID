using Alura.Adopet.Console.Services.Http;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes.UnitTests;

public class HttpClientPetTest
{
    [Fact]
    public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();

        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(@"
                [
                    {
                        ""id"": ""456b24f4-19e2-4423-845d-4a80e8854a41"",
                        ""nome"": ""Romeu"",
                        ""tipo"": 0,
                        ""proprietario"": null
                    },
                    {
                        ""id"": ""456b24f4-19e3-4423-845d-4a80e8854a41"",
                        ""nome"": ""Lexie"",
                        ""tipo"": 1,
                        ""proprietario"": null
                    }
                 ]")
        };

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>
                ("SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);

        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

        var httpClientPet = new HttpClientPet(httpClient.Object);

        // Act
        var lista = await httpClientPet.ListAsync();

        // Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }

    [Fact]
    public async Task APIForaDeveRetornarUmaExcecao()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>
                ("SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new SocketException());

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

        var httpClientPet = new HttpClientPet(httpClient.Object);

        // Act + Assert
        // Valida se retorna qualquer exceção do tipo SocketException
        await Assert.ThrowsAnyAsync<SocketException>(() => httpClientPet.ListAsync());
    }
}