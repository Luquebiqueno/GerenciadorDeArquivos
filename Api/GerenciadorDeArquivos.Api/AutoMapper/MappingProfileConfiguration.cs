using AutoMapper;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;

namespace GerenciadorDeArquivos.Api.AutoMapper
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Usuario, UsuarioDto>();

            //CreateMap<Gasto, GastoViewModel>()
            //.ReverseMap();
        }
    }
}
