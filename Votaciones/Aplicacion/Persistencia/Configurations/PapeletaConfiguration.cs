using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacion.Persistencia.Configurations;
public partial class PapeletaConfiguration : IEntityTypeConfiguration<Papeleta>
{
    public void Configure(EntityTypeBuilder<Papeleta> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .HasColumnName("PapeletaId")
            .IsRequired(true);

        entity.Property(e => e.Codigo)
            .HasMaxLength(60)
            .IsUnicode(true)
            .IsRequired(true);
        
        entity.Property(e => e.Dignidad)
            .HasMaxLength(200)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.FechaEleccion)
            .HasColumnType("date")
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

    partial void OnConfigurePartial(EntityTypeBuilder<Papeleta> entity);
}
