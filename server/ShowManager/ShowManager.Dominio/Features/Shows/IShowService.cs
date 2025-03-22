namespace ShowManager.Dominio.Features.Shows;

public interface IShowService
{
    Task CriarAsync(Show show);

    Task<Show> BuscarPorIDAsync(int id);

    Task<IEnumerable<Show>> BuscarTodos();

    Task AtualizarAsync(Show showAtualizado);

    Task DeletarAsync(int id);
}