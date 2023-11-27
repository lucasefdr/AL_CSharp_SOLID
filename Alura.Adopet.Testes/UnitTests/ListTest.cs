using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;

namespace Alura.Adopet.Testes.UnitTests;

public class ListTest
{
    [Fact]
    public async Task QuandoExecutarComandoDeveRetornarUmaListaDePets()
    {
        /* Arrange */
        var listaDePets = new List<Pet> { PetBuilder.GetPet() };

        // Mock para simular conexão
        var httpClientPet = HttpClientPetBuilder.GetMockList(listaDePets);

        // Act
        var retorno = await new Alura.Adopet.Console.List(httpClientPet.Object)
            .ExecutarAsync();

        // Assert
        var resultado = retorno.Successes.First() as SuccessWithPets;
        Assert.Single(resultado!.Data);
    }
}
