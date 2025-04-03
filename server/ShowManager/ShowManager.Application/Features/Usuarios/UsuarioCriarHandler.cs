using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Features.Usuarios;

namespace ShowManager.Application.Features.Usuarios;

public class UsuarioCriarHandler(UsuarioRepository _usuarioRepository, IMapper mapper) : IRequestHandler<UsuarioCriarCommand, Unit>
{
    public async Task<Unit> Handle(UsuarioCriarCommand command, CancellationToken cancellationToken)
    {
        var usuario = mapper.Map<Usuario>(command);

        await _usuarioRepository.Adicionar(usuario, true);

        return await Unit.Task;
    }
}