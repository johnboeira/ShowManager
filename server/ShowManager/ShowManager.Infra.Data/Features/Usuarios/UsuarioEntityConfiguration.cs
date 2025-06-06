﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Infra.Data.Features.Usuarios;

public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Nome)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(o => o.Email)
           .HasMaxLength(200)
           .HasColumnType("nvarchar(200)")
           .IsRequired();

        builder.Property(o => o.Senha)
           .HasMaxLength(400)
           .HasColumnType("nvarchar(400)")
           .IsRequired();
    }
}