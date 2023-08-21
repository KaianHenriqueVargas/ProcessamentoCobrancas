using APIClientes.Dominio;
using AutoMapper;

namespace APIClientes.DTOs.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        }
    }
}
