using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacion.Persistencia.Configurations;
public partial class DetalleActaConfiguration : IEntityTypeConfiguration<DetalleActa>
{
    public void Configure(EntityTypeBuilder<DetalleActa> entity)
    {
        entity.ToTable("Detalles_Acta");

        entity.HasKey(e => new { e.ActaId, e.CandidatoId });
        
        entity.Property(e => e.ActaId)
            .IsRequired(true);

        entity.Property(e => e.CandidatoId)
            .IsRequired(true);

        entity.Property(e => e.CantidadVotos)
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

        entity.HasOne<Acta>(e => e.Acta)
            .WithMany(e => e.DetalleActas)
            .HasForeignKey(e => e.ActaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_DetallesActasActas");

        entity.HasOne<Candidato>(e => e.Candidato)
            .WithMany(e => e.DetalleActas)
            .HasForeignKey(e => e.CandidatoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_DetallesActasCandidatos");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<DetalleActa> entity);
}
