
using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Persistencia;
public partial class EscrutinioDbContext : DbContext
{


    public EscrutinioDbContext(DbContextOptions<EscrutinioDbContext> options) : base(options)
    {

    }

    public EscrutinioDbContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActaConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    public virtual DbSet<Acta> Actas { get; set; }


}
