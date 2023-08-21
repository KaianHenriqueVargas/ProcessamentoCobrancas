using APICobrancas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICobrancas.Repositorio
{
    public class UnityOfWork : IUnityOfWork
    {
        private CobrancaRepositorio _cobrancaRepositorio;
        private AppDBContext _dbContext;

        public ICobrancaRepositorio CobrancaRepositorio
        {
            get
            {
                return _cobrancaRepositorio = _cobrancaRepositorio ?? new CobrancaRepositorio(_dbContext);
            }
        }

        public UnityOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
