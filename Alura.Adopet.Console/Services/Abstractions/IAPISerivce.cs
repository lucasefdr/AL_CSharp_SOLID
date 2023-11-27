namespace Alura.Adopet.Console.Services.Abstractions;

public interface IAPISerivce
{
    Task<HttpResponseMessage> CreatePetAsync(Pet pet);
    Task<IEnumerable<Pet>?> ListPetsAsync();
}
