using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Apresentadores;

namespace ShowManager.Infra.Data.Features.Apresentadores;

public class ApresentadorEntityConfiguration : IEntityTypeConfiguration<Apresentador>
{
    public void Configure(EntityTypeBuilder<Apresentador> builder)
    {
        builder.ToTable("Apresentadores");
        builder.HasKey(a => a.Id);

        // FK para Usuario
        builder.Property(a => a.UsuarioId)
            .IsRequired();

        builder.HasOne(a => a.Usuario)
            .WithMany()
            .HasForeignKey(a => a.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK para Documento (Documento como entidade separada)
        builder.HasOne(a => a.Documento)
            .WithMany()
            .HasForeignKey("DocumentoId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}