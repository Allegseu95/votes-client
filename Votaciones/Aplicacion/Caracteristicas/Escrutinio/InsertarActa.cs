using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared.Escrutinio;
using Cliente.Shared.Mensajes;
using FluentValidation;
using MediatR;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class InsertarActa
{
    public class ComandoValidacionDetallesActa : AbstractValidator<DetalleActaComandoDTO>
    {
        public ComandoValidacionDetallesActa()
        {
            RuleFor(x => x.CandidatoId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.CantidadVotos).GreaterThanOrEqualTo(0);
        }
    }

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
            RuleForEach(x => x.DetalleActas).SetValidator(new ComandoValidacionDetallesActa());
        }
    }

    public class Handler : IRequestHandler<ActaComandoDTO, RespuestaDTO>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RespuestaDTO> Handle(ActaComandoDTO request,
            CancellationToken cancellationToken)
        {
            try
            {
                await context.Actas.AddAsync(this.mapper.Map<Acta>(request), cancellationToken);
                int cantidadCambios = await context.SaveChangesAsync(cancellationToken);
                return cantidadCambios >= 2
                    ? new RespuestaDTO(MensajesNotificacion.MENSAJE_ACTA_REGISTRADA, true, cantidadCambios)
                    : new RespuestaDTO(MensajesNotificacion.MENSAJE_ACTA_REGISTRADA_PROBLEMAS, true, cantidadCambios);
            }
            catch (Exception)
            {
                return new RespuestaDTO(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA, false, 0);
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
