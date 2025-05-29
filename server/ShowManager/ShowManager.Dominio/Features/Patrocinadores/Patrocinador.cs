using ShowManager.Dominio.Shared;

namespace ShowManager.Dominio.Features.Patrocinadores;

public class Patrocinador : Entidade
{
    public string Nome { get; set; } = string.Empty;

    public byte[] Logo { get; set; }
    public string SiteUrl { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}