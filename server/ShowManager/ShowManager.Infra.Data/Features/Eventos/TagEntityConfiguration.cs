using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Eventos;

namespace ShowManager.Infra.Data.Features.Eventos;

public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome)
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)")
            .IsRequired();
    }
}