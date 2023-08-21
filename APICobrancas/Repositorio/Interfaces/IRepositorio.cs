using System.Linq.Expressions;

namespace APICobrancas.Repositorio.Interfaces
{
    public interface IRepositorio<T>
    {
        IQueryable<T> Get();
        Task<T> GetByID(Expression<Func<T, bool>> condicao);
        void Add(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
    }
}
