
namespace CareerPortal.Dtos.CompanyDtos;

public sealed record GetCompaniesRequest(
    string? Search,
    int Page = 1,
    int PageSize = 20
);