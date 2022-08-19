using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cliente.Shared.Escrutinio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                await this.context.Acta.ProjectTo<ActaDTO>(this.mapper.ConfigurationProvider)
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
