using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services;

public class HttpClientPet
{
    private readonly HttpClient client;

    public HttpClientPet(string uri = "http://localhost:5057")
    {
        client = ConfiguraHttpClient(uri);
    }

    public HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }

    public async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return await client.PostAsJsonAsync("pet/add", pet);

        }
    }

    public async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
