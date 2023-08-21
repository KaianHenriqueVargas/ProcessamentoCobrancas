namespace APIClientes.Repositorio.Interfaces
{
    public interface IUnityOfWork
    {
        IPessoaRepositorio PessoaRepositorio { get; }

        Task Commit();
    }
}
