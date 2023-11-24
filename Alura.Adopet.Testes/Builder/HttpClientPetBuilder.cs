using Alura.Adopet.Console.Services;
using Moq;

namespace Alura.Adopet.Testes.Builder;

public static class HttpClientPetBuilder
{
    public static Mock<HttpClientPet> CriaMock()
        => new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
}
