using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Usuarios;

public interface IUsuarioRepository : IRepositoryBase<Usuario>
{
    //Novo
    public Task<int> UpdateAsync(Usuario usuario);
}