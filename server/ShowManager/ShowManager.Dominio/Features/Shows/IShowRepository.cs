using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Shows;

public interface IShowRepository : IRepositoryBase<Show>
{
    public Task<int> UpdateAsync(Show show);
}