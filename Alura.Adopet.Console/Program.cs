using Alura.Adopet.Console;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    var comando = args[0].Trim();
    switch (comando)
    {
        case "import":
            var import = new Import();
            await import.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
            break;
        case "help":
            var entrada = args;
            var help = new Help();
            help.ExibeInformacoesDeAjuda(entrada);
            break;
        case "show":
            var show = new Show();
            var caminhoDoArquivoASerExibido = args[1];
            show.ExibeConteudoDoArquivo(caminhoDoArquivoASerExibido);
            break;
        case "list":
            var list = new List();
            await list.ListaPetsAsync();
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}