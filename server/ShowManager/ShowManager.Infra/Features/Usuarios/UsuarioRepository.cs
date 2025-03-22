using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Features.Usuarios;

public class UsuarioRepository(ShowManagerContext _context) : IUsuarioRepository
{
    public async Task Adicionar(Usuario usuario, bool saveChanges = false)
    {
        await _context.Usuarios.AddAsync(usuario);

        if (saveChanges)
        {
            await SaveChangesAsync();
        }
    }

    public async Task<Usuario?> BuscarPorIdAsync(int id)
    {
        return await _context.Usuarios.SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _context.Usuarios.Where(x => x.Id == id)
          .ExecuteDeleteAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}