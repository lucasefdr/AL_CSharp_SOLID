using Alura.Adopet.Console;
using Moq;

namespace Alura.Adopet.Testes.Builder;

public static class LeitorDeArquivoBuilder
{
    public static Mock<LeitorDeArquivo> GetMock(List<Pet> listaDePets)
    {
        var leitorDeArquivoMock = new Mock<LeitorDeArquivo>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivoMock.Setup(_ => _.RealizaLeitura()).Returns(listaDePets);

        return leitorDeArquivoMock;
    }
}
