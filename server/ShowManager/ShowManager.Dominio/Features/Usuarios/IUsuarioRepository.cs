using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Usuarios;

public interface IUsuarioRepository : IRepositoryBase<Usuario>
{
    public Task<int> AtualizarAsync(Usuario usuario);
}