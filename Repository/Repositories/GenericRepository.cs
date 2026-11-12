
using CareerPortal.Context;
using CareerPortal.Repository.Interfaces;

namespace CareerPortal.Repository.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext Context;

    public GenericRepository(AppDbContext context) => Context = context;

    public void Add(T entity)
        => Context.Set<T>().Add(entity);

    public void AddRange(IEnumerable<T> entities)
        => Context.Set<T>().AddRange(entities);

    public void Remove(T entity)
        => Context.Set<T>().Remove(entity);

    public Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
        => Context.Set<T>().FindAsync(new object[] {id}, ct).AsTask();

}