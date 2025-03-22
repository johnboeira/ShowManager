using ShowManager.Dominio.DTO;

namespace ShowManager.Dominio.Features.Shows;

public interface IShowService
{
    Task<Show> Criar(ShowAdicionarDTO showAdicionarDTO);

    Task<int> Deletar(int id);

    Task<Show> Atualizar(ShowEditarDTO showEditarDTO, int id);

    Task<IEnumerable<Show>?> Buscar();

    Task<Show?> BuscarPorID(int id);
}