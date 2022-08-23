using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Persistencia;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class InsertarActa
{
    public record Consulta(
    int CantidadVotaciones,
    int VotosBlancos,
    int VotosNulos,
    Boolean FirmaPresidente,
    Boolean FirmaSecretario,
    string Imagen,
    Boolean Estado,
    string Observador) : IRequest<int>;


    public class Handler : IRequestHandler<Consulta, int>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(Consulta request,
            CancellationToken cancellationToken)
        {
            await context.Acta.AddAsync(this.mapper.Map<Acta>(request), cancellationToken);
            return await context.SaveChangesAsync(cancellationToken);
        }
    }


    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<Consulta, Acta>();
        }
    }
}
