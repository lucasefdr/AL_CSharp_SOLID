using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Arquivos.JSON;

namespace Alura.Adopet.Testes.UnitTests.LeitorDeArquivo;

public class LeitorDeArquivosJSONTest : IDisposable
{
    private string _caminhoArquivo;

    public LeitorDeArquivosJSONTest()
    {
        // Cria o conteúdo do arquivo .json
        string conteudo = @"
            [
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""Nome"": ""Mancha"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""Nome"": ""Alvo"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""Nome"": ""Pinta"",
                ""Tipo"": 1
              }
            ]
        ";

        // Cria um nome randômico para o arquivo
        var nomeArquivo = Path.GetRandomFileName();

        // Escreve o arquivo de .json
        File.WriteAllText(nomeArquivo, conteudo);

        // Configura o caminho do arquivo criado
        _caminhoArquivo = Path.GetFullPath(nomeArquivo);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        /* ARRANGE + ACT */
        // Realiza a leitura do arquivo e retorna uma lista de pets
        IEnumerable<Pet> listaDePets = new PetsJSON(_caminhoArquivo).RealizaLeitura();

        /* ASSERT */
        Assert.NotNull(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    // Remove o arquivo no final do teste
    public void Dispose() => File.Delete(_caminhoArquivo);
}
