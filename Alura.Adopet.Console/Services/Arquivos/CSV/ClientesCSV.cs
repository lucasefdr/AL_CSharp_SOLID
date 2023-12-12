using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Modelos.Enums;

namespace Alura.Adopet.Console.Services.Arquivos.CSV;

public class ClientesCSV(string? caminhoDoArquivo) : LeitorDeArquivosCSV<Cliente>(caminhoDoArquivo)
{
    public override Cliente CriarDaLinhaCSV(string linha)
    {
        var propriedades = linha.Split(';');

        return new Cliente(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            email: propriedades[2],
            cpf: propriedades[3]);
    }
}
