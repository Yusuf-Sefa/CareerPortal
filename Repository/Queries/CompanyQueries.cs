
using CareerPortal.Context;
using CareerPortal.Dtos.CompanyDtos;
using CareerPortal.Dtos.PagedDtos;
using CareerPortal.Mapping;
using CareerPortal.Repository.Interfaces.ICompany;
using Microsoft.EntityFrameworkCore;

namespace CareerPortal.Repository.Queries;

internal class CompanyQueries : ICompanyQueries
{
    private readonly AppDbContext _context;

    public CompanyQueries(AppDbContext context) => _context = context;

    public Task<CompanyDto?> GetByIdAsync(Guid id, CancellationToken ct)
        => _context.Companies
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new CompanyDto(
                    c.Id,
                    c.Name,
                    c.Location,
                    c.Description,
                    c.RecruiterProfiles.Count,
                    c.JobPostings.Count(j => j.IsActive)    
                ))
            .FirstOrDefaultAsync(ct);

    public async Task<PagedResult<CompanyListItemDto>> GetPagedAsync(string? search, int page, int pageSize, CancellationToken ct)
    {
        var query = _context.Companies.AsNoTracking();

        if(!string.IsNullOrWhiteSpace(search))
            query = query.Where(c => EF.Functions.ILike(c.Name, $"%{search}%"));

        var totalCount = await query.CountAsync(ct);

        var items = await query
            .OrderBy(c => c.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectToListItemDto()
            .ToListAsync(ct);

        return new PagedResult<CompanyListItemDto>(items, page, pageSize, totalCount);
    }
}