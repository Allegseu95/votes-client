
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
    private const string DB = "BDdemo";
    private string conexion =
        $"Data Source=(localDb)\\MSSQLlocalDB;Database={DB};Integrated Security=true";

    public EscrutinioDbContext(DbContextOptions<EscrutinioDbContext> options) : base(options)
    {

    }

    public EscrutinioDbContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(conexion);
    }

    public DbSet<Acta> Acta { get; set; }
}
