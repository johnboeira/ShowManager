using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Features.Usuarios;

namespace ShowManager.Aplicacao.Features.Usuarios;

public class UsuarioService(UsuarioRepository _usuarioRepository) : IUsuarioService
{
    public async Task CriarAsync(Usuario usuario)
    {
        await _usuarioRepository.Adicionar(usuario, true);
    }

    public async Task<Usuario> BuscarPorIDAsync(int id)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(id);

        if (usuario is null)
        {
            //NotFound
            throw new Exception();
        }

        return usuario;
    }

    public async Task AtualizarAsync(Usuario usuarioEditado)
    {
        var usuarioDoBanco = await BuscarPorIDAsync(usuarioEditado.Id);

        usuarioDoBanco.AtualizarNome(usuarioEditado.Nome);

        await _usuarioRepository.SaveChangesAsync();
    }

    public async Task DeletarAsync(int id)
    {
        var registrosDeletados = await _usuarioRepository.DeleteAsync(id);

        if (registrosDeletados == 0)
        {
            //NotFound
            throw new Exception();
        }
    }
}