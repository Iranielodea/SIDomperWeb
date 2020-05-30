using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.EF;
using SIDomper.Infra.RepositorioDapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Servicos.Regras
{
    public class AgendamentoServico
    {
        private readonly AgendamentoEF _rep;
        private readonly TipoEF _repTipo;
        private readonly UsuarioServico _repUsuario;
        AgendamentoRepositorioDapper _agendamentoRepositorioDapper;

        private readonly EnProgramas _tipoPrograma;
        List<string> _listaEmail;
        List<string> _listaEmailCliente;

        public AgendamentoServico()
        {
            _rep = new AgendamentoEF();
            _repTipo = new TipoEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Agendamento;
            _listaEmail = new List<string>();
            _listaEmailCliente = new List<string>();
            _agendamentoRepositorioDapper = new AgendamentoRepositorioDapper();
        }

        public Agendamento ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public void Excluir(int idUsuario, int id)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            var model = _rep.ObterPorId(id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public Agendamento Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);
        }

        public Agendamento Novo(int idUsuario)
        {
            if (VerificarAgendamentoAberto(idUsuario))
                throw new Exception("Há Agendamentos em Aberto!");

            var statusServico = new StatusServico();
            var model = new Agendamento();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Programa = 2;
            model.Data = DateTime.Now.Date;
            model.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            model.Usuario = _repUsuario.ObterPorId(idUsuario);
            model.Tipo = RetornarTipoAgendamento();
            model.Status = statusServico.ObterPorCodigo(StatusAbertura());

            return model;
        }

        public IEnumerable<AgendamentoConsultaViewModel> Filtrar(AgendamentoFiltroViewModel filtro, string campo, string texto, int idUsuario, bool contem = true)
        {
            return _agendamentoRepositorioDapper.Filtrar(filtro, campo, texto, idUsuario, contem);
        }

        private void ValidarAgendamento(Agendamento model)
        {
            if (model.Data == null)
                throw new Exception("Informe a Data!");
            if (model.Hora == null)
                throw new Exception("Informe a Hora!");
            if (model.UsuarioId == 0)
                throw new Exception("Informe o Usuário!");
            if (model.ClienteId == 0)
                throw new Exception("Informe o Cliente!");
            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo!");
            if (model.StatusId == 0)
                throw new Exception("Informe o Status!");
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");            

            if (model.Id == 0)
            {
                if (model.Data == DateTime.Now.Date)
                {
                    if (model.Hora < TimeSpan.Parse(DateTime.Now.ToShortTimeString()))
                        throw new Exception("Não será possível agendar para este horário!");
                }
            }
        }

        public void Salvar(Agendamento model)
        {
            ValidarAgendamento(model);

            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Salvar(Agendamento model, int usuarioId)
        {
            int id = model.Id;

            ValidarAgendamento(model);

            _rep.Salvar(model);
            _rep.Commit();

            if (id == 0)
            {
                //EnviarEmailAgendamento(model, usuarioId);
            }
        }

        public void Reagendamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            int idStatus = RetornarIdStatus(35);
            if (idStatus == 0)
                return;

            var model = ObterPorId(idAgendamento);

            if (model.UsuarioId != idUsuario)
                throw new Exception("Para Reagendar, somente o mesmo usuário da Abertura!");

            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(model.Motivo))
                sb.AppendLine(model.Motivo);

            sb.AppendLine(model.Status.Nome + " - ");
            sb.Append(model.Data.ToShortDateString() + "- ");
            sb.Append(model.Hora.ToString("hh:mm"));

            model.Motivo = sb.ToString();
            model.Hora = TimeSpan.Parse(hora);
            model.Data = Convert.ToDateTime(data);
            model.StatusId = idStatus;

            Salvar(model);
        }

        public void Cancelamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            int idStatus = RetornarIdStatus(34);
            if (idStatus == 0)
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
            model.StatusId = idStatus;

            Salvar(model);
        }

        public void Encerramento(int idUsuario, int idAgenda, int idPrograma)
        {
            int idStatus = RetornarIdStatus(36);
            if (idStatus == 0)
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
                    model.StatusId = idStatus;
                }

                if (model.Programa == 7) // atividade
                {
                    model.AtividadeId = idPrograma;
                    model.StatusId = idStatus;
                }
                Salvar(model);
            }
        }

        public void EncerramentoWEB(int idUsuario, int idAgenda)
        {
            int idStatus = RetornarIdStatus(36);
            if (idStatus == 0)
                return;

            var model = ObterPorId(idAgenda);

            if (model.UsuarioId == idUsuario)
                throw new Exception("Para encerrar, somente o mesmo usuário da Abertura!");

            if (model.StatusId == idStatus)
                throw new Exception("Agendamento já encerrado!");

            model.StatusId = idStatus;
            Salvar(model);
        }

        public IEnumerable<AgendamentoQuadroViewModel> Quadros(string dataInicial, string dataFinal, int idUsuario, int idRevenda)
        {
            return _agendamentoRepositorioDapper.Quadros(dataInicial, dataFinal, idUsuario, idRevenda);
        }

        public string AgendamentoCancelado()
        {
            var parametroServico = new ParametroServico();
            var parametroModel = parametroServico.ObterPorParametro(34, 112);
            if (parametroModel != null)
                return parametroModel.Valor;
            else
                return "";
        }

        public string AgendamentoEnderrado()
        {
            var parametroServico = new ParametroServico();
            var parametroModel = parametroServico.ObterPorParametro(36, 0);

            if (parametroModel != null)
                return parametroModel.Valor;
            else
                return "";
        }

        public int StatusAbertura()
        {
            var parametroServico = new ParametroServico();
            var parametroModel = parametroServico.ObterPorParametro(33, 112); 

            if (parametroModel != null)
                return int.Parse(parametroModel.Valor);
            else
                return 0;
        }

        private int RetornarIdStatus(int codParametro)
        {
            var parametroServico = new ParametroServico();
            var parametro = parametroServico.ObterPorParametro(codParametro, 0);

            if (parametro == null)
                return 0;

            var statusServico = new StatusServico();
            var modelStatus = statusServico.ObterPorCodigo(Convert.ToInt32(parametro.Valor));
            if (modelStatus == null)
                return 0;

            return modelStatus.Id;
        }

        private bool VerificarAgendamentoAberto(int idUsuario)
        {
            string codigo = AgendamentoEnderrado();

            int idStatusCancelado = 0;
            int idStatusEncerrado = 0;

            var statusServico = new StatusServico();
            Status model = new Status();

            model = statusServico.ObterPorCodigo(int.Parse(codigo));
            if (model != null)
                idStatusEncerrado = model.Id;

            codigo = AgendamentoCancelado();
            model = statusServico.ObterPorCodigo(int.Parse(codigo));
            if (model != null)
                idStatusCancelado = model.Id;

            return _rep.VerificarAgendamentoAberto(idUsuario, idStatusEncerrado, idStatusCancelado);
        }

        private Tipo RetornarTipoAgendamento()
        {
            return _repTipo.ObterPorCodigo(30);
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

                ContaEmailServico conta = new ContaEmailServico();
                conta.EnviarEmail(usuarioId, emailCliente, emailOculto, assunto, texto, "");
            }
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

        private string RetornarAssunto(int agendamentoId)
        {
            return "Agendamento: " + agendamentoId.ToString("000000") + " Domper Consultoria e Sistemas Ltda.";
        }

        private List<ClienteEmail> BuscarEmailClientes(int agendamentoId)
        {
            return _rep.RetornarEmailClientes(agendamentoId);
        }

        public string RetornarEmailCliente(int usuarioId, Agendamento agendamento)
        {
            string emailConta = RetornarEmailConta(usuarioId);
            if (string.IsNullOrWhiteSpace(emailConta))
                return "";

            var listaEmail = BuscarEmailClientes(agendamento.Id);

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
            var usuario = new UsuarioServico().ObterPorId(usuarioId);

            string sRetorno = "";
            if (usuario.ContaEmail != null)
                sRetorno = usuario.ContaEmail.Email;

            return sRetorno;
        }

        private void RetornarEmailSupervisor(int usuarioId, Agendamento agendamento)
        {
            var notificar = new StatusServico().NotificarSupervisor(agendamento.StatusId);

            if (notificar)
            {
                var listaEmail = new DepartamentoEmailServico().RetornarEmail(usuarioId);
                foreach (var item in listaEmail)
                {
                    Adicionar(item.Email);
                }
            }
        }

        private void RetornarEmailConsultor(int usuarioId, Agendamento agendamento)
        {
            var notificar = new StatusServico().NotificarConsultor(agendamento.StatusId);

            if (notificar)
            {
                if (agendamento.Cliente == null)
                {
                    agendamento.Cliente = new ClienteServico().ObterPorId(agendamento.ClienteId);

                    if (agendamento.Cliente == null)
                        return;
                }

                int idUsuario = 0;
                if (agendamento.Cliente.UsuarioId != null)
                    idUsuario = Convert.ToInt32(agendamento.Cliente.UsuarioId);

                var usuarioModel = new UsuarioServico().ObterPorId(idUsuario);

                if (usuarioModel == null)
                    return;

                if (!string.IsNullOrEmpty(usuarioModel.Email))
                {
                    Adicionar(usuarioModel.Email);
                }
            }
        }

        private void RetornarEmailRevenda(int usuarioId, Agendamento agendamento)
        {
            var notificar = new StatusServico().NotificarRevenda(agendamento.StatusId);

            if (notificar)
            {
                if (agendamento.Cliente == null)
                    return;

                if (agendamento.Cliente.Revenda == null)
                    return;

                var listaEmail = new RevendaEmailServico().ObterPorRevenda(agendamento.Cliente.Revenda.Id);

                foreach (var item in listaEmail)
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
    }
}
