namespace ShowManager.Dominio.Features.Usuarios;

public interface IUsuarioRepository
{
    Task Adicionar(Usuario usuario, bool saveChanges = false);

    Task<Usuario?> BuscarPorIdAsync(int id);

    Task<int> DeleteAsync(int id);

    Task SaveChangesAsync();
}