using MediatR;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Application.Features.Usuarios;

public class UsuarioCriarCommand : IRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public TipoUsuarioEnum TipoUsuarioEnum { get; set; }
}