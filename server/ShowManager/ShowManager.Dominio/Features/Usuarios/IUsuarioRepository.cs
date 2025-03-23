using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Usuarios;

public interface IUsuarioRepository : IRepositoryBase<Usuario>
{
    //Novo
    public Task AtualizarAsync(Usuario usuario);
}