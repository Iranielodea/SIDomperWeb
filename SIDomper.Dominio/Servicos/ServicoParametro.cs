using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoParametro : IServicoParametro
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ParametroConsulta> _repositoryReadOnly;
        private readonly IRepositoryReadOnly<ParametroTitulosQuadroViewModel> _repositoryTitulosQuadroReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoParametro(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ParametroConsulta> repositoryReadOnly,
           IRepositoryReadOnly<ParametroTitulosQuadroViewModel> repositoryTitulosQuadroReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Parametro;
            _repositoryTitulosQuadroReadOnly = repositoryTitulosQuadroReadOnly;
        }

        public Parametro Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Parametro model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioParametro.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ParametroConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Par_Id as Id,");
            sb.AppendLine(" Par_Codigo as Codigo,");
            sb.AppendLine(" Par_Nome as Nome,");
            sb.AppendLine(" Par_Programa as Programa,");
            sb.AppendLine(" Par_Valor as Valor");
            sb.AppendLine(" FROM Parametros");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Par_Id > 0");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public IEnumerable<Parametro> ListarTodos()
        {
            return _uow.RepositorioParametro.GetAll();
        }

        public Parametro Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var parametro = new Parametro
            {
                Codigo = ProximoCodigo()
            };
            return parametro;
        }

        public Parametro ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioParametro.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Parâmetro não Cadastrado!");
            return model;
        }

        public Parametro ObterPorId(int id)
        {
            return _uow.RepositorioParametro.find(id);
        }

        public Parametro ObterPorParametro(int codigo, int programa)
        {
            return _uow.RepositorioParametro.ObterPorParametro(codigo, programa);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Parametro model)
        {
            if (model.Codigo < 0)
                _uow.Notificacao.Add("O Código não pode ficar Negativo!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (string.IsNullOrWhiteSpace(model.Valor))
                _uow.Notificacao.Add("Informe o Valor do Parâmetro!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            _uow.RepositorioParametro.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioParametro.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public IEnumerable<ParametroTitulosQuadroViewModel> BuscarTitulosQuadro()
        {
            var listaTitulos = new List<ParametroTitulosQuadroViewModel>();

            var resultado = _uow.RepositorioParametro.BuscarTitulosQuadro();
            listaTitulos = _repositoryTitulosQuadroReadOnly.GetAll(resultado).ToList();

            foreach (var item in listaTitulos)
            {
                switch(item.CodigoParametro)
                {
                    case 3:
                        item.NumeroQuadro = 1; // chamados
                        item.Tipo = 1;
                        break;
                    case 4:
                        item.NumeroQuadro = 2;
                        item.Tipo = 1;
                        break;
                    case 5:
                        item.NumeroQuadro = 3;
                        item.Tipo = 1;
                        break;
                    case 6:
                        item.NumeroQuadro = 4;
                        item.Tipo = 1;
                        break;
                    case 7:
                        item.NumeroQuadro = 5;
                        item.Tipo = 1;
                        break;
                    case 8:
                        item.NumeroQuadro = 6;
                        item.Tipo = 1;
                        break;
                    case 12:
                        item.NumeroQuadro = 1; // solicitacoes
                        item.Tipo = 3;
                        break;
                    case 13:
                        item.NumeroQuadro = 2;
                        item.Tipo = 3;
                        break;
                    case 14:
                        item.NumeroQuadro = 3;
                        item.Tipo = 3;
                        break;
                    case 15:
                        item.NumeroQuadro = 4;
                        item.Tipo = 3;
                        break;
                    case 16:
                        item.NumeroQuadro = 5;
                        item.Tipo = 3;
                        break;
                    case 17:
                        item.NumeroQuadro = 6;
                        item.Tipo = 3;
                        break;
                    case 19:
                        item.NumeroQuadro = 7;
                        item.Tipo = 3;
                        break;
                    case 20:
                        item.NumeroQuadro = 8;
                        item.Tipo = 3;
                        break;
                    case 21:
                        item.NumeroQuadro = 9;
                        item.Tipo = 3;
                        break;
                    case 22:
                        item.NumeroQuadro = 10;
                        item.Tipo = 3;
                        break;
                    case 23:
                        item.NumeroQuadro = 11;
                        item.Tipo = 3;
                        break;
                    case 24:
                        item.NumeroQuadro = 12;
                        item.Tipo = 3;
                        break;
                    case 25:
                        item.NumeroQuadro = 1; // atividades
                        item.Tipo = 2;
                        break;
                    case 26:
                        item.NumeroQuadro = 2;
                        item.Tipo = 2;
                        break;
                    case 27:
                        item.NumeroQuadro = 3;
                        item.Tipo = 2;
                        break;
                    case 28:
                        item.NumeroQuadro = 4;
                        item.Tipo = 2;
                        break;
                    case 29:
                        item.NumeroQuadro = 5;
                        item.Tipo = 2;
                        break;
                    case 30:
                        item.NumeroQuadro = 6;
                        item.Tipo = 2;
                        break;
                }
            }
            return listaTitulos;
        }
    }
}
