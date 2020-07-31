using System;
using System.Collections.Generic;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.RepositorioEF;

namespace SIDomper.Infra.DataBase
{
    public class UnitOfWorkEF : IUnitOfWork, IDisposable
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

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
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

        private IRepositorioRevenda _repositorioRevenda;
        public IRepositorioRevenda RepositorioRevenda
        {
            get
            {
                if (_repositorioRevenda == null)
                    _repositorioRevenda = new RepositorioRevenda(_context);
                return _repositorioRevenda;
            }
        }

        private IRepositorioCliente _repositorioCliente;
        public IRepositorioCliente RepositorioCliente
        {
            get
            {
                if (_repositorioCliente == null)
                    _repositorioCliente = new RepositorioCliente(_context);
                return _repositorioCliente;
            }
        }

        private IRepositorioRamal _repositorioRamal;
        public IRepositorioRamal RepositorioRamal
        {
            get
            {
                if (_repositorioRamal == null)
                    _repositorioRamal = new RepositorioRamal(_context);
                return _repositorioRamal;
            }
        }

        private IRepositorioDepartamento _repositorioDepartamento;
        public IRepositorioDepartamento RepositorioDepartamento
        {
            get
            {
                if (_repositorioDepartamento == null)
                    _repositorioDepartamento = new RepositorioDepartamento(_context);
                return _repositorioDepartamento;
            }
        }

        private IRepositorioBaseConhecimento _repositorioBaseConhecimento;
        public IRepositorioBaseConhecimento RepositorioBaseConhecimento
        {
            get
            {
                if (_repositorioBaseConhecimento == null)
                    _repositorioBaseConhecimento = new RepositorioBaseConhecimento(_context);
                return _repositorioBaseConhecimento;
            }
        }

        private IRepositorioAgendamento _repositorioAgendamento;
        public IRepositorioAgendamento RepositorioAgendamento
        {
            get
            {
                if (_repositorioAgendamento == null)
                    _repositorioAgendamento = new RepositorioAgendamento(_context);
                return _repositorioAgendamento;
            }
        }

        private IRepositorioVersao _repositorioVersao;
        public IRepositorioVersao RepositorioVersao
        {
            get
            {
                if (_repositorioVersao == null)
                    _repositorioVersao = new RepositorioVersao(_context);
                return _repositorioVersao;
            }
        }

        private IRepositorioVisita _repositorioVisita;
        public IRepositorioVisita RepositorioVisita
        {
            get
            {
                if (_repositorioVisita == null)
                    _repositorioVisita = new RepositorioVisita(_context);
                return _repositorioVisita;
            }
        }

        private IRepositorioRecado _repositorioRecado;
        public IRepositorioRecado RepositorioRecado
        {
            get
            {
                if (_repositorioRecado == null)
                    _repositorioRecado = new RepositorioRecado(_context);
                return _repositorioRecado;
            }
        }

        private IRepositorioChamado _repositorioChamado;
        public IRepositorioChamado RepositorioChamado
        {
            get
            {
                if (_repositorioChamado == null)
                    _repositorioChamado = new RepositorioChamado(_context);
                return _repositorioChamado;
            }
        }

    }
}
