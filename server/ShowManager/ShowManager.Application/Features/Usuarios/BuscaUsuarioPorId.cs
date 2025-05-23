using AutoMapper;
using MediatR;
using ShowManager.Contracts.DTOs.Features.Usuario;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Exceptions.Excecoes;

namespace ShowManager.Application.Features.Usuarios;

public class BuscaUsuarioPorId
{
    public class Query : IRequest<UsuarioDTO>
    {
        public int Id { get; set; }
    }

    public class Handler(IUsuarioRepository _usuarioRepository, IMapper _mapper) : IRequestHandler<Query, UsuarioDTO>
    {
        public async Task<UsuarioDTO> Handle(Query query, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.BuscarPorIdAsync(query.Id);

            if (usuario is null)
                throw new NaoEncontradoExcecao("Usuário não encontrado.");

            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}