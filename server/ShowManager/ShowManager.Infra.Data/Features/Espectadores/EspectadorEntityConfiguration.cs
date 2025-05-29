using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Espectadores;

namespace ShowManager.Infra.Data.Features.Espectadores;

public class EspectadorEntityConfiguration : IEntityTypeConfiguration<Espectador>
{
    public void Configure(EntityTypeBuilder<Espectador> builder)
    {
        builder.ToTable("Espectadores");
        builder.HasKey(e => e.Id);

        // FK para Usuario
        builder.Property(e => e.UsuarioId)
            .IsRequired();

        builder.HasOne(e => e.Usuario)
            .WithMany()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK para Documento (Documento como entidade separada)
        builder.HasOne(e => e.Documento)
            .WithMany()
            .HasForeignKey("DocumentoId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}