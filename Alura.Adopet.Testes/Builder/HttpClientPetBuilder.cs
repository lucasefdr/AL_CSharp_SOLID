using Alura.Adopet.Console;
using Alura.Adopet.Console.Services;
using Moq;

namespace Alura.Adopet.Testes.Builder;

public static class HttpClientPetBuilder
{
    public static Mock<HttpClientPet> GetMock()
        => new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());

    public static Mock<HttpClientPet> GetMockList(List<Pet> pets)
    {
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
        httpClientPet.Setup(_ => _.ListPetsAsync()).ReturnsAsync(pets);

        return httpClientPet;
    }
}
