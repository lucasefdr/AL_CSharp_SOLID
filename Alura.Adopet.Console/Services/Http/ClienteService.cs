using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services;

public class ClienteService(HttpClient client) : IAPIService<Cliente>
{
    public Task<HttpResponseMessage> CreateAsync<Cliente>(Cliente cliente)
        => client.PostAsJsonAsync("proprietario/add", cliente);


    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("proprietario/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
    }
}
