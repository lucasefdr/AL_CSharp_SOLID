using Alura.Adopet.Console.Modelos;
using FluentResults;

namespace Alura.Adopet.Console.Util;

public class SuccessWithClientes(IEnumerable<Cliente> data, string mensagem) : Success(message: mensagem)
{
    public IEnumerable<Cliente> Data { get; } = data;
}
