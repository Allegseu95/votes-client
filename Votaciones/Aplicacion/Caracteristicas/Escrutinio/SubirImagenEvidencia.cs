using Aplicacion.Servicios.Intefaces;
using AutoMapper;
using Cliente.Shared.ComandosDTO;
using Cliente.Shared.EntidadadesDTO;
using FluentValidation;
using MediatR;

namespace Aplicacion.Caracteristicas.Escrutinio;
public class SubirImagenEvidencia
{
    public class ComandoValidacion : AbstractValidator<ArchivoComandoDTO>
    {
        public ComandoValidacion()
        {
            RuleFor(x => x.Path).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.Contenido).NotEmpty();
            RuleFor(x => x.Tamano).InclusiveBetween(1, 1024 * 1024 * 8);
        }
    }

    public class Handler : IRequestHandler<ArchivoComandoDTO, RespuestaDTO>
    {
        private readonly ISubirArchivo subirArchivo;
        private readonly IMapper mapper;

        public Handler(ISubirArchivo subirArchivo, IMapper mapper)
        {
            this.subirArchivo = subirArchivo;
            this.mapper = mapper;
        }
        public async Task<RespuestaDTO> Handle(ArchivoComandoDTO request,
            CancellationToken cancellationToken)
            => this.mapper.Map<RespuestaDTO>(
                await this.subirArchivo.Ejecutar(request.Path, request.Nombre, request.Contenido));
    }

    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<ArchivoRespuestaDTO, RespuestaDTO>()
                .ConstructUsing(e => new RespuestaDTO(e.Ruta, e.Estado, e.Cantidad));
        }
    }
}