using APICobrancas.Dominio;
using APICobrancas.Repositorio.Interfaces;
using AutoMapper;

namespace APICobrancas.Repositorio
{
    public class CobrancaRepositorio : Repositorio<Cobranca>, ICobrancaRepositorio
    {
        private Mapper _mapper;
        public CobrancaRepositorio(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
