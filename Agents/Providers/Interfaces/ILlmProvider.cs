
namespace CareerPortal.Agents.Providers.Interfaces;

public interface ILlmProvider
{
    string ProviderName {get;}
    Task<string> GenerateCvTextAsync(string systemPrompt, string userPrompt, CancellationToken cancellationToken = default);
}