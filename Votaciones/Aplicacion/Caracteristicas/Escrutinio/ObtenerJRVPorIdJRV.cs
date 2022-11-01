using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared.Escrutinio;
using FluentValidation;
using MediatR;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class ObtenerJRVPorIdJRV
{
    public record Consulta(int JRVId) : IRequest<JRVDTO>;

    public class ConsultaValidacion : AbstractValidator<Consulta>
    {
        public ConsultaValidacion()
        {
            RuleFor(x => x.JRVId).GreaterThanOrEqualTo(1);
        }
    }

    public class Handler : IRequestHandler<Consulta, JRVDTO>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<JRVDTO> Handle(Consulta request,
            CancellationToken cancellationToken) =>
            this.mapper.Map<JRVDTO>(await this.context.JRVs.FindAsync(request.JRVId));
    }
    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<JRV, JRVDTO>();
        }
    }
}
