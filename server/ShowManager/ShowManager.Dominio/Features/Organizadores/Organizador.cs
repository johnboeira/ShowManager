using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Organizadores;

public class Organizador : Entidade
{
    public string Apelido { get; private set; }
    public List<Evento> ListaEventos { get; private set; }
    public Documento Documento { get; private set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
}