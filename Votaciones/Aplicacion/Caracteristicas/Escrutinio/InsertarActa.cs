using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared.Escrutinio;
using FluentValidation;
using MediatR;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class InsertarActa
{
    public class ComandoValidacion : AbstractValidator<ActaComandoDTO>
    {
        public ComandoValidacion()
        {
            RuleFor(x => x.JRVId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.PapeletaId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.CantidadVotaciones).GreaterThanOrEqualTo(0);
            RuleFor(x => x.VotosBlancos).GreaterThanOrEqualTo(0);
            RuleFor(x => x.VotosNulos).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Imagen).NotEmpty().MinimumLength(8);
            RuleFor(x => x.DetalleActas).NotEmpty();
            RuleForEach(x => x.DetalleActas).ChildRules(det =>
            {
                det.RuleFor(x => x.CandidatoId).NotEmpty().GreaterThanOrEqualTo(1);
                det.RuleFor(x => x.CantidadVotos).GreaterThanOrEqualTo(0);
            });
        }
    }

    public class Handler : IRequestHandler<ActaComandoDTO, bool>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(ActaComandoDTO request,
            CancellationToken cancellationToken)
        {
            try
            {
                await context.Actas.AddAsync(this.mapper.Map<Acta>(request), cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al Registrar => {e.InnerException?.Message}");
                return false;
            }
        }
    }

    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<ActaComandoDTO, Acta>();
            CreateMap<DetalleActaComandoDTO, DetalleActa>();
        }
    }
}
