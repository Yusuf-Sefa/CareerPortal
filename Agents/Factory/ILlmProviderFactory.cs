
using CareerPortal.Agents.Providers.Interfaces;

namespace CareerPortal.Agents.Factory;

public interface ILlmProviderFactory
{
    ILlmProvider GetProvider(string? providerName = null);
}