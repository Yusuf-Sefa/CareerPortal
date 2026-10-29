
using System.Text.Json;
using CareerPortal.Agents.Factory;
using CareerPortal.Dtos.AgentDtos;

namespace CareerPortal.Agents.ConcreteAgents;

public class CvParserAgent : ICvParserAgent
{
    private readonly ILlmProviderFactory _llmFactory;

    public CvParserAgent(ILlmProviderFactory llmFactory)
    {
        _llmFactory = llmFactory;
    }

    public async Task<ParsedCvDto> ParseCvAsync(string rawCvText, CancellationToken cancellationToken)
    {
        var llmProvider = _llmFactory.GetProvider();

        string systemPrompt = @"
            Sen uzman bir CV analiz ajanısın. Sana verilen ham CV metnini analiz et ve şu JSON formatında yanıt ver:
            {
               ""fullName"": ""string"",
               ""title"": ""string"",
               ""summary"": ""string"",
               ""skills"": [""string""]
            }
            Sadece saf JSON döndür, markdown blokları veya ekstra açıklama ekleme.";

        string userPrompt = $"Analiz edilecek ham CV metni:\n{rawCvText}";

        var jsonResponse = await llmProvider.GenerateCvTextAsync(systemPrompt, userPrompt, cancellationToken);

        return JsonSerializer.Deserialize<ParsedCvDto>(jsonResponse, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new ParsedCvDto();

    }

}