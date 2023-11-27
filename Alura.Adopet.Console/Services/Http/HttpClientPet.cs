using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstractions;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services.Http;

public class HttpClientPet(HttpClient client) : IAPIService<Pet>
{
    private readonly HttpClient _client = client;

    public virtual async Task<HttpResponseMessage> CreateAsync<Pet>(Pet pet)
    {
        using (_ = new HttpResponseMessage())
        {
            return await _client.PostAsJsonAsync("pet/add", pet);
        }
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        var response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
