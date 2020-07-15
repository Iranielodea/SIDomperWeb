using SIDomper.Dominio.Interfaces.Repositorios;

namespace SIDomper.Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
        void Executar(string instrucaoSQL);

        IRepositorioProduto RepositorioProduto { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
    }
}
