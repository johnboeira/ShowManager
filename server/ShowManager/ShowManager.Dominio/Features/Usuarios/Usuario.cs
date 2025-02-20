using ShowManager.Dominio.Features.Shared;

namespace ShowManager.Dominio.Features.Usuarios;

public class Usuario : Entidade
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public TipoUsuarioEnum TipoUsuarioEnum { get; set; }
}