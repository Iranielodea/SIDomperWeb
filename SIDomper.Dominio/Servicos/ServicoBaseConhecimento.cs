using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoBaseConhecimento : IServicoBaseConhecimento
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<BaseConhConsultaViewModel> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoBaseConhecimento(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<BaseConhConsultaViewModel> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.BaseConh;
        }

        public BaseConhecimento Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(BaseConhecimento model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioBaseConhecimento.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<BaseConhConsultaViewModel> Filtrar(BaseConhecimentoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Bas_Id as Id, ");
            sb.AppendLine(" Bas_Data as Data, ");
            sb.AppendLine(" Bas_Nome as Nome, ");
            sb.AppendLine(" Usu_Nome as NomeUsuario, ");
            sb.AppendLine(" Tip_Nome as NomeTipo, ");
            sb.AppendLine(" Sta_Nome as NomeStatus ");
            sb.AppendLine(" FROM Base");
            sb.AppendLine(" INNER JOIN Usuario ON Bas_Usuario = Usu_id");
            sb.AppendLine(" INNER JOIN Tipo ON Bas_Tipo = Tip_id");
            sb.AppendLine(" INNER JOIN Status ON Bas_Status = Sta_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine(" WHERE Bas_Id > 0");

            if (!Funcoes.Utils.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Bas_Data >= " + Funcoes.Utils.DataIngles(filtro.DataInicial));

            if (!Funcoes.Utils.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Bas_Data <= " + Funcoes.Utils.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.ModuloId))
                sb.AppendLine(" AND Bas_Modulo IN (" + filtro.ModuloId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.ProdutoId))
                sb.AppendLine(" AND Bas_Produto IN (" + filtro.ModuloId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.StatusId))
                sb.AppendLine(" AND Bas_Status IN (" + filtro.StatusId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.TipoId))
                sb.AppendLine(" AND Bas_Tipo IN (" + filtro.TipoId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.UsuarioId))
                sb.AppendLine(" AND Bas_Usuario IN (" + filtro.UsuarioId + ")");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public BaseConhecimento Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var model = new BaseConhecimento
            {
                Usuario = _uow.RepositorioUsuario.find(idUsuario)
            };
            model.UsuarioId = model.Usuario.Id;
            model.Data = DateTime.Now.Date;

            var obs = _uow.RepositorioObservacao.ObterPadrao((int)EnTipos.BaseConhecimento);
            if (obs != null)
                model.Descricao = obs.Descricao;

            var modelTipo = _uow.RepositorioTipo.RetornarUmRegistroPrograma(EnTipos.BaseConhecimento);
            if (modelTipo != null)
                model.Tipo = modelTipo;

            return model;
        }

        public BaseConhecimento ObterPorId(int id)
        {
            return _uow.RepositorioBaseConhecimento.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(BaseConhecimento model)
        {
            if (Funcoes.Utils.DataEmBranco(model.Data.ToShortDateString()))
               _uow.Notificacao.Add("Informe a Data!");

            if (model.UsuarioId == 0)
                _uow.Notificacao.Add("Informe o Consultor!");

            if (string.IsNullOrWhiteSpace(model.Descricao))
                _uow.Notificacao.Add("Informe a Descrição!");

            if (model.StatusId == 0)
                _uow.Notificacao.Add("Informe o Status!");

            if (model.TipoId == 0)
                _uow.Notificacao.Add("Informe o Tipo!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            _uow.RepositorioBaseConhecimento.Salvar(model);
            _uow.SaveChanges();
        }
    }
}
