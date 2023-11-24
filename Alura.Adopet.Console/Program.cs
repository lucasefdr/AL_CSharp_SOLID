using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.UI;
using FluentResults;

// Utiliza o factory para criar o comando
var comando = ComandosFactory.Create(args);

// Executa o comando
if (comando is not null)
{
    var resultado = await comando.ExecutarAsync();

    // Exibe o resultado
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando não encontrado!"));
}