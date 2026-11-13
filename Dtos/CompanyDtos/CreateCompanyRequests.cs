
namespace CareerPortal.Dtos.CompanyDtos;

public sealed record CreateCompanyRequest(
    string Name,
    string? Location,
    string? Description
);