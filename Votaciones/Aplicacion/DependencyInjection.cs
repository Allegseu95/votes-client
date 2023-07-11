using Aplicacion.Helper;
using Aplicacion.Persistencia;
using Aplicacion.Servicios.Implementaciones;
using Aplicacion.Servicios.Intefaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Aplicacion;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
    {
        /*services.AddScoped<ISubirArchivo, SubirArchivoLocal>();*/
        services.AddScoped<ISubirArchivo, SubirArchivoBlobStorage>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddLogging();



        //if (bool.Parse(configuration.GetSection("UseInMemoryDatabase").Value))
        //    services.AddDbContext<SGAPContext>(options =>
        //    {
        //        options.UseInMemoryDatabase("SGAPInMemory");
        //    });
        //else
        services.AddDbContext<EscrutinioDbContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }, ServiceLifetime.Transient);

        services.AddHelper();
        return services;
    }
}