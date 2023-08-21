namespace APICobrancas.Repositorio.Interfaces
{
    public interface IUnityOfWork
    {
        ICobrancaRepositorio CobrancaRepositorio { get; }

        Task Commit();

    }
}

