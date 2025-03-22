using System.Linq.Expressions;

namespace ShowManager.Dominio.Features.Shared
{
    public interface IRepository<T> where T : class
    {
        Task<T> SaveAsync(T entity);

        Task DeleteAsync(int id);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>?> GetByIdsAsync(List<int> ids);

        Task<IEnumerable<T>?> GetAllAsync();

        Task<IEnumerable<T>?> FindAllByCriterioAsync(Expression<Func<T, bool>> expression);

        Task<T?> FindOneByCriterioAsync(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}