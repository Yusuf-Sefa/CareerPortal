
using CareerPortal.Context;
using CareerPortal.Dtos.CompanyDtos;
using CareerPortal.Dtos.PagedDtos;
using CareerPortal.Repository.Interfaces.ICompany;

namespace CareerPortal.Repository.Queries;

internal class CompanyQueries : ICompanyQueries
{
    private readonly AppDbContext _context;

    public CompanyQueries(AppDbContext context) => _context = context;

    Task<CompanyDto?> ICompanyQueries.GetByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    Task<PagedResult<CompanyListItemDto>> ICompanyQueries.GetPagedAsync(string? search, int page, int pageSize, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}