using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Dominio.DTO;

public class UsuarioEditarDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}