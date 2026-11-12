
using CareerPortal.Dtos.CompanyDtos;
using CareerPortal.Dtos.PagedDtos;

namespace CareerPortal.Repository.Interfaces.ICompany;

public interface ICompanyQueries
{
    Task<CompanyDto?> GetByIdAsync(Guid id, CancellationToken ct = default);

    Task<PagedResult<CompanyListItemDto>> GetPagedAsync(string? search, int page, int pageSize, CancellationToken ct = default);
    
}