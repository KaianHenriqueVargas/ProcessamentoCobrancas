using APIClientes.Repositorio.Interfaces;

namespace APIClientes.Repositorio
{
    public class UnityOfWork : IUnityOfWork
    {
        private PessoaRepositorio _pessoaRepositorio;
        public AppDBContext _dbcontext;

        public IPessoaRepositorio PessoaRepositorio
        {
            get
            {
                return _pessoaRepositorio = _pessoaRepositorio ?? new PessoaRepositorio(_dbcontext);
            }
        }

        public UnityOfWork(AppDBContext contexto)
        {
            _dbcontext = contexto;

        }

        public async Task Commit()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
