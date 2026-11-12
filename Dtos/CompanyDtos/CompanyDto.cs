
namespace CareerPortal.Dtos.CompanyDtos;

public sealed record CompanyDto(
    Guid Id,
    string Name,
    string? Location,
    string? Description,
    int RecruiterCount,
    int ActiveJobPostingCount
);