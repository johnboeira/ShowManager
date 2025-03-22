using System.Linq.Expressions;

namespace ShowManager.Dominio.Features.Shared
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetByIdsAsync(List<int> ids);

        Task<IEnumerable<T>> GetAllAsync();

        Task<int> DeleteAsync(int id);

        Task SaveChangesAsync();

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}