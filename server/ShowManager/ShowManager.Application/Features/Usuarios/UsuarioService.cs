//using ShowManager.Dominio.Features.Usuarios;
//using ShowManager.Exceptions.Excecoes;
//using ShowManager.Infra.Data.Features.Usuarios;

//namespace ShowManager.Aplicacao.Features.Usuarios;

//public class UsuarioService : IUsuarioService
//{
//    private readonly UsuarioRepository _usuarioRepository;

//    public UsuarioService(UsuarioRepository usuarioRepository)
//    {
//        _usuarioRepository = usuarioRepository;
//    }

//    public async Task CriarAsync(Usuario usuario)
//    {
//        await _usuarioRepository.Adicionar(usuario, true);
//    }

//    public async Task<Usuario> BuscarPorIDAsync(int id)
//    {
//        var usuario = await _usuarioRepository.BuscarPorIdAsync(id);

//        if (usuario is null)
//        {
//            //NotFound
//            throw new Exception();
//        }

//        return usuario;
//    }

//    public async Task AtualizarAsync(Usuario usuarioEditado)
//    {
//        var usuarioDoBanco = await BuscarPorIDAsync(usuarioEditado.Id);

//        if (usuarioDoBanco is null)
//        {
//            throw new NaoEncontradoExcecao($"Usuário não encontrado, id: {usuarioEditado.Id}");
//        }

//        usuarioDoBanco.AtualizarNome(usuarioEditado.Nome);

//        await _usuarioRepository.SaveChangesAsync();
//    }

//    public async Task DeletarAsync(int id)
//    {
//        var registrosDeletados = await _usuarioRepository.DeleteAsync(id);

//        if (registrosDeletados == 0)
//        {
//            //NotFound
//            throw new Exception();
//        }
//    }
//}