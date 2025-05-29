using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Data.Features.Shows;

public class EventoRepository : RepositoryBase<Evento>
{
    private readonly ShowManagerContext _context;

    public EventoRepository(ShowManagerContext context) : base(context)
    {
        _context = context;
    }
}