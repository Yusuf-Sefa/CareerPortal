
namespace CareerPortal.Dtos.CompanyDtos;

public sealed record CompanyListItemDto(
    Guid Id,
    string Name,
    string? Location);