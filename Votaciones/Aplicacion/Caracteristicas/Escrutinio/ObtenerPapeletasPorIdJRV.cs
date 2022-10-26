using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Helper.Comunes.Mappings;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared.Escrutinio;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class ObtenerPapeletasPorIdJRV
{
    public record Consulta(int JRVId) : IRequest<IReadOnlyList<JRVPapeletaDTO>>;

    public class ConsultaValidacion : AbstractValidator<Consulta>
    {
        public ConsultaValidacion()
        {
            RuleFor(x => x.JRVId).GreaterThanOrEqualTo(1);
        }
    }

    public class Handler : IRequestHandler<Consulta, IReadOnlyList<JRVPapeletaDTO>>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<JRVPapeletaDTO>> Handle(Consulta request,
            CancellationToken cancellationToken)
            => await this.context.JRVPapeletas.Where(e => e.JRVId == request.JRVId)
                .Include(e => e.Papeleta)
                .Include(e => e.Acta)
                .ProjectToListAsync<JRVPapeletaDTO>(this.mapper.ConfigurationProvider);
    }

    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<JRVPapeleta, JRVPapeletaDTO>()
                .ConstructUsing(e => new JRVPapeletaDTO(0, 0, string.Empty, e.Acta == null ? false : true));
        }
    }
}
