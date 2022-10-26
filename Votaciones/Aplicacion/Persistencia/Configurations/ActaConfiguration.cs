using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacion.Persistencia.Configurations;
public partial class ActaConfiguration : IEntityTypeConfiguration<Acta>
{
    public void Configure(EntityTypeBuilder<Acta> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .HasColumnName("ActaId")
            .IsRequired(true);
        
        entity.Property(e => e.JRVId)
           .IsRequired(true);

        entity.Property(e => e.PapeletaId)
            .IsRequired(true);

        entity.Property(e => e.Codigo)
            .HasMaxLength(60)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.CantidadVotaciones)
            .IsRequired(true);

        entity.Property(e => e.VotosBlancos)
            .IsRequired(true);

        entity.Property(e => e.VotosNulos)
            .IsRequired(true);

        entity.Property(e => e.FirmaPresidente)
            .IsRequired(true);

        entity.Property(e => e.FirmaSecretario)
            .IsRequired(true);

        entity.Property(e => e.Imagen)
            .HasMaxLength(1000)
            .IsUnicode(true)
            .IsRequired(true);

        entity.Property(e => e.Estado)
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

        entity.HasOne<JRVPapeleta>(e => e.JRVPapeleta)
            .WithOne(e => e.Acta)
            .HasForeignKey<Acta>(e => new { e.JRVId, e.PapeletaId })
            .HasConstraintName("FK_ActasJRVs_Papeletas");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Acta> entity);
}
