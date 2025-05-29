using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Shared;

namespace ShowManager.Infra.Data.Features.Shared;

public class DocumentoEntityConfiguration : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.ToTable("Documentos");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.ValorIdentidade)
            .HasMaxLength(20)
            .HasColumnType("nvarchar(20)")
            .IsRequired();

        builder.Property(d => d.NomeCompleto)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(d => d.Tipo)
            .HasConversion<int>()
            .IsRequired();
    }
}