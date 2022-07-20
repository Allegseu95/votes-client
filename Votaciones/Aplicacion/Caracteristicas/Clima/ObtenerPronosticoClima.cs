using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared;
using MediatR;

namespace Aplicacion.Caracteristicas.Clima;

public class ObtenerPronosticoClima
{
    public record Consulta : IRequest<IReadOnlyList<PronosticoClimaDto>>;


    public class Handler : IRequestHandler<Consulta, IReadOnlyList<PronosticoClimaDto>>
    {
        private readonly Contexto context;
        private readonly IMapper mapper;

        public Handler(Contexto context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<PronosticoClimaDto>> Handle(Consulta request,
            CancellationToken cancellationToken) =>
            await Task.FromResult(this.mapper.Map<IReadOnlyList<PronosticoClimaDto>>(this.context.Pronosticos));
    }


    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<PronosticoClima, PronosticoClimaDto>();
        }
    }
}