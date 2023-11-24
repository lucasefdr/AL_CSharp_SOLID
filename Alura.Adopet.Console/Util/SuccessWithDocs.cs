using FluentResults;

namespace Alura.Adopet.Console.Util;

public class SuccessWithDocs(IEnumerable<string> documentacao) : Success
{
    public IEnumerable<string> Documentacao { get; } = documentacao;
}
