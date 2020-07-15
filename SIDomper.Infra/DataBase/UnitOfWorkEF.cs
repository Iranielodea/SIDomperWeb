using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.RepositorioEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
