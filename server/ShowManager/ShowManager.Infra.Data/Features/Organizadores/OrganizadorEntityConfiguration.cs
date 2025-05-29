using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Organizadores;

namespace ShowManager.Infra.Data.Features.Organizadores;

public class OrganizadorEntityConfiguration : IEntityTypeConfiguration<Organizador>
{
    public void Configure(EntityTypeBuilder<Organizador> builder)
    {
        builder.ToTable("Organizadores");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Apelido)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        // FK para Usuario
        builder.HasOne(o => o.Usuario)
            .WithMany()
            .HasForeignKey(o => o.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK para Documento
        builder.HasOne(o => o.Documento)
            .WithMany()
            .HasForeignKey("DocumentoId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Eventos
        builder.HasMany(o => o.ListaEventos)
            .WithOne(e => e.Organizador)
            .HasForeignKey(e => e.OrganizadorId);
    }
}