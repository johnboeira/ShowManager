using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Features.Usuarios;

namespace ShowManager.Aplicacao.Features.Usuarios;

public class UsuarioService : IUsuarioService
{
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        this._usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> Atualizar(UsuarioEditarDTO usuarioEditarDTO)
    {
        var usuario = _usuarioRepository.GetByIdsAsync(usuarioEditarDTO.Id);

        usuario.Atualizar(usuarioEditarDTO);

        await _usuarioRepository.SaveChangesAsync();
        return usuarioAtualizado;
    }

    public async Task<IEnumerable<Usuario>?> Buscar()
    {
        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<Usuario?> BuscarPorID(int id)
    {
        return await _usuarioRepository.GetByIdAsync(id);
    }

    public async Task<Usuario> Criar(UsuarioAdicionarDTO usuarioAdicionarDTO)
    {
        var usuario = new Usuario
        {
            Nome = usuarioAdicionarDTO.Nome,
            Email = usuarioAdicionarDTO.Email,
            Senha = usuarioAdicionarDTO.Senha,
            TipoUsuarioEnum = usuarioAdicionarDTO.TipoUsuarioEnum
        };
        return await _usuarioRepository.SaveAsync(usuario);
    }

    public async Task<int> Deletar(int id)
    {
        await _usuarioRepository.DeleteAsync(id);
        return id;
    }
}