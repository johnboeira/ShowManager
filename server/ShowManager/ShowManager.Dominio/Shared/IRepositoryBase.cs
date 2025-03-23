using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Shared;

public interface IRepositoryBase<T> where T : Entidade
{
    Task Adicionar(T entidade, bool saveChanges = false);

    Task<T?> BuscarPorIdAsync(int id);

    Task<int> DeleteAsync(int id);

    Task SaveChangesAsync();
}