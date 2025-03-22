using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Dominio.Features.Shows;

public interface IShowRepository
{
    Task Adicionar(Show show, bool saveChanges = false);

    Task<Show?> BuscarPorIdAsync(int id);

    Task<IEnumerable<Show>> BuscarTodosAsync(int id);

    Task<int> DeleteAsync(int id);

    Task SaveChangesAsync();
}