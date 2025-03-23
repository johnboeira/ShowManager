using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Infra.Features.Organizadores;

namespace ShowManager.Aplicacao.Features.Organizadores;

public class OrganizadorService : IOrganizadorService
{
    private readonly OrganizadorRepository _organizadoresRepository;

    public OrganizadorService(OrganizadorRepository organizadoresRepository)
    {
        _organizadoresRepository = organizadoresRepository;
    }

    public async Task AtualizarAsync(Organizador organizadorAtualizado)
    {
        var registrosAtualizados = await _organizadoresRepository.AtualizarAsync(organizadorAtualizado);

        if (registrosAtualizados == 0)
        {
            //NotFound
            throw new Exception();
        }
    }
}