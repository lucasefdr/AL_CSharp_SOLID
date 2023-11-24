using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.UI;
using FluentResults;

var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
var leitorDeArquivo = args.Length == 2 ? new LeitorDeArquivo(args[1]) : null;

var comandosDoSistema = new Dictionary<string, IComando>()
{
    {"help", new Help()},
    {"import", new Import(httpClientPet, leitorDeArquivo!)},
    {"show", new Show(leitorDeArquivo)},
    {"list", new List(httpClientPet)}
};


var comando = args[0].Trim();

if (!comandosDoSistema.ContainsKey(comando)) ConsoleUI.ExibeResultado(Result.Fail($"O comando {comando} não é válido."));

var comandoDeEntrada = comandosDoSistema[comando];
var resultado = await comandoDeEntrada.ExecutarAsync(args);
ConsoleUI.ExibeResultado(resultado);

