
using System.Text.Json;
using CareerPortal.Agents.Providers.Interfaces;

namespace CareerPortal.Agents.Providers;

public class OpenAiProvider : ILlmProvider
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public string ProviderName => "OpenAi";

    public OpenAiProvider(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        var apiKey = _configuration["LlmSettings:OpenAi:ApiKey"];
        _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> GenerateCvTextAsync(string systemPrompt, string userPrompt, CancellationToken cancellationToken = default)
    {
        var model = _configuration["LlmSettings:OpenAi:Model"] ?? "gpt-4o-mini";

        var requestBody = new
        {
            model = model,
            messages = new[]
            {
                new { role = "system", content = systemPrompt },
                new { role = "user", content = userPrompt }
            },
            temperature = 0.3
        };

        var response = await _httpClient.PostAsJsonAsync("chat/completions", requestBody, cancellationToken);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken: cancellationToken);
        var content = jsonResponse.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

        return content ?? string.Empty;
    }

}