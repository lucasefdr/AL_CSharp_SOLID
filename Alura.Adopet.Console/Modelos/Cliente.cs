namespace Alura.Adopet.Console.Modelos;

public class Cliente(Guid id, string nome, string email, string cpf)
{
    public Guid Id { get; set; } = id;
    public string Nome { get; set; } = nome;
    public string Email { get; set; } = email;
    public string? CPF { get; set; } = cpf;

    public override string ToString()
    {
        return $"{Id} - {Nome} - {Email} - {CPF}";
    }

}
