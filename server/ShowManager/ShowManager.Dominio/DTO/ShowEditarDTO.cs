using ShowManager.Dominio.Features.Organizadores;

namespace ShowManager.Dominio.DTO
{
    public class ShowEditarDTO
    {
        public string NomeShow { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? NumeroParticipantes { get; set; }
        public TimeSpan? Duracao { get; set; }
        public int OrganizadorId { get; set; }
        public Organizador Organizador { get; set; }
    }
}