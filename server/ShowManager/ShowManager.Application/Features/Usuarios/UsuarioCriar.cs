using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Features.Usuarios;

namespace ShowManager.Application.Features.Usuarios;

public class UsuarioCriar
{
    public class Command : IRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class Handler(IUsuarioRepository _usuarioRepository, IMapper mapper) : IRequestHandler<Command, Unit>
    {
        public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
        {
            var usuario = mapper.Map<Usuario>(command);

            await _usuarioRepository.Adicionar(usuario, true);

            return await Unit.Task;
        }
    }
}