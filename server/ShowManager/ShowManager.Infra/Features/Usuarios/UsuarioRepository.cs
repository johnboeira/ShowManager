using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Features.Usuarios;

public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ShowManagerContext context) : base(context)
    {
    }
}