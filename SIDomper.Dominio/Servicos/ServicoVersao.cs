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
    public class ServicoVersao : IServicoVersao
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<VersaoConsultaViewModel> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoVersao(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<VersaoConsultaViewModel> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Versao;
        }

        public Versao Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Versao model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioVersao.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<VersaoConsultaViewModel> Filtrar(VersaoFiltroViewModel filtro, string campo, string texto, bool contem)
        {
            string consulta = " SELECT"
                + "  Ver_DataInicio as DataInicio,"
                + "  Ver_DataLiberacao as DataLiberacao,"
                + "  Ver_Descricao as Descricao,"
                + "  Ver_Id as Id,"
                + "  Ver_Versao as VersaoStr,"
                + "  Sta_Nome as NomeStatus,"
                + "  Tip_Nome as NomeTipo,"
                + "  Usu_Nome as NomeUsuario"
                + " FROM Versao"
                + " 	INNER JOIN Status ON Ver_Status = Sta_Id"
                + " 	INNER JOIN Tipo ON Ver_Tipo = Tip_Id"
                + " 	INNER JOIN Usuario ON Ver_Usuario = Usu_Id";

            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine(consulta);

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Ver_Id > 0");
            }

            if (filtro.Id > 0)
                sb.AppendLine(" AND Ver_Id = " + filtro.Id);

            if (!Funcoes.Utils.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Ver_DataInicio >= " + Funcoes.Utils.DataIngles(filtro.DataInicial));
            if (!Funcoes.Utils.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Ver_DataInicio <= " + Funcoes.Utils.DataIngles(filtro.DataFinal));

            if (!Funcoes.Utils.DataEmBranco(filtro.DataLiberacaoInicial))
                sb.AppendLine(" AND Ver_DataLiberacao >= " + Funcoes.Utils.DataIngles(filtro.DataLiberacaoInicial));
            if (!Funcoes.Utils.DataEmBranco(filtro.DataLiberacaoFinal))
                sb.AppendLine(" AND Ver_DataLiberacao <= " + Funcoes.Utils.DataIngles(filtro.DataLiberacaoFinal));

            if (!string.IsNullOrWhiteSpace(filtro.UsuarioId))
                sb.AppendLine(" AND Ver_Usuario IN (" + filtro.UsuarioId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.StatusId))
                sb.AppendLine(" AND Ver_Status IN (" + filtro.StatusId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.TipoId))
                sb.AppendLine(" AND Ver_Tipo IN (" + filtro.TipoId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.ProdutoId))
                sb.AppendLine(" AND Ver_Produto IN (" + filtro.ProdutoId + ")");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Versao Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var model = new Versao();
            model.Usuario = _uow.RepositorioUsuario.find(idUsuario);

            var observacao = _uow.RepositorioObservacao.ObterPadrao((int)EnProgramas.Versao);
            if (observacao != null)
                model.Descricao = observacao.Descricao;

            model.Tipo = _uow.RepositorioTipo.RetornarUmRegistroPrograma(EnTipos.Versao);

            return model;
        }

        public Versao ObterPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }

        public Versao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Relatorio(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Versao model)
        {
            throw new NotImplementedException();
        }
    }
}
