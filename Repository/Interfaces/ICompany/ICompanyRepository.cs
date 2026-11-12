
using CareerPortal.Models;

namespace CareerPortal.Repository.Interfaces.ICompany;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<Company?> GetByNameAsync(string name, CancellationToken ct = default);
    Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default);
}