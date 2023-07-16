using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Helper.Comunes.Mappings;
using Aplicacion.Persistencia;
using AutoMapper;
using Cliente.Shared.EntidadadesDTO;
using FluentValidation;
using MediatR;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class ObtenerUsuarioPorEmail
{
    public record Consulta(string Email) : IRequest<IReadOnlyList<UsuarioDTO>>;

    public class ConsultaValidacion : AbstractValidator<Consulta>
    {
        public ConsultaValidacion()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
        }
    }

    public class Handler : IRequestHandler<Consulta, IReadOnlyList<UsuarioDTO>>
    {
        private readonly EscrutinioDbContext context;
        private readonly IMapper mapper;

        public Handler(EscrutinioDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<UsuarioDTO>> Handle(Consulta request,
            CancellationToken cancellationToken) =>
            await this.context.Usuarios.Where(e => e.Email == request.Email)
                .ProjectToListAsync<UsuarioDTO>(this.mapper.ConfigurationProvider);
    }
    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
