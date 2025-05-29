using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Patrocinadores;

namespace ShowManager.Infra.Data.Features.Patrocinadores;

public class PatrocinadorEntityConfiguration : IEntityTypeConfiguration<Patrocinador>
{
    public void Configure(EntityTypeBuilder<Patrocinador> builder)
    {
        builder.ToTable("Patrocinadores");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(p => p.Logo)
            .HasColumnType("varbinary(max)")
            .IsRequired();

        builder.Property(p => p.SiteUrl)
            .HasMaxLength(300)
            .HasColumnType("nvarchar(300)")
            .IsRequired();

        builder.Property(p => p.Descricao)
            .HasMaxLength(1000)
            .HasColumnType("nvarchar(1000)")
            .IsRequired();
    }
}