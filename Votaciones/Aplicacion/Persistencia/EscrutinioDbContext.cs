using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Helper.Dominio.Comunes;
using Aplicacion.Persistencia.Configurations;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace Aplicacion.Persistencia;
public partial class EscrutinioDbContext : ApiAuthorizationDbContext<UsuarioCredencial>
{
    public EscrutinioDbContext(
        DbContextOptions<EscrutinioDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ActaConfiguration());
        modelBuilder.ApplyConfiguration(new CandidatoConfiguration());
        modelBuilder.ApplyConfiguration(new DetalleActaConfiguration());
        modelBuilder.ApplyConfiguration(new JRVPapeletaConfiguration());
        modelBuilder.ApplyConfiguration(new JRVConfiguration());
        modelBuilder.ApplyConfiguration(new PapeletaConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public virtual DbSet<Acta> Actas { get; set; }
    public virtual DbSet<Candidato> Candidatos { get; set; }
    public virtual DbSet<DetalleActa> DetallesActa { get; set; }
    public virtual DbSet<JRVPapeleta> JRVPapeletas { get; set; }
    public virtual DbSet<JRV> JRVs { get; set; }
    public virtual DbSet<Papeleta> Papeletas { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await GestionarAuditoria();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task GestionarAuditoria()
    {
        var usuarioActual = "Usuario Prueba";

        foreach (var item in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (item.State)
            {

                case EntityState.Modified:
                    item.Entity.Modificado = DateTime.Now;
                    item.Entity.ModificadoPor = usuarioActual;
                    break;
                case EntityState.Added:
                    item.Entity.Modificado = DateTime.Now;
                    item.Entity.ModificadoPor = usuarioActual;
                    item.Entity.Creado = DateTime.Now;
                    item.Entity.CreadoPor = usuarioActual;
                    break;
                default:
                    break;
            }
        }

        await Task.CompletedTask;

    }
}


