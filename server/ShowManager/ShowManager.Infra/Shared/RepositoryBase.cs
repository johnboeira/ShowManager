using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Shared;
using System.Linq.Expressions;

namespace ShowManager.Infra.Shared;

public class RepositoryBase<T> where T : Entidade
{
    protected DbSet<T> Query { get; set; }
    protected ShowManagerContext Context { get; set; }

    public RepositoryBase(ShowManagerContext context)
    {
        Context = context;
        Query = Context.Set<T>();
    }

    public async Task<T> BuscarPorId(int id)
    {
        return await Query.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetByIdsAsync(List<int> ids)
    {
        return await Query.Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Query.ToListAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await Query.AnyAsync(expression);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await Query.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}