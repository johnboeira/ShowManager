using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Features.Shows;

public class ShowRepository : RepositoryBase<Show>, IShowRepository
{
    private readonly ShowManagerContext _context;

    public ShowRepository(ShowManagerContext context) : base(context)
    {
        _context = context;
    }
}