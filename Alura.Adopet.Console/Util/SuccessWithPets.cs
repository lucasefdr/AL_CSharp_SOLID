using Alura.Adopet.Console.Modelos;
using FluentResults;

namespace Alura.Adopet.Console.Util;

public class SuccessWithPets(IEnumerable<Pet> data, string mensagem) : Success(mensagem)
{
    public IEnumerable<Pet> Data { get; } = data;
}
