namespace ShowManager.Dominio.Features.Usuarios
{
    public interface IUsuarioService
    {
        Task CriarAsync(Usuario usuario);

        Task<Usuario> BuscarPorIDAsync(int id);

        Task AtualizarAsync(Usuario usuarioAtualizado);

        Task DeletarAsync(int id);
    }
}