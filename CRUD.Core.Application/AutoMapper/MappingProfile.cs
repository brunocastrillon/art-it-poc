﻿using AutoMapper;
using CRUD.Core.Application.DTO;
using CRUD.Core.Domain.Entities;

namespace CRUD.Core.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cliente para resposta
            //CreateMap<Cliente, ClienteResponseDTO>().ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones));
            CreateMap<Cliente, ClienteResponseDTO>();

            // Cliente para criação
            CreateMap<ClienteCreateDTO, Cliente>().ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones));

            // Base reversível (opcional)
            CreateMap<ClienteDTO, Cliente>().ReverseMap();

            // Telefones de entrada
            //CreateMap<TelefoneCreateDTO, Telefone>().ForMember(dest => dest.CodigoTipoTelefone, opt => opt.MapFrom(src => src.CodigoTipoTelefone));
            CreateMap<TelefoneCreateDTO, Telefone>().ForMember(dest => dest.TipoTelefone, opt => opt.Ignore()); // se usar string como TipoTelefoneDesc

            // Telefones de saída
            CreateMap<Telefone, TelefoneResponseDTO>().ForMember(dest => dest.TipoTelefoneDesc, opt => opt.MapFrom(src => src.TipoTelefone.DescricaoTipoTelefone));


            CreateMap<TipoTelefone, TipoTelefoneDTO>().ReverseMap();
        }
    }
}