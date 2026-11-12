
using CareerPortal.Context;
using CareerPortal.Models;
using CareerPortal.Repository.Interfaces.ICompany;
using Microsoft.EntityFrameworkCore;

namespace CareerPortal.Repository.Repositories;

internal class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context) {}


    Task<Company?> ICompanyRepository.GetByNameAsync(string name, CancellationToken ct)
        => Context.Companies.FirstOrDefaultAsync(c => c.Name == name, ct);
    
    Task<bool> ICompanyRepository.ExistsByNameAsync(string name, CancellationToken ct)
        => Context.Companies.AsNoTracking().AnyAsync(c => c.Name == name, ct);

}