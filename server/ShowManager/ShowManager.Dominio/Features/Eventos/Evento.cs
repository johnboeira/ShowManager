using ShowManager.Dominio.Features.Eventos;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Shows;

public class Evento : Entidade
{
    public string Nome { get; set; } = string.Empty;
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public decimal PrecoIngresso { get; set; }
    public int? NumeroParticipantes { get; set; }
    public TimeSpan? Duracao { get; set; }

    public byte[] UrlImagemPoster { get; set; }
    public ICollection<Tag> Tags { get; set; }

    public ClassificacaoIndicativa Classificacao { get; set; }
    public StatusShow Status { get; set; }

    public int OrganizadorId { get; set; }
    public Organizador Organizador { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime? DataUltimaModificacao { get; set; }
}

public enum GeneroShow
{ Musica, Teatro, StandUp, Infantil, Outros }

public enum StatusShow
{ Agendado, EmAndamento, Concluido, Cancelado }

public enum ClassificacaoIndicativa
{ Livre, Dezesseis, Dezoito }