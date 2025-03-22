using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Organizadores;

public interface IOrganizadorRepository
{
    public Task<int> UpdateAsync(Organizador organizador);
}