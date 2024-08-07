using AutoMapper;
using Practica_Final.DTO;
using Practica_Final.Models;

namespace Practica_Final.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Soldado, SoldadoDTO>().ReverseMap();

            CreateMap<Escuadron, EscuadronDTO>().ForMember(
                x => x.Tipo, opt => opt.MapFrom(src => src.TipoEscuadron.Nombre));

            CreateMap<SoldadoXEscuadron, SoldadoXEscuadronDTO>().ForMember(
                x => x.NombreEscuadron, opt => opt.MapFrom(src => src.Escuadron.Nombre))
                .ForMember(x => x.NombreSoldado, opt => opt.MapFrom(src => src.Soldado.Nombre))/*.ReverseMap()*/;
        }
    }
}
