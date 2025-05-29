using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Espectadores;

public class Espectador : Entidade
{
    public Documento Documento { get; private set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
}