using APIClientes.Dominio;
using System.Linq.Expressions;

namespace APIClientes.Repositorio.Interfaces
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        public Task<bool> AdicionarPessoaSeNaoExistir(Pessoa pessoa);
    }
}
