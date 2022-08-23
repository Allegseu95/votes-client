
using Aplicacion.Dominio.Entidades.Escrutinio;
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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    public DbSet<Acta> Acta { get; set; }
}
