using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Features.Usuarios;

public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ShowManagerContext _context) : base(_context)
    {
    }

    public async Task<int> UpdateAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}