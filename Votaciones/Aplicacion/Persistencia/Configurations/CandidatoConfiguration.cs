using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacion.Persistencia.Configurations;
public partial class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
{
    public void Configure(EntityTypeBuilder<Candidato> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .HasColumnName("CandidatoId")
            .IsRequired(true);
        
        entity.Property(e => e.PapeletaId)
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
            .IsRequired(true);

        entity.Property(e => e.FechaNacimiento)
         .HasColumnType("date")
         .IsRequired(true);

        entity.Property(e => e.OrganizacionPolitica)
           .HasMaxLength(500)
           .IsUnicode(true)
           .IsRequired(true);

        entity.Property(e => e.Imagen)
            .HasMaxLength(1000)
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

        entity.HasOne<Papeleta>(e => e.Papeleta)
            .WithMany(e => e.Candidatos)
            .HasForeignKey(e => e.PapeletaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_CandidatosPapeletas");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Candidato> entity);
}
