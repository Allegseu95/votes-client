using Aplicacion.Helper;
using Aplicacion.Persistencia;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Aplicacion;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddLogging();


        //mi codigo para usar la base de datos creado con code first
        services.AddDbContext<EscrutinioDbContext>();

        //if (bool.Parse(configuration.GetSection("UseInMemoryDatabase").Value))
        //    services.AddDbContext<SGAPContext>(options =>
        //    {
        //        options.UseInMemoryDatabase("SGAPInMemory");
        //    });
        //else
        //    services.AddDbContext<SGAPContext>(options =>
        //    {
        //        options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //    }, ServiceLifetime.Transient);
        services.AddScoped<Contexto>();
        services.AddHelper();
        return services;
    }
}