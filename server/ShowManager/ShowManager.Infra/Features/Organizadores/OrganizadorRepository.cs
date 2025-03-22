using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Features.Organizadores;

public class OrganizadorRepository : RepositoryBase<Organizador>, IOrganizadorRepository
{
    public OrganizadorRepository(ShowManagerContext context) : base(context)
    {
    }

    public async Task<int> UpdateAsync(Organizador organizador)
    {
        return await Context.Organizadores.ExecuteUpdateAsync(x =>
            x.SetProperty(o => o.Apelido, organizador.Apelido)
        );
    }
}