using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Helper.Comunes.Mappings;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared.EntidadadesDTO;
using FluentValidation;
using MediatR;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class ObtenerJRVsPorIdUsuario
{
    public record Consulta(int UsuarioId) : IRequest<IReadOnlyList<JRVDTO>>;

    public class ConsultaValidacion : AbstractValidator<Consulta>
    {
        public ConsultaValidacion()
        {
            RuleFor(x => x.UsuarioId).GreaterThanOrEqualTo(1);
        }
    }

    public class Handler : IRequestHandler<Consulta, IReadOnlyList<JRVDTO>>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<JRVDTO>> Handle(Consulta request,
            CancellationToken cancellationToken)
            => await this.context.JRVs.Where(e => e.UsuarioId == request.UsuarioId)
                .ProjectToListAsync<JRVDTO>(this.mapper.ConfigurationProvider);
    }
    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<JRV, JRVDTO>();
        }
    }
}
