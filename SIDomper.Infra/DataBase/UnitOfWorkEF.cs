using System;
using System.Collections.Generic;
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
            _notificacao = new List<string>();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        private List<string> _notificacao;
        public List<string> Notificacao
        {
            get
            {
                return _notificacao;
            }
        }

        public bool IsValid()
        {
            return (_notificacao.Count == 0);
        }

        public string RetornoNotificacao()
        {
            string resultado = "";
            foreach (var item in _notificacao)
            {
                resultado = resultado + item + Environment.NewLine;
            }

            return resultado;
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

        private IRepositorioContaEmail _repositorioContaEmail;
        public IRepositorioContaEmail RepositorioContaEmail
        {
            get
            {
                if (_repositorioContaEmail == null)
                    _repositorioContaEmail = new RepositorioContaEmail(_context);
                return _repositorioContaEmail;
            }
        }

        private IRepositorioObservacao _repositorioObservacao;
        public IRepositorioObservacao RepositorioObservacao
        {
            get
            {
                if (_repositorioObservacao == null)
                    _repositorioObservacao = new RepositorioObservacao(_context);
                return _repositorioObservacao;
            }
        }

        private IRepositorioTipo _repositorioTipo;
        public IRepositorioTipo RepositorioTipo
        {
            get
            {
                if (_repositorioTipo == null)
                    _repositorioTipo = new RepositorioTipo(_context);
                return _repositorioTipo;
            }
        }

        private IRepositorioStatus _repositorioStatus;
        public IRepositorioStatus RepositorioStatus
        {
            get
            {
                if (_repositorioStatus == null)
                    _repositorioStatus = new RepositorioStatus(_context);
                return _repositorioStatus;
            }
        }

        private IRepositorioEscala _repositorioEscala;
        public IRepositorioEscala RepositorioEscala
        {
            get
            {
                if (_repositorioEscala == null)
                    _repositorioEscala = new RepositorioEscala(_context);
                return _repositorioEscala;
            }
        }

        private IRepositorioParametro _repositorioParametro;
        public IRepositorioParametro RepositorioParametro
        {
            get
            {
                if (_repositorioParametro == null)
                    _repositorioParametro = new RepositorioParametro(_context);
                return _repositorioParametro;
            }
        }
    }
}
