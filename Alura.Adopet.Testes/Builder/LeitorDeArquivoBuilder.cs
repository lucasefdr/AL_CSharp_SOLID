using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Arquivos.CSV;
using Moq;

namespace Alura.Adopet.Testes.Builder;

public static class LeitorDeArquivoBuilder
{
    public static Mock<LeitorDeArquivosCSV<Pet>> GetMock(List<Pet>? listaDePets)
    {
        var leitorDeArquivoMock = new Mock<LeitorDeArquivosCSV<Pet>>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivoMock.Setup(_ => _.RealizaLeitura()).Returns(listaDePets);


        return leitorDeArquivoMock;
    }
}
