using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


public class ChatGPTService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public ChatGPTService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OpenAI:ApiKey"];
    }

    public async Task<string> GetResponseAsync(string prompt)
    {
        var requestBody = new
        {
            model = "gpt-4o", // or the specific model you are using
            prompt = prompt,
            max_tokens = 150
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        request.Content = JsonContent.Create(requestBody);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
        return responseBody.GetProperty("choices")[0].GetProperty("text").GetString();
    }
}