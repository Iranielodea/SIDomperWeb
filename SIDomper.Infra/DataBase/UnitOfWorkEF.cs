using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.RepositorioEF;

namespace SIDomper.Infra.DataBase
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private Contexto _context;

        public UnitOfWorkEF(Contexto context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Executar(string instrucaoSQL)
        {
            _context.Database.ExecuteSqlCommand(instrucaoSQL);
        }

        private IRepositorioProduto _repositorioProduto;
        public IRepositorioProduto RepositorioProduto
        {
            get
            {
                if (_repositorioProduto == null)
                    _repositorioProduto = new RepositorioProduto(_context);
                return _repositorioProduto;
            }
        }

        private IRepositorioUsuario _repositorioUsuario;
        public IRepositorioUsuario RepositorioUsuario
        {
            get
            {
                if (_repositorioUsuario == null)
                    _repositorioUsuario = new RepositorioUsuario(_context);
                return _repositorioUsuario;
            }
        }

        private IRepositorioModulo _repositorioModulo;
        public IRepositorioModulo RepositorioModulo
        {
            get
            {
                if (_repositorioModulo == null)
                    _repositorioModulo = new RepositorioModulo(_context);
                return _repositorioModulo;
            }
        }

        private IRepositorioCategoria _repositorioCategoria;
        public IRepositorioCategoria RepositorioCategoria
        {
            get
            {
                if (_repositorioCategoria == null)
                    _repositorioCategoria = new RepositorioCategoria(_context);
                return _repositorioCategoria;
            }
        }

        private IRepositorioCidade _repositorioCidade;
        public IRepositorioCidade RepositorioCidade
        {
            get
            {
                if (_repositorioCidade == null)
                    _repositorioCidade = new RepositorioCidade(_context);
                return _repositorioCidade;
            }
        }

        private IRepositorioFeriado _repositorioFeriado;
        public IRepositorioFeriado RepositorioFeriado
        {
            get
            {
                if (_repositorioFeriado == null)
                    _repositorioFeriado = new RepositorioFeriado(_context);
                return _repositorioFeriado;
            }
        }
    }
}
