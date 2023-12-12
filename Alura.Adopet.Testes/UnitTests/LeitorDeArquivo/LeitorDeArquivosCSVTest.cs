using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Services.Arquivos.CSV;

namespace Alura.Adopet.Testes.UnitTests.LeitorDeArquivo;

public class LeitorDeArquivoCSVTest : IDisposable
{
    private string _caminhoArquivo;

    public LeitorDeArquivoCSVTest()
    {
        // Setup
        var linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Romeu;1";
        File.WriteAllText("lista.csv", linha);
        _caminhoArquivo = Path.GetFullPath("lista.csv");
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange            
        //Act
        var listaDePets = new PetsCSV(_caminhoArquivo).RealizaLeitura();

        //Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistenteDeveRetornarNulo()
    {
        //Arrange            
        //Act
        var listaDePets = new PetsCSV("").RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNuloDeveRetornarNulo()
    {
        //Arrange            
        //Act
        var listaDePets = new PetsCSV(null).RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }


    public void Dispose()
    {
        //ClearDown
        File.Delete(_caminhoArquivo);
    }
}
