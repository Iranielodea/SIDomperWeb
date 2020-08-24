using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoObservacao : IServicoObservacao
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ObservacaoConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoObservacao(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ObservacaoConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Observacao;
        }

        public Observacao Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Observacao model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioObservacao.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ObservacaoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Obs_Id as Id,");
            sb.AppendLine(" Obs_Codigo as Codigo,");
            sb.AppendLine(" Obs_Nome as Nome");
            sb.AppendLine(" FROM Observacao");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Obs_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Obs_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Obs_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Observacao Novo(int idUsuario)
        {
            var observacao = new Observacao();
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            observacao.Codigo = ProximoCodigo();
            observacao.Ativo = true;
            return observacao;
        }

        public Observacao ObterEmailPadrao(int? programa)
        {
            return _uow.RepositorioObservacao.ObterEmailPadrao(programa);
        }

        public Observacao ObterPadrao(int? programa)
        {
            return _uow.RepositorioObservacao.ObterPadrao(programa);
        }

        public Observacao ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioObservacao.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Observação não Cadastrada!");
            if (model.Ativo == false)
                throw new Exception("Observação Inativa!");
            return model;
        }

        public Observacao ObterPorId(int id)
        {
            return _uow.RepositorioObservacao.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Observacao model)
        {
            if (model.Codigo <= 0)
                _uow.Notificacao.Add("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            _uow.RepositorioObservacao.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioObservacao.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
