
namespace CareerPortal.Dtos.AgentDtos;

public sealed record ParsedCvDto(
    string FullName,
    string Title,
    string Summary,
    IReadOnlyList<string> Skills
);