
using CareerPortal.Dtos.CompanyDtos;
using CareerPortal.Dtos.PagedDtos;

namespace CareerPortal.Services.Interface;

public interface ICompanyService
{
    Task<CompanyDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<CompanyListItemDto>> GetPagedAsync(GetCompaniesRequest request, CancellationToken ct = default);
    Task<CompanyDto> CreateAsync(CreateCompanyRequest request, CancellationToken ct = default);
    Task<CompanyDto?> UpdateAsync(Guid id, UpdateCompanyRequest request, CancellationToken ct = default);
}