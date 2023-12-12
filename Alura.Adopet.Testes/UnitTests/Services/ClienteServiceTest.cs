using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Moq;
using Moq.Protected;
using System.Net;

namespace Alura.Adopet.Testes.UnitTests.Services;

public class ClienteServiceTest
{
    [Fact]
    public async Task ListAsyncDeveRetornarUmaListaDeClientesNaoVazia()
    {
        /* ARRANGE */
        Mock<HttpMessageHandler> handlerMock = new();

        // Create a response that returns a 200 status code and a JSON array
        HttpResponseMessage response = new()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(@"
                [
                    {
                        ""id"": ""456b24f4-19e2-4423-845d-4a80e8854a33"",
                        ""nome"": ""Lucas Ferreira"",
                        ""cpf"": ""12345678900"",
                        ""email"": ""lucas@email.com""
                    },
                    {
                        ""id"": ""456b24f4-19e2-4423-845d-4dd0e8854a33"",
                        ""nome"": ""Lara Maria"",
                        ""cpf"": ""98765432100"",
                        ""email"": ""lara@email.com""
                    }
                ]")
        };

        // Setup the mock to return the response
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>
                ("SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()).ReturnsAsync(response);

        Mock<HttpClient> httpClientMock = new(MockBehavior.Default, handlerMock.Object);
        httpClientMock.Object.BaseAddress = new Uri("http://localhost:5057");

        // Create the service and inject the client object
        ClienteService clienteService = new(httpClientMock.Object);

        /* ACT */
        // Call the service method
        IEnumerable<Cliente>? clienteList = await clienteService.ListAsync();

        /* ASSERT */
        // Assert that the list is not null and not empty
        Assert.NotNull(clienteList);
        Assert.NotEmpty(clienteList);
    }
}
