using ShowManager.Dominio.Features.Organizadores;

namespace ShowManager.Infra.Features.Organizadores;

public class OrganizadorRepository : RepositoryBase<Organizador>, IOrganizadorRepository
{
    public OrganizadorRepository(ShowManagerContext context) : base(context)
    {
    }
}