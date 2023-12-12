using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Services.Http;

public class AdopetAPIClientFactory(string url) : IHttpClientFactory
{

    public HttpClient CreateClient(string name)
    {
        HttpClient _client = new();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}
