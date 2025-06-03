using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Data.Features.Usuarios;

public class UsuarioRepository(ShowManagerContext _context) : RepositoryBase<Usuario>(_context), IUsuarioRepository
{
    public async Task<int> AtualizarAsync(Usuario usuario)
    {
        return await _context.Usuarios
            .Where(u => u.Id == usuario.Id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(u => u.Nome, u => usuario.Nome)
                .SetProperty(u => u.Email, u => usuario.Email)
                .SetProperty(u => u.Senha, u => usuario.Senha));
    }
}