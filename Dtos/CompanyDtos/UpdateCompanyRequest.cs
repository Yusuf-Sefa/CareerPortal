
namespace CareerPortal.Dtos.CompanyDtos;

public sealed record UpdateCompanyRequest(
    string Name,
    string? Location,
    string? Description
);