using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Helper.Comunes.Mappings;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared.Escrutinio;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class ObtenerCandidatosPorIdPapeleta
{
    public record Consulta(int PapeletaId) : IRequest<IReadOnlyList<CandidatoDTO>>;

    public class ConsultaValidacion : AbstractValidator<Consulta>
    {
        public ConsultaValidacion()
        {
            RuleFor(x => x.PapeletaId).GreaterThanOrEqualTo(1);
        }
    }

    public class Handler : IRequestHandler<Consulta, IReadOnlyList<CandidatoDTO>>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<CandidatoDTO>> Handle(Consulta request,
            CancellationToken cancellationToken)
        => await this.context.Candidatos.Where(e => e.PapeletaId == request.PapeletaId)
            .Include(e => e.Papeleta)
            .ProjectToListAsync<CandidatoDTO>(this.mapper.ConfigurationProvider);
    }
    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<Candidato, CandidatoDTO>();
        }
    }
}
