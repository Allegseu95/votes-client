using Aplicacion.Dominio.Entidades.Escrutinio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Persistencia.Configurations;
public partial class ActaConfiguration : IEntityTypeConfiguration<Acta>
{
    public void Configure(EntityTypeBuilder<Acta> entity)
    {


        entity.HasKey(e => e.Id);






        entity.Property(e => e.Imagen)
            .HasMaxLength(500)
            .IsUnicode(true)
            .IsRequired(true);



        OnConfigurePartial(entity);

    }

    partial void OnConfigurePartial(EntityTypeBuilder<Acta> entity);

}
