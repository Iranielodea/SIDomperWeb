using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoRecado : IServicoRecado
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<RecadoConsultaViewModel> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoRecado(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<RecadoConsultaViewModel> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas. Recado;
        }

        public Recado Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Recado model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioRecado.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<RecadoConsultaViewModel> Filtrar(RecadoFiltroViewModel filtro)
        {
            string sTexto;
            sTexto = "'" + filtro.Texto + "%'";
            if (filtro.Contem)
                sTexto = "'%" + filtro.Texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine(" Rec_Id as Id,");
            sb.AppendLine(" Rec_Data as Data,");
            sb.AppendLine(" Rec_Nivel as Nivel,");
            sb.AppendLine(" Rec_RazaoSocial as RazaoSocial,");
            sb.AppendLine(" Rec_Telefone as Telefone,");
            sb.AppendLine(" Lcto.Usu_Nome as NomeUsuarioLancamento,");
            sb.AppendLine(" Dest.Usu_Nome as NomeUsuarioDestino,");
            sb.AppendLine(" Sta_Nome as NomeStatus");
            sb.AppendLine(" FROM Recado");
            sb.AppendLine(" INNER JOIN Usuario Lcto ON Rec_UsuarioLcto = Lcto.Usu_Id");
            sb.AppendLine(" LEFT JOIN Usuario Dest ON Rec_UsuarioDestino = Dest.Usu_Id");
            sb.AppendLine(" LEFT JOIN Status ON Rec_Status = Sta_Id");

            if (!string.IsNullOrEmpty(filtro.Texto))
            {
                if (filtro.Campo == "Rec_Data")
                    sb.AppendLine(" WHERE " + filtro.Campo + " = '" + filtro.Texto + "'");
                else
                    sb.AppendLine(" WHERE " + filtro.Campo + " LIKE " + sTexto);
            }
            else
            {
                sb.AppendLine(" WHERE Rec_Id > 0");
            }

            if (!Funcoes.Utils.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Rec_Data >= " + Funcoes.Utils.DataIngles(filtro.DataInicial));
            if (!Funcoes.Utils.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Rec_Data <= " + Funcoes.Utils.DataIngles(filtro.DataFinal));

            if (!Funcoes.Utils.DataEmBranco(filtro.DataInicialDest))
                sb.AppendLine(" AND Rec_DataFinal >= " + Funcoes.Utils.DataIngles(filtro.DataInicialDest));
            if (!Funcoes.Utils.DataEmBranco(filtro.DataFinalDest))
                sb.AppendLine(" AND Rec_DataFinal <= " + Funcoes.Utils.DataIngles(filtro.DataFinalDest));

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioLcto))
                sb.AppendLine(" AND Rec_UsuarioLcto in " + filtro.IdUsuarioLcto);

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioDestino))
                sb.AppendLine(" AND Rec_UsuarioDestino in " + filtro.IdUsuarioDestino);

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Rec_Status in " + filtro.IdStatus);

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Rec_Cliente in " + filtro.IdCliente);

            try
            {
                return _repositoryReadOnly.GetAll(sb.ToString());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Recado Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var parametro = _uow.RepositorioParametro.ObterPorParametro(43, 0);

            int.TryParse(parametro.Valor, out int codigoStatus);

            var model = new Recado
            {
                Data = DateTime.Now.Date,
                Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString()),
                Nivel = 2,

                UsuarioLcto = _uow.RepositorioUsuario.find(idUsuario),
                Status = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatus),
                Tipo = _uow.RepositorioTipo.RetornarUmRegistroPrograma(EnTipos.Recado)
            };

            return model;
        }

        public Recado ObterPorId(int id)
        {
            return _uow.RepositorioRecado.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Recado model)
        {
            Validar(model);
            _uow.RepositorioRecado.Salvar(model);
            _uow.SaveChanges();

            // TODO: tirar o comentario
            EnviarEmailAoSalvar(model);
        }

        private void EnviarEmail(int idUsuarioOrigem, int idUsuarioDestino, int id)
        {
            if (id == 0 || idUsuarioOrigem == 0 || idUsuarioDestino == 0)
                return;

            string assunto = "Domper Recado - " + id.ToString("000000");

            var usuario = _uow.RepositorioUsuario.find(idUsuarioDestino);
            string email = usuario.Email;

            if (!string.IsNullOrWhiteSpace(email))
            {
                var model = ObterPorId(id);
                if (model != null)
                    _uow.RepositorioContaEmail.EnviarEmail(idUsuarioOrigem, email, "", assunto, TextoEmail(model), "");
            }
        }

        private string TextoEmail(Recado model)
        {
            string ModoAbrEnc = "E";
            string status = " (Encerrado)";

            if (string.IsNullOrWhiteSpace(model.DescricaoFinal))
            {
                ModoAbrEnc = "A";
                status = " (Aberto)";
            }

            if (model.Cliente == null)
                model.Cliente = _uow.RepositorioCliente.find(model.ClienteId);
            if (model.Tipo == null)
                model.Tipo = _uow.RepositorioTipo.find(model.TipoId);
            if (model.Status == null)
                model.Status = _uow.RepositorioStatus.find(model.StatusId);
            if (model.UsuarioDestino == null)
                model.UsuarioDestino = _uow.RepositorioUsuario.find(model.UsuarioDestinoId);
            if (model.UsuarioLcto == null)
                model.UsuarioLcto = _uow.RepositorioUsuario.find(model.UsuarioLctoId);

            var sb = new StringBuilder();
            sb.AppendLine("Recado Sistema Domper: " + status);
            sb.AppendLine("Id: " + model.Id.ToString("000000"));
            sb.AppendLine("Data: " + model.Data.ToString() + " Hora: " + model.Hora.ToString());
            sb.AppendLine("Usuário Lcto: " + model.UsuarioLcto.Nome);
            sb.AppendLine("Nínvel: " + model.Nivel.ToString());
            sb.AppendLine("Razão Social: " + model.Cliente.Nome);
            sb.AppendLine("Endereco: " + model.Cliente.Endereco);
            sb.AppendLine("Telefone: " + model.Cliente.Telefone);
            sb.AppendLine("Contato: " + model.Contato);
            sb.AppendLine("Usuário Destino: " + model.UsuarioDestino.Nome);
            sb.AppendLine("Tipo: " + model.Tipo.Nome);
            sb.AppendLine("Status: " + model.Status.Nome);
            sb.AppendLine("Descrição:");
            sb.AppendLine(model.DescricaoInicial);

            if (ModoAbrEnc == "E")
                sb.AppendLine("Descrição Encerramento: " + model.DescricaoFinal);

            return sb.ToString();
        }

        private void Validar(Recado model)
        {
            if (string.IsNullOrEmpty(model.RazaoSocial))
                _uow.Notificacao.Add("Informe a Razão Social!");

            if (model.TipoId == 0)
                _uow.Notificacao.Add("Informe o Tipo!");

            if (model.UsuarioLctoId == 0)
                _uow.Notificacao.Add("Informe o Usuário Lançamento!");

            if (model.UsuarioDestinoId == 0)
                _uow.Notificacao.Add("Informe o Usuário Destino!");

            if (model.StatusId == 0)
                _uow.Notificacao.Add("Informe o Status!");

            if (string.IsNullOrEmpty(model.DescricaoInicial))
                _uow.Notificacao.Add("Informe a Descrição Inicial!");

            if (!string.IsNullOrEmpty(model.DescricaoInicial))
            {
                if (model.Data > model.DataFinal)
                    _uow.Notificacao.Add("Data do Lançamento maior que Data do Encerramento!");

                var parametro = _uow.RepositorioParametro.ObterPorParametro(44, 0);
                if (parametro == null || string.IsNullOrEmpty(parametro.Valor))
                    _uow.Notificacao.Add("Informe o Status de Enceramento dos Recados nos parâmetros do Sistema!");

                if (model.ModoAbrEnc == "E" && string.IsNullOrEmpty(model.DescricaoFinal))
                    _uow.Notificacao.Add("Informe a Descrição Final!");

                if (!_uow.IsValid())
                    throw new Exception(_uow.RetornoNotificacao());

                if (model.ModoAbrEnc == "E")
                {
                    int.TryParse(parametro.Valor, out int codigoStatus);
                    var status = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatus);
                    if (status != null)
                        model.StatusId = status.Id;
                }
            }
        }

        private void EnviarEmailAoSalvar(Recado model)
        {
            if (string.IsNullOrEmpty(model.ModoAbrEnc))
            {
                if (string.IsNullOrEmpty(model.DescricaoFinal))
                    model.ModoAbrEnc = "A";
                else
                    model.ModoAbrEnc = "E";
            }

            if (model.ModoAbrEnc == "A")
                EnviarEmail(model.UsuarioLctoId, model.UsuarioDestinoId, model.Id);
            else
                EnviarEmail(model.UsuarioDestinoId, model.UsuarioLctoId, model.Id);
        }
    }
}
