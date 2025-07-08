using AutoMapper;
using CRUD.Core.Application.DTO;
using CRUD.Core.Domain.Entities;

namespace CRUD.Core.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            CreateMap<Telefone, TelefoneDTO>().ForMember(dest => dest.TipoTelefoneDesc, opt => opt.MapFrom(src => src.TipoTelefone.DescricaoTipoTelefone));

            CreateMap<TelefoneCreateDTO, Telefone>();

            CreateMap<TipoTelefone, TipoTelefoneDTO>().ReverseMap();
        }
    }
}