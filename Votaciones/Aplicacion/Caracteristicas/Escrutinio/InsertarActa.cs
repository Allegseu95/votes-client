using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia;
using AutoMapper;
using FluentValidation;
using MediatR;
using static Aplicacion.Caracteristicas.Escrutinio.ObtenerActas;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class InsertarActa
{
    public class Comando : IRequest<int>
    {
        public int JRVId { get; set; }
        public int PapeletaId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public int CantidadVotaciones { get; set; }
        public int VotosBlancos { get; set; }
        public int VotosNulos { get; set; }
        public Boolean FirmaPresidente { get; set; }
        public Boolean FirmaSecretario { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public Boolean Estado { get; set; }
    }

    public class ActaValidacion : AbstractValidator<Comando>
    {
        public ActaValidacion()
        {
            RuleFor(x => x.CantidadVotaciones).NotEmpty();
            RuleFor(x => x.VotosBlancos).NotEmpty();
            RuleFor(x => x.VotosNulos).NotEmpty();
            RuleFor(x => x.FirmaPresidente).NotEmpty();
            RuleFor(x => x.FirmaSecretario).NotEmpty();
            RuleFor(x => x.Imagen).NotEmpty();
            RuleFor(x => x.Estado).NotEmpty();
           // RuleFor(x => x.Observador).NotEmpty();

        }
    }


    public class Handler : IRequestHandler<Comando, int>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(Comando request,
            CancellationToken cancellationToken)
        {
            await context.Actas.AddAsync(this.mapper.Map<Acta>(request), cancellationToken);
            return await context.SaveChangesAsync(cancellationToken);
        }
    }

    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<Comando, Acta>();
        }
    }
}
