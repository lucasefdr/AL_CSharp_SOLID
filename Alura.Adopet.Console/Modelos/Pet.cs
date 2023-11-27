using Alura.Adopet.Console.Modelos.Enums;
namespace Alura.Adopet.Console.Modelos;

public class Pet(Guid id, string? nome, TipoPet tipo)
{
    public Guid Id { get; set; } = id;
    public string? Nome { get; set; } = nome;
    public TipoPet Tipo { get; set; } = tipo;

    public override string ToString()
    {
        return $"{Id} - {Nome} - {Tipo}";
    }
}
