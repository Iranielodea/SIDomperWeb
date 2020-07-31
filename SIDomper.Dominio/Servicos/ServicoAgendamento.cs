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
    public class ServicoAgendamento : IServicoAgendamento
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<AgendamentoConsultaViewModel> _repositoryReadOnly;
        private readonly IRepositoryReadOnly<AgendamentoQuadroViewModel> _repositorioReadOnlyQuadro;
        private readonly EnProgramas _enProgramas;
        List<string> _listaEmailCliente;
        List<string> _listaEmail;

        public ServicoAgendamento(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<AgendamentoConsultaViewModel> repositoryReadOnly,
           IRepositoryReadOnly<AgendamentoQuadroViewModel> repositorioReadOnlyQuadro)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _repositorioReadOnlyQuadro = repositorioReadOnlyQuadro;
            _enProgramas = EnProgramas.Agendamento;
            _listaEmailCliente = new List<string>();
            _listaEmail = new List<string>();
        }

        public void Cancelamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            var status = RetornarStatusParametro(34);
            if (status == null)
                return;

            var model = ObterPorId(idAgendamento);

            if (model.UsuarioId == idUsuario)
                throw new Exception("Para cancelar, somente o mesmo usuário da Abertura!");

            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(model.Motivo))
                sb.AppendLine(model.Motivo);

            sb.AppendLine(model.Status.Nome + " - ");
            sb.Append(model.Data.ToShortDateString() + "- ");
            sb.Append(model.Hora.ToString("hh:mm"));

            model.Motivo = sb.ToString();
            model.Hora = TimeSpan.Parse(hora);
            model.Data = Convert.ToDateTime(data);
            model.StatusId = status.Id;

            Salvar(model);
        }

        public Agendamento Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Encerramento(int idUsuario, int idAgenda, int idPrograma)
        {
            var status = RetornarStatusParametro(36);
            if (status == null)
                return;

            var model = ObterPorId(idAgenda);

            if (idPrograma == 0)
            {
                if (model.UsuarioId == idUsuario)
                    throw new Exception("Para Encerrar, somente o mesmo usuário da Abertura!");
            }

            if (idPrograma > 0)
            {
                if (model.Programa == 2) // visita
                {
                    model.VisitaId = idPrograma;
                    model.StatusId = status.Id;
                }

                if (model.Programa == 7) // atividade
                {
                    model.AtividadeId = idPrograma;
                    model.StatusId = status.Id;
                }
                Salvar(model);
            }
        }

        public void EncerramentoWEB(int idUsuario, int idAgenda)
        {
            var status = RetornarStatusParametro(36);
            if (status == null)
                return;

            var model = ObterPorId(idAgenda);

            if (model.UsuarioId == idUsuario)
                throw new Exception("Para encerrar, somente o mesmo usuário da Abertura!");

            if (model.StatusId == status.Id)
                throw new Exception("Agendamento já encerrado!");

            model.StatusId = status.Id;
            Salvar(model);
        }

        public void Excluir(Agendamento model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioAgendamento.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<AgendamentoConsultaViewModel> Filtrar(AgendamentoFiltroViewModel filtro, string campo, string texto, int idUsuario, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            var usuarioPermissao = _uow.RepositorioUsuario.PermissaoUsuario(idUsuario);

            sb.AppendLine(" SELECT");
            sb.AppendLine(" Age_Id as Id,");
            sb.AppendLine("	Age_Data as Data,");
            sb.AppendLine("	Age_Hora as Hora,");
            sb.AppendLine(" Age_Cliente as ClienteId,");
            sb.AppendLine(" Age_NomeCliente as NomeCliente,");
            sb.AppendLine(" Tip_Nome as TipoNome,");
            sb.AppendLine(" Usu_Nome as UsuarioNome,");
            sb.AppendLine(" Sta_Nome as StatusNome");
            sb.AppendLine(" FROM Agendamento");
            sb.AppendLine("     INNER JOIN Cliente ON Age_Cliente = Cli_Id");
            sb.AppendLine(" 	INNER JOIN Tipo ON Age_Tipo = Tip_Id");
            sb.AppendLine(" 	INNER JOIN Usuario ON Age_Usuario = Usu_Id");
            sb.AppendLine(" 	INNER JOIN Status ON Age_Status = Status.Sta_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Age_Id > 0");
            }

            sb.AppendLine(usuarioPermissao);

            if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (!Funcoes.Utils.DataEmBranco(filtro.DataInicial)))
                sb.AppendLine(" AND Age_Data >=" + Funcoes.Utils.DataIngles(filtro.DataInicial));

            if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (!Funcoes.Utils.DataEmBranco(filtro.DataFinal)))
                sb.AppendLine(" AND Age_Data <=" + Funcoes.Utils.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Age_Cliente IN (" + filtro.IdCliente + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdTipo))
                sb.AppendLine(" AND Age_Tipo IN (" + filtro.IdTipo + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Age_Status IN (" + filtro.IdStatus + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuario))
                sb.AppendLine(" AND Age_Usuario IN (" + filtro.IdUsuario + ")");

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Agendamento Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
            // TODO: tirar este comentario
            //if (VerificarAgendamentoAberto(idUsuario))
            //    throw new Exception("Há Agendamentos em Aberto!");

            int codigoStatus = StatusAbertura();
            var model = new Agendamento
            {
                Programa = 2,
                Data = DateTime.Now.Date,
                Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString()),
                Usuario = _uow.RepositorioUsuario.find(idUsuario),
                Tipo = _uow.RepositorioTipo.RetornarTipoAgendamento(),
                Status = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatus)
            };

            return model;
        }

        private bool VerificarAgendamentoAberto(int idUsuario)
        {
            string codigo = AgendamentoEnderrado();

            int idStatusCancelado = 0;
            int idStatusEncerrado = 0;

            var model = _uow.RepositorioStatus.First(x => x.Codigo == int.Parse(codigo));
            if (model != null)
                idStatusEncerrado = model.Id;

            codigo = AgendamentoCancelado();
            model = _uow.RepositorioStatus.First(x => x.Codigo == int.Parse(codigo));
            if (model != null)
                idStatusCancelado = model.Id;

            return _uow.RepositorioAgendamento.VerificarAgendamentoAberto(idUsuario, idStatusEncerrado, idStatusCancelado);
        }

        private int StatusAbertura()
        {
            var parametroModel = _uow.RepositorioParametro.ObterPorParametro(33, 112);

            if (parametroModel != null)
                return int.Parse(parametroModel.Valor);
            else
                return 0;
        }

        public Agendamento ObterPorId(int id)
        {
            return _uow.RepositorioAgendamento.find(id);
        }

        public IEnumerable<AgendamentoQuadroViewModel> Quadros(string dataInicial, string dataFinal, int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("	Age_Id as Id,");
            sb.AppendLine("	Age_Data as Data,");
            sb.AppendLine("	Age_Hora as Hora,");
            sb.AppendLine("  Age_Cliente as ClienteId,");
            sb.AppendLine("	Age_NomeCliente as ClienteNome,");
            sb.AppendLine("	Usu_Nome as UsuarioNome,");
            sb.AppendLine("	Sta_Nome as StatusNome");
            sb.AppendLine(" FROM Agendamento");
            sb.AppendLine(" INNER JOIN Cliente ON  Age_Cliente = Cli_Id");
            sb.AppendLine(" INNER JOIN Usuario ON Age_Usuario = Usu_Id");
            sb.AppendLine(" INNER JOIN Status ON Age_Status = Sta_Id");
            sb.AppendLine(" WHERE Age_Data >=" + Funcoes.Utils.DataIngles(dataInicial));
            sb.AppendLine(" AND Age_Data <=" + Funcoes.Utils.DataIngles(dataFinal));

            if (idRevenda > 0)
                sb.AppendLine(" AND Cli_Revenda = " + idRevenda);

            sb.AppendLine(_uow.RepositorioUsuario.PermissaoUsuario((idUsuario)));

            sb.AppendLine(" ORDER BY Age_Data");

            return _repositorioReadOnlyQuadro.GetAll(sb.ToString());
        }

        public void Reagendamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            var model = ObterPorId(idAgendamento);

            if (model.UsuarioId != idUsuario)
                throw new Exception("Para Reagendar, somente o mesmo usuário da Abertura!");

            var status = RetornarStatusParametro(35);
            if (status == null)
                throw new Exception("Informe o Status de Reagendamento código 35 nos Parâmetros!");

            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(model.Motivo))
                sb.AppendLine(model.Motivo);

            sb.AppendLine(model.Status.Nome + " - ");
            sb.Append(model.Data.ToShortDateString() + "- ");
            sb.Append(model.Hora.ToString("hh:mm"));

            model.Motivo = sb.ToString();
            model.Hora = TimeSpan.Parse(hora);
            model.Data = Convert.ToDateTime(data);
            model.StatusId = status.Id;

            Salvar(model);
        }

        private Status RetornarStatusParametro(int codigo)
        {
            var parametro = _uow.RepositorioParametro.ObterPorParametro(codigo, 0);
            if (parametro == null)
                return null;

            return _uow.RepositorioStatus.First(x => x.Codigo == Convert.ToInt32(parametro.Valor));
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Agendamento model)
        {
            ValidarAgendamento(model);
            _uow.RepositorioAgendamento.Salvar(model);
            _uow.SaveChanges();
        }

        private void ValidarAgendamento(Agendamento model)
        {
            if (model.Data == null)
                _uow.Notificacao.Add("Informe a Data!");
            if (model.Hora == null)
                _uow.Notificacao.Add("Informe a Hora!");
            if (model.UsuarioId == 0)
                _uow.Notificacao.Add("Informe o Usuário!");
            if (model.ClienteId == 0)
                _uow.Notificacao.Add("Informe o Cliente!");
            if (model.TipoId == 0)
                _uow.Notificacao.Add("Informe o Tipo!");
            if (model.StatusId == 0)
                _uow.Notificacao.Add("Informe o Status!");
            if (string.IsNullOrWhiteSpace(model.Descricao))
                _uow.Notificacao.Add("Informe a Descrição!");

            if (model.Id == 0)
            {
                if (model.Data == DateTime.Now.Date)
                {
                    if (model.Hora < TimeSpan.Parse(DateTime.Now.ToShortTimeString()))
                        _uow.Notificacao.Add("Não será possível agendar para este horário!");
                }
            }

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());
        }

        public void Salvar(Agendamento model, int usuarioId)
        {
            int id = model.Id;
            Salvar(model);

            if (id == 0)
            {
                //TODO: tirar comentario
                EnviarEmailAgendamento(model, usuarioId);
            }
        }

        public string AgendamentoCancelado()
        {
            var parametroModel = _uow.RepositorioParametro.ObterPorParametro(34, 112);
            if (parametroModel != null)
                return parametroModel.Valor;
            else
                return "";
        }

        public string AgendamentoEnderrado()
        {
            var parametroModel = _uow.RepositorioParametro.ObterPorParametro(36, 0);

            if (parametroModel != null)
                return parametroModel.Valor;
            else
                return "";
        }

        int IServicoAgendamento.StatusAbertura()
        {
            var parametroModel = _uow.RepositorioParametro.ObterPorParametro(33, 112);

            if (parametroModel != null)
                return int.Parse(parametroModel.Valor);
            else
                return 0;
        }

        public void EnviarEmailAgendamento(Agendamento model, int usuarioId)
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

        private string TextoEmail(Agendamento agendamento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Caro(a) : " + agendamento.Cliente.Nome + ", seguem abaixo informações referente ao agendamento da Domper Consultoria e Sistemas:");
            sb.AppendLine("");
            sb.AppendLine("Nº Agendamento : " + agendamento.Id.ToString("000000"));
            sb.AppendLine("Data : " + agendamento.Data.ToShortDateString() + " - Hora Inicial : " + agendamento.Hora.ToString());
            sb.AppendLine("Usuário : " + agendamento.Usuario.Nome);
            sb.AppendLine("Contato : " + agendamento.Contato);
            sb.AppendLine("Tipo : " + agendamento.Tipo.Nome);
            sb.AppendLine("Status : " + agendamento.Status.Nome);
            sb.AppendLine("Descrição : " + agendamento.Descricao);
            sb.AppendLine("");
            sb.AppendLine(MensagemFinal());

            return sb.ToString();
        }

        private string MensagemFinal()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Colocamo-nos a disposição para maiores esclarecimentos.");
            sb.AppendLine("");
            sb.AppendLine("Equipe Domper");
            sb.AppendLine("");

            sb.AppendLine("Esta mensagem é automática e foi gerada pelo Sistema Interno de Agendamentos Domper.");
            sb.AppendLine("Por favor não responda este email.");

            return sb.ToString();
        }

        private string RetornarAssunto(int id)
        {
            return "Agendamento: " + id.ToString("000000") + " Domper Consultoria e Sistemas Ltda.";
        }

        private string BuscarEmail(Agendamento model, int usuarioId)
        {
            if (TemContaEmail(usuarioId))
            {
                RetornarEmailSupervisor(usuarioId, model);
                RetornarEmailConsultor(usuarioId, model);
                RetornarEmailRevenda(usuarioId, model);
            }

            return RetornaListaEmail(_listaEmail);
        }

        private void RetornarEmailRevenda(int usuarioId, Agendamento agendamento)
        {
            var notificar =_uow.RepositorioStatus.NotificarRevenda(agendamento.StatusId);

            if (notificar)
            {
                if (agendamento.Cliente == null)
                    return;

                if (agendamento.Cliente.Revenda == null)
                    return;

                var revenda = _uow.RepositorioRevenda.find(agendamento.Cliente.Revenda.Id);

                foreach (var item in revenda.RevendaEmails)
                {
                    Adicionar(item.Email);
                }
            }
        }

        private void RetornarEmailConsultor(int usuarioId, Agendamento agendamento)
        {
            var notificar = _uow.RepositorioStatus.NotificarConsultor(agendamento.StatusId);

            if (notificar)
            {
                if (agendamento.Cliente == null)
                {
                    agendamento.Cliente = _uow.RepositorioCliente.find(agendamento.ClienteId);

                    if (agendamento.Cliente == null)
                        return;
                }

                int idUsuario = 0;
                if (agendamento.Cliente.UsuarioId != null)
                    idUsuario = Convert.ToInt32(agendamento.Cliente.UsuarioId);

                var usuarioModel = _uow.RepositorioUsuario.find(idUsuario);

                if (usuarioModel == null)
                    return;

                if (!string.IsNullOrEmpty(usuarioModel.Email))
                {
                    Adicionar(usuarioModel.Email);
                }
            }
        }

        private void RetornarEmailSupervisor(int usuarioId, Agendamento model)
        {
            var notificar = _uow.RepositorioStatus.NotificarSupervisor(model.StatusId);

            if (notificar)
            {
                var usuario = _uow.RepositorioUsuario.find(usuarioId);
                foreach (var item in usuario.Departamento.DepartamentosEmail)
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

        public string RetornarEmailCliente(int usuarioId, Agendamento agendamento)
        {
            string emailConta = RetornarEmailConta(usuarioId);
            if (string.IsNullOrWhiteSpace(emailConta))
                return "";

            var listaEmail = _uow.RepositorioAgendamento.RetornarEmailClientes(agendamento.Id);

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

        private void AdicionarEmailCliente(string email)
        {
            if (!_listaEmailCliente.Contains(email))
                _listaEmailCliente.Add(email);
        }

        private string RetornarEmailConta(int usuarioId)
        {
            var usuario = _uow.RepositorioUsuario.find(usuarioId);

            string sRetorno = "";
            if (usuario.ContaEmail != null)
                sRetorno = usuario.ContaEmail.Email;

            return sRetorno;
        }
    }
}
