using ShowManager.Dominio.DTO;

namespace ShowManager.Dominio.Features.Usuarios
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>?> Buscar();

        Task<Usuario?> BuscarPorID(int id);

        Task<Usuario> Criar(UsuarioAdicionarDTO usuarioAdicionarDTO);

        Task<int> Deletar(int id);

        Task<Usuario> Atualizar(UsuarioEditarDTO usuarioEditarDTO);
    }
}