using SIDomper.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        List<string> Notificacao { get; }
        bool IsValid();
        string RetornoNotificacao();

        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
        void Executar(string instrucaoSQL);

        IRepositorioProduto RepositorioProduto { get; }
        IRepositorioModulo RepositorioModulo { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioCategoria RepositorioCategoria { get; }
        IRepositorioCidade RepositorioCidade { get; }
        IRepositorioFeriado RepositorioFeriado { get; }
        IRepositorioContaEmail RepositorioContaEmail { get; }
        IRepositorioObservacao RepositorioObservacao { get; }
        IRepositorioTipo RepositorioTipo { get; }
        IRepositorioStatus RepositorioStatus { get; }
        IRepositorioEscala RepositorioEscala { get; }
        IRepositorioParametro RepositorioParametro { get; }
        IRepositorioRevenda RepositorioRevenda { get; }
        IRepositorioCliente RepositorioCliente { get; }
        IRepositorioRamal RepositorioRamal { get; }
        IRepositorioDepartamento RepositorioDepartamento { get; }
    }
}
