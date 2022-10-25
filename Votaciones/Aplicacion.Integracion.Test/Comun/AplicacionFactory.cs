using Aplicacion.Persistencia;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacion.Integracion.Test.Comun;

internal class AplicacionFactory
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            var integrationConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            configurationBuilder.AddConfiguration(integrationConfig);
        });

        builder.ConfigureServices((builder, services) =>
        {
            //services
            //    .Remove<ICurrentUserService>()
            //    .AddTransient(provider => Mock.Of<ICurrentUserService>(s =>
            //        s.UserId == GetCurrentUserId()));

            services
                .Remove<DbContextOptions<EscrutinioDbContext>>()
                .AddDbContext<EscrutinioDbContext>((sp, options) =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(EscrutinioDbContext).Assembly.FullName)));
        });
    }
}