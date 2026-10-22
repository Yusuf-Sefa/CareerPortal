
using CareerPortal.Agents.Providers.Interfaces;

namespace CareerPortal.Agents.Factory;

public class LlmProviderFactory : ILlmProviderFactory
{
    private readonly IEnumerable<ILlmProvider> _providers;  
    private readonly IConfiguration _configuration;

    public LlmProviderFactory(IEnumerable<ILlmProvider> providers, IConfiguration configuration)
    {
        _providers = providers;
        _configuration = configuration;
    }

    public ILlmProvider GetProvider(string? providerName = null)
    {
        providerName ??= _configuration["LlmSettings:ActiveProvider"] ?? "OpenAI";

        var provider = _providers.FirstOrDefault(p => 
            p.ProviderName.Equals(providerName, StringComparison.OrdinalIgnoreCase));

        return provider
            ?? throw new InvalidOperationException($"LLM Provider '{providerName}' bulunamadı.");
    }
}