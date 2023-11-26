﻿using Alura.Adopet.Console;
using Alura.Adopet.Console.Services.Arquivos;
using Moq;

namespace Alura.Adopet.Testes.Builder;

public static class LeitorDeArquivoBuilder
{
    public static Mock<LeitorDeArquivosCSV> GetMock(List<Pet>? listaDePets)
    {
        var leitorDeArquivoMock = new Mock<LeitorDeArquivosCSV>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivoMock.Setup(_ => _.RealizaLeitura()).Returns(listaDePets);


        return leitorDeArquivoMock;
    }
}
