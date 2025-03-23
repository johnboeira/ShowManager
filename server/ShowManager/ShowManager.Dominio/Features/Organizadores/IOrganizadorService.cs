using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Dominio.Features.Organizadores;

public interface IOrganizadorService
{
    Task CriarAsync(Organizador organizador);

    Task<Show> BuscarPorIDAsync(int id);

    Task<IEnumerable<Organizador>> BuscarTodos();

    Task AtualizarAsync(Organizador organizadorAtualizado);

    Task DeletarAsync(int id);
}