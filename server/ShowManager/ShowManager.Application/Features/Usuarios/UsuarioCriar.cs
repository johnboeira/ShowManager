using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Criptografia;

namespace ShowManager.Application.Features.Usuarios;

public class UsuarioCriar
{
    public class Command : IRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class Handler(IUsuarioRepository _usuarioRepository, IMapper _mapper, SenhaEncriptador _senhaEncriptador) : IRequestHandler<Command, Unit>
    {
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(command);

            var senhaCriptografada = _senhaEncriptador.Encriptar(usuario.Senha);

            usuario.DefinirSenha(senhaCriptografada);

            await _usuarioRepository.Adicionar(usuario, true);

            return await Unit.Task;
        }
    }
}