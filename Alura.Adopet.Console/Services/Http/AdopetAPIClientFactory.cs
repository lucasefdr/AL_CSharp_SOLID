using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Services.Http;

public class AdopetAPIClientFactory : IHttpClientFactory
{
    private readonly string _url = "http://localhost:5057";

    public HttpClient CreateClient(string name)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(_url);
        return _client;
    }
}
