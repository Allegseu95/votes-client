using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacion.Persistencia.Configurations;
public partial class JRVPapeletaConfiguration : IEntityTypeConfiguration<JRVPapeleta>
{
    public void Configure(EntityTypeBuilder<JRVPapeleta> entity)
    {
        entity.ToTable("JRVs_Papeletas");

        entity.HasKey(e => new { e.JRVId, e.PapeletaId});

        entity.Property(e => e.JRVId)
            .IsRequired(true);

        entity.Property(e => e.PapeletaId)
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

        entity.HasOne<JRV>(e=>e.JRV)
            .WithMany(e=>e.JRVPapeletas)
            .HasForeignKey(e=>e.JRVId)
            .HasConstraintName("FK_JRVs_PapeletasJRVs")
            .OnDelete(DeleteBehavior.Restrict);
        
        entity.HasOne<Papeleta>(e=>e.Papeleta)
            .WithMany(e=>e.JRVPapeletas)
            .HasForeignKey(e=>e.PapeletaId)
            .HasConstraintName("FK_JRVs_PapeletasPapeletas")
            .OnDelete(DeleteBehavior.Restrict);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<JRVPapeleta> entity);
}
