using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Features.Shows;

public class ShowRepository : RepositoryBase<Show>, IShowRepository
{
    public ShowRepository(ShowManagerContext context) : base(context)
    {
    }
}