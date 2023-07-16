using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacion.Persistencia.Configurations;
public partial class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .HasColumnName("UsuarioId")
            .IsRequired(true);

        entity.Property(e => e.Nombre)
            .HasMaxLength(60)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Apellido)
            .HasMaxLength(60)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Genero)
            .HasMaxLength(20)
            .IsUnicode(true)
            .IsRequired(false);

        entity.Property(e => e.Cedula)
            .HasMaxLength(10)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Email)
           .HasMaxLength(300)
           .IsUnicode(true)
           .IsRequired(true);

        entity.Property(e => e.Creado)
           .HasColumnType("datetime2")
           .IsRequired(true);

        entity.Property(e => e.Modificado)
            .HasColumnType("datetime2")
            .IsRequired(true);

        entity.Property(e => e.CreadoPor)
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.ModificadoPor)
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(false);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Usuario> entity);

}
