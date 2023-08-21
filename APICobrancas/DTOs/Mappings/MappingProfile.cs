using APICobrancas.Dominio;
using AutoMapper;

namespace APICobrancas.DTOs.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Cobranca, CobrancaDTO>().ReverseMap();
        }
    }
}
