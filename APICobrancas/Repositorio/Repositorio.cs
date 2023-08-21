using APICobrancas.Repositorio.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APICobrancas.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected AppDBContext _dbContext;

        public Repositorio(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByID(Expression<Func<T, bool>> condicao)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(condicao);
        }

        public void Add(T entidade)
        {
            _dbContext.Set<T>().Add(entidade);
        }

        public void Delete(T entidade)
        {
            _dbContext.Set<T>().Remove(entidade);
        }

        public void Update(T entidade)
        {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entidade);
        }
    }
}
