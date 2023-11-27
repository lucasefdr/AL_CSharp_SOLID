namespace Alura.Adopet.Console.Services.Abstractions;

public interface IAPIService<T> where T : class
{
    Task<HttpResponseMessage> CreateAsync<T>(T obj);
    Task<IEnumerable<T>?> ListAsync();
}
