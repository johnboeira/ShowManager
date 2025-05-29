using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Shows;

public interface IEventoRepository : IRepositoryBase<Evento>
{
    public Task<int> UpdateAsync(Evento show);
}