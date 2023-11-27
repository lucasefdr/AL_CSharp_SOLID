using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Http;
using Moq;

namespace Alura.Adopet.Testes.Builder;

public static class HttpClientPetBuilder
{
    public static Mock<HttpClientPet> GetMock()
        => new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());

    public static Mock<HttpClientPet> GetMockList(List<Pet> pets)
    {
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
        httpClientPet.Setup(_ => _.ListAsync()).ReturnsAsync(pets);

        return httpClientPet;
    }
}
