using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Shared;
using System.Linq.Expressions;

namespace ShowManager.Infra.Shared;

public class RepositoryBase<T> : IRepository<T> where T : Entidade
{
    protected DbSet<T> Query { get; set; }
    protected DbContext Context { get; set; }

    public RepositoryBase(ShowManagerContext context)
    {
        Context = context;
        Query = Context.Set<T>();
    }

    public async Task<T> SaveAsync(T entity)
    {
        var obj = await Query.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
        if (obj != null)
        {
            Context.Entry(obj).CurrentValues.SetValues(entity);
        }
        else
        {
            await Query.AddAsync(entity);
        }
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var obj = await Query.FindAsync(id);
        if (obj != null)
        {
            Query.Remove(obj);
            await Context.SaveChangesAsync();
        }
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Query.FindAsync(id);
    }

    public async Task<IEnumerable<T>?> GetByIdsAsync(List<int> ids)
    {
        return await Query.Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await Query.ToListAsync();
    }

    public async Task<IEnumerable<T>?> FindAllByCriterioAsync(Expression<Func<T, bool>> expression)
    {
        return await Query.Where(expression).ToListAsync();
    }

    public async Task<T?> FindOneByCriterioAsync(Expression<Func<T, bool>> expression)
    {
        return await Query.Where(expression).FirstOrDefaultAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await Query.AnyAsync(expression);
    }
}