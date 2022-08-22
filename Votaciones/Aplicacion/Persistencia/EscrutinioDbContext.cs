
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
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(conexion);
        }
        //base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlServer(conexion);"Server=MSSQLSERVER; Database=votaciones; User Id=userp; Password=aeiou123"
    }

    public DbSet<Acta> Acta { get; set; }
}
