using APIClientes.Dominio;
using APIClientes.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace APIClientes.Repositorio
{
    public class PessoaRepositorio : Repositorio<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(AppDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AdicionarPessoaSeNaoExistir(Pessoa pessoa)
        {
            if (await GetByID(p => p.CPF == pessoa.CPF) != null)
            {
                return false;
            }
            Add(pessoa);
            return true;
        }
    }
}
