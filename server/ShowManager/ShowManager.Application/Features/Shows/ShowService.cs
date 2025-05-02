using ShowManager.Dominio.Features.Shows;
using ShowManager.Infra.Features.Shows;

namespace ShowManager.Aplicacao.Features.Shows;

public class ShowService(ShowRepository _showRepository)
{
    public async Task CriarAsync(Show show)
    {
        await _showRepository.Adicionar(show, true);
    }

    public async Task<Show> BuscarPorIDAsync(int id)
    {
        var show = await _showRepository.BuscarPorIdAsync(id);

        if (show is null)
        {
            //NotFound
            throw new Exception();
        }

        return show;
    }

    public async Task DeletarAsync(int id)
    {
        var registrosDeletados = await _showRepository.DeleteAsync(id);

        if (registrosDeletados == 0)
        {
            //NotFound
            throw new Exception();
        }
    }
}