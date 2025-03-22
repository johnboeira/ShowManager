using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Features.Shows;

public class ShowRepository(ShowManagerContext _context) : IShowRepository
{
    public async Task Adicionar(Show show, bool saveChanges = false)
    {
        await _context.Shows.AddAsync(show);

        if (saveChanges)
        {
            await SaveChangesAsync();
        }
    }

    public async Task<Show?> BuscarPorIdAsync(int id)
    {
        return await _context.Shows.SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Show>> BuscarTodosAsync(int id)
    {
        return await _context.Shows.ToListAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _context.Shows.Where(x => x.Id == id)
          .ExecuteDeleteAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}