using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cliente.Shared.EntidadadesDTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class ObtenerActas
{
    public record Consulta : IRequest<IReadOnlyList<ActaDTO>>;

    public class Handler : IRequestHandler<Consulta, IReadOnlyList<ActaDTO>>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<ActaDTO>> Handle(Consulta request,
            CancellationToken cancellationToken)
        {
            IReadOnlyCollection<ActaDTO> respuesta =
                await this.context.Actas.ProjectTo<ActaDTO>(this.mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);

            return (IReadOnlyList<ActaDTO>)respuesta;
        }
    }

    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<Acta, ActaDTO>();
        }
    }
}
