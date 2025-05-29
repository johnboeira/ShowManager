using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Shows;
using System.Reflection.Emit;

namespace ShowManager.Infra.Data.Features.Shows;

internal class EventoEntityConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.ToTable("Eventos");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Nome)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(o => o.DataInicio)
            .HasDefaultValue(new DateTime(2000, 1, 1))
            .HasColumnType("datetime2(0)")
            .IsRequired(false);

        builder.Property(o => o.DataFim)
            .HasDefaultValue(new DateTime(2000, 1, 1))
            .HasColumnType("datetime2(0)")
            .IsRequired(false);

        builder.Property(o => o.PrecoIngresso)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(o => o.NumeroParticipantes)
            .HasDefaultValue(0)
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(o => o.UrlImagemPoster)
            .HasColumnType("varbinary(max)")
            .IsRequired();

        builder.Property(o => o.Classificacao)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(o => o.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(o => o.DataCriacao)
            .HasColumnType("datetime2(0)")
            .IsRequired();

        builder.Property(o => o.DataUltimaModificacao)
            .HasColumnType("datetime2(0)")
            .IsRequired(false);

        // Relacionamento com Organizador
        builder.Property(o => o.OrganizadorId)
            .IsRequired();

        builder.HasOne(o => o.Organizador)
            .WithMany(o => o.ListaEventos)
            .HasForeignKey(o => o.OrganizadorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento muitos-para-muitos com Tags
        builder.HasMany(e => e.Tags)
            .WithMany(t => t.Eventos)
            .UsingEntity(j => j.ToTable("EventoTags"));

        builder.Ignore(o => o.Duracao);
    }
}