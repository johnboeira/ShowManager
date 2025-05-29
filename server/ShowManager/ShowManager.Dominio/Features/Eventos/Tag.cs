using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Eventos;

public class Tag : Entidade
{
    public string Nome { get; set; }

    public ICollection<Evento> Eventos { get; set; }
}