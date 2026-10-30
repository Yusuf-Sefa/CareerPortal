
using CareerPortal.Dtos.AgentDtos;

namespace CareerPortal.Agents.ConcreteAgents;

public interface ICvParserAgent
{
    Task<ParsedCvDto> ParseCvAsync(string rawCvText, CancellationToken cancellationToken = default);
}