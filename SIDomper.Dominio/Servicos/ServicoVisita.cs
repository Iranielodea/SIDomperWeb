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

namespace SIDomper.Dominio.Servicos
{
    public class ServicoVisita : IServicoVisita
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<VisitaConsultaViewModelApi> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;
        List<string> _listaEmail;
        List<string> _listaEmailCliente;

        public ServicoVisita(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<VisitaConsultaViewModelApi> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Visita;
            _listaEmail = new List<string>();
            _listaEmailCliente = new List<string>();
        }

        public Visita Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public IEnumerable<VisitaConsultaViewModelApi> Filtrar(int idUsuario, VisitaFiltroViewModelApi filtro, string campo, string valor)
        {
            var sb = new StringBuilder();

            sb.AppendLine(MontarSql(idUsuario, campo, valor));

            if (filtro.Id > 0)
                sb.AppendLine(" AND Vis_Id = " + filtro.Id);

            if (!string.IsNullOrWhiteSpace(filtro.Perfil))
                sb.AppendLine(" AND Cli_Perfil = '" + filtro.Perfil + "'");

            if (!Funcoes.Utils.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Vis_Data >= '" + filtro.DataInicial + "'");

            if (!Funcoes.Utils.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Vis_Data <= '" + filtro.DataFinal + "'");

            if (!string.IsNullOrWhiteSpace(filtro.ClienteId))
                sb.AppendLine(" AND Vis_Cliente IN (" + filtro.ClienteId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.RevendaId))
                sb.AppendLine(" AND Cli_Revenda IN (" + filtro.RevendaId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.StatusId))
                sb.AppendLine(" AND Vis_Status IN (" + filtro.StatusId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.TipoId))
                sb.AppendLine(" AND Vis_Tipo IN (" + filtro.TipoId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.UsuarioId))
                sb.AppendLine(" AND Vis_Usuario IN (" + filtro.UsuarioId + ")");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        private string MontarSql(int idUsuario, string campo, string valor)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Vis_Id as Id");
            //sb.AppendLine(",'' as Data");
            //sb.AppendLine(",Vis_Data as DataD");
            sb.AppendLine(",Vis_Data as Data");
            sb.AppendLine(",Vis_Dcto as Documento");
            sb.AppendLine(",Cli_Nome as NomeCliente");
            sb.AppendLine(",Cli_Fantasia as NomeFantasia");
            sb.AppendLine(",Usu_Nome as NomeConsultor");
            sb.AppendLine(",Vis_Dcto as Documento");

            sb.AppendLine(" FROM Visita");
            sb.AppendLine(" INNER JOIN Cliente ON Vis_Cliente = Cli_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Vis_Usuario = Usu_Id");
            sb.AppendLine(" WHERE " + campo + " LIKE'%" + valor + "%'");

            return sb.ToString();
        }

        public Visita Novo(int idUsuario, int idClienteAgendamento)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
            var model = new Visita
            {
                Data = DateTime.Now.Date
            };

            var status = _uow.RepositorioStatus.ObterPorPrograma(EnStatus.Visita).FirstOrDefault();
            if (status != null)
                model.Status = status;

            if (idClienteAgendamento > 0)
            {
                var cliente = _uow.RepositorioCliente.find(idClienteAgendamento);
                if (cliente != null)
                    model.Cliente = cliente;
            }

            model.Usuario = _uow.RepositorioUsuario.find(idUsuario);

            if (!_uow.RepositorioUsuario.HorarioUsoSistema("", "", idUsuario))
                throw new Exception("Horário não disponível para lançamento de visita");

            return model;
        }

        public Visita ObterPorId(int id)
        {
            return _uow.RepositorioVisita.find(id);
        }

        public void Salvar(Visita model, int usuarioId)
        {
            if (model.HoraInicio > model.HoraFim)
                throw new Exception("Hora Inicial maior que Hora Final!");

            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo");

            double HoraInicio = Funcoes.Utils.HoraToDecimal(model.HoraInicio.ToString());
            double HoraFim = Funcoes.Utils.HoraToDecimal(model.HoraFim.ToString());
            int id = model.Id;

            model.TotalHoras = HoraFim - HoraInicio;

            _uow.RepositorioVisita.Salvar(model);
            AtualizarVersaoCliente(model);
            _uow.SaveChanges();

            if (id == 0)
            {
                model = ObterPorId(model.Id);
                EnviarEmailVisita(model, usuarioId);
            }
        }

        public void EnviarEmailVisita(Visita model, int usuarioId)
        {
            string emailOculto = BuscarEmail(model, usuarioId);
            string emailCliente = RetornarEmailCliente(usuarioId, model);

            if (string.IsNullOrEmpty(emailCliente))
                emailCliente = emailOculto;

            if (!string.IsNullOrEmpty(emailCliente))
            {
                string assunto = RetornarAssunto(model.Id);
                string texto = TextoEmail(model);

                _uow.RepositorioContaEmail.EnviarEmail(usuarioId, emailCliente, emailOculto, assunto, texto, "");
            }
        }

        private string TextoEmail(Visita visita)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Caro(a) : " + visita.Cliente.Nome + ", seguem abaixo informações referente à visita realizada pela Domper Consultoria e Sistemas:");
            sb.AppendLine("");
            sb.AppendLine("Nº Visita : " + visita.Id.ToString("000000"));
            sb.AppendLine("Data : " + visita.Data.ToShortDateString() + " - Hora Inicial : " + visita.HoraInicio.ToString() + " - Hora Final : " + visita.HoraFim.ToString());
            sb.AppendLine("Documento : " + visita.Dcto);
            sb.AppendLine("Consultor : " + visita.Usuario.Nome);
            sb.AppendLine("Tipo : " + visita.Tipo.Nome);
            sb.AppendLine("Status : " + visita.Status.Nome);
            sb.AppendLine("Contato : " + visita.Contato);
            sb.AppendLine("Descrição : " + visita.Descricao);
            sb.AppendLine("Valor : " + visita.Valor.ToString("N2"));
            sb.AppendLine("Forma de Pagamento : " + visita.FormaPagto);
            sb.AppendLine("");
            sb.AppendLine(MensagemFinal());

            return sb.ToString();
        }

        private string MensagemFinal()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Esta mensagem é automática e foi gerada pelo Sistema Interno Domper.");
            sb.AppendLine("Caso o que foi relatado não esteja em conformidade com o que foi realizado, favor entrar em contato com o seu consultor.");

            return sb.ToString();
        }

        private string RetornarAssunto(int id)
        {
            return "Visita: " + id.ToString("000000") + " Domper Consultoria e Sistemas Ltda.";
        }

        public string RetornarEmailCliente(int usuarioId, Visita visita)
        {
            string emailConta = RetornarEmailConta(usuarioId);
            if (string.IsNullOrWhiteSpace(emailConta))
                return "";

            var status = _uow.RepositorioStatus.find(visita.StatusId);
            if (status.NotificarCliente == false)
                return "";

            var listaEmail = visita.Cliente.Emails.Where(x => x.Notificar);

            int contador = 0;

            if (listaEmail != null)
            {
                foreach (var item in listaEmail)
                {
                    AdicionarEmailCliente(item.Email);
                    contador++;
                }
            }

            if (contador == 0)
                AdicionarEmailCliente(emailConta);

            return RetornaListaEmail(_listaEmailCliente);
        }

        private void AdicionarEmailCliente(string email)
        {
            if (!_listaEmailCliente.Contains(email))
                _listaEmailCliente.Add(email);
        }

        private string BuscarEmail(Visita model, int usuarioId)
        {
            if (TemContaEmail(usuarioId))
            {
                RetornarEmailSupervisor(usuarioId, model);
                RetornarEmailConsultor(usuarioId, model);
                RetornarEmailRevenda(usuarioId, model);
            }

            return RetornaListaEmail(_listaEmail);
        }

        private string RetornaListaEmail(List<string> lista)
        {
            string sReturn = "";

            foreach (var item in lista)
            {
                if (sReturn == "")
                    sReturn = item;
                else
                    sReturn = sReturn + ";" + item;
            }
            return sReturn;
        }

        private void RetornarEmailRevenda(int usuarioId, Visita visita)
        {
            var notificar = _uow.RepositorioStatus.NotificarRevenda(visita.StatusId);

            if (notificar)
            {
                if (visita.Cliente == null)
                    return;

                if (visita.Cliente.Revenda == null)
                    return;

                foreach (var item in visita.Cliente.Revenda.RevendaEmails)
                {
                    Adicionar(item.Email);
                }
            }
        }

        private void RetornarEmailConsultor(int usuarioId, Visita visita)
        {
            var notificar = _uow.RepositorioStatus.NotificarConsultor(visita.StatusId);

            if (notificar)
            {
                if (visita.Cliente == null)
                {
                    visita.Cliente = _uow.RepositorioCliente.find(visita.ClienteId);

                    if (visita.Cliente == null)
                        return;
                }

                int idUsuario = 0;
                if (visita.Cliente.UsuarioId != null)
                    idUsuario = Convert.ToInt32(visita.Cliente.UsuarioId);

                var email = _uow.RepositorioUsuario.find(idUsuario);

                if (!string.IsNullOrEmpty(email.Email))
                {
                    Adicionar(email.Email);
                }
            }
        }

        private void RetornarEmailSupervisor(int usuarioId, Visita visita)
        {
            var notificar = _uow.RepositorioStatus.NotificarSupervisor(visita.StatusId);

            if (notificar)
            {
                foreach (var item in visita.Usuario.Departamento.DepartamentosEmail)
                {
                    Adicionar(item.Email);
                }
            }
        }

        private void Adicionar(string email)
        {
            if (!_listaEmail.Contains(email))
            {
                _listaEmail.Add(email);
            }
        }

        private bool TemContaEmail(int usuarioId)
        {
            string resultado = RetornarEmailConta(usuarioId);

            if (string.IsNullOrEmpty(resultado))
                return false;
            else
                return true;
        }

        private string RetornarEmailConta(int usuarioId)
        {
            var usuario = _uow.RepositorioUsuario.find(usuarioId);

            string sRetorno = "";
            if (usuario.ContaEmail != null)
                sRetorno = usuario.ContaEmail.Email;

            return sRetorno;
        }

        private void AtualizarVersaoCliente(Visita visita)
        {
            var modelTipo = _uow.RepositorioTipo.find(visita.TipoId);

            if (modelTipo != null)
            {
                bool resultado = TipoObrigatorio(modelTipo.Codigo);

                if (resultado == true && string.IsNullOrWhiteSpace(visita.Versao))
                    throw new Exception("Informe a Versão");
            }

            if (!string.IsNullOrWhiteSpace(visita.Versao))
            {
                var modelCliente = _uow.RepositorioCliente.find(visita.ClienteId);

                if (modelCliente != null)
                {
                    modelCliente.Versao = visita.Versao;
                    _uow.RepositorioCliente.Salvar(modelCliente);
                }
            }
        }

        private bool TipoObrigatorio(int codigoTipo)
        {
            bool resultado = false;

            if (codigoTipo > 0)
            {
                var parametro = _uow.RepositorioParametro.ObterPorParametro(51, 0);
                if (parametro.Codigo > 0)
                {
                    if (codigoTipo.ToString() == parametro.Valor)
                        resultado = true;
                }
            }
            return resultado;
        }

        public void Excluir(Visita model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioVisita.Deletar(model);
            _uow.SaveChanges();
        }
    }
}
