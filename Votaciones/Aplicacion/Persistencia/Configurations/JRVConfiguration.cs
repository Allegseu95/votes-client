using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacion.Persistencia.Configurations;
public partial class JRVConfiguration : IEntityTypeConfiguration<JRV>
{
    public void Configure(EntityTypeBuilder<JRV> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .HasColumnName("JRVId")
            .IsRequired(true);

        entity.Property(e => e.Numero)
            .IsRequired(true);

        entity.Property(e => e.Genero)
            .HasMaxLength(20)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.DireccionRecinto)
            .HasMaxLength(300)
            .IsUnicode(true)
            .IsRequired(false);
        
        entity.Property(e => e.Recinto)
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.ZonaElectoral)
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(false);

        entity.Property(e => e.Parroquia)
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.TipoParroquia)
            .HasMaxLength(20)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Canton)
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Circunscripcion)
           .HasMaxLength(100)
           .IsUnicode(true)
           .IsRequired(false);

        entity.Property(e => e.Provincia)
           .HasMaxLength(100)
           .IsUnicode(true)
           .IsRequired(true);

        entity.Property(e => e.CantidadVotantes)
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

    partial void OnConfigurePartial(EntityTypeBuilder<JRV> entity);
}
