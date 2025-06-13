using AutoMapper;
using Servidor.Dtos;
using Servidor.Modelos;

namespace Servidor
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {

            CreateMap<Ajustador, AjustadorDto>()
                .ForMember(dest => dest.NombreCompleto, opt =>
                opt.MapFrom(src =>
                $"{src.Nombre} {src.ApellidoPaterno} {src.ApellidoMaterno}".Trim()));

            CreateMap<Usuario, LoginResponseDto>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.NumeroEmpleado, opt => opt.MapFrom(src => src.NumeroEmpleado))
                .ForMember(dest => dest.UltimoAcceso, opt => opt.MapFrom(src => src.UltimoAcceso))
                .ForMember(dest => dest.Ajustador,
               opt => opt.MapFrom(src => src.NumeroEmpleadoNavigation))
                .ForMember(dest => dest.Localizacion, opt => opt.MapFrom(src => src.Localizacion));

            CreateMap<LoginResponseDto, Usuario>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.NumeroEmpleado, opt => opt.MapFrom(src => src.NumeroEmpleado))
                .ForMember(dest => dest.UltimoAcceso, opt => opt.MapFrom(src => src.UltimoAcceso))
                .ForMember(dest => dest.Localizacion, opt => opt.MapFrom(src => src.Localizacion));

            

           
        }
    }
}
