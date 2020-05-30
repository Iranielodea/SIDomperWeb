using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.EF;
using SIDomper.Infra.RepositorioDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SIDomper.Servicos.Regras
{
    public class VisitaServico
    {
        UsuarioServico _usuario;
        VisitaEF _rep;
        List<string> _listaEmail;
        List<string> _listaEmailCliente;
        private readonly EnProgramas _tipoPrograma;
        private readonly VisitaRepositorioDapper _visitaRepositorioDapper;

        public VisitaServico()
        {
            _usuario = new UsuarioServico();
            _rep = new VisitaEF();
            _listaEmail = new List<string>();
            _listaEmailCliente = new List<string>();
            _tipoPrograma = EnProgramas.Visita;
            _visitaRepositorioDapper = new VisitaRepositorioDapper();
        }

        public Visita Novo(int idUsuario, int idClienteAgendamento)
        {
            var model = new Visita();
            _usuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Data = DateTime.Now.Date;

            var StatusServico = new StatusServico();
            var status = StatusServico.ObterPorPrograma(EnStatus.Visita).First();
            if (status != null)
                model.Status = status;

            if (idClienteAgendamento > 0)
            {
                var ClienteServico = new ClienteServico();
                var cliente = ClienteServico.ObterPorId(idClienteAgendamento);
                if (cliente !=  null)
                    model.Cliente = cliente;
            }

            model.Usuario = _usuario.ObterPorId(idUsuario);

            if (!_usuario.HorarioUsoSistema("", "", idUsuario))
                throw new Exception("Horário não disponível para lançamento de visita");

            return model;
        }

        public Visita Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao;
            var model = new Visita();
            model = _rep.ObterPorId(id);

            var Usuario = _usuario.ObterPorId(idUsuario);
            if (Usuario.Adm)
            {
                permissao = true;
                permissaoMensagem = "OK";
            }
            else
            {
                permissao = _usuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
                if (permissao)
                    permissao = (model.UsuarioId == idUsuario);

                permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            }
            return model;


            //bool permissao = _usuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            //permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            //return _rep.ObterPorId(id);
        }

        private string MensagemFinal()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Esta mensagem é automática e foi gerada pelo Sistema Interno Domper.");
            sb.AppendLine("Caso o que foi relatado não esteja em conformidade com o que foi realizado, favor entrar em contato com o seu consultor.");

            return sb.ToString();
        }

        public List<VisitaConsulta> Filtrar(int idUsuario, VisitaFiltro filtro)
        {
            return _rep.Filtrar(idUsuario, filtro);
        }

        public List<VisitaConsulta> Filtrar(int idUsuario, VisitaFiltro filtro, string campo, string valor)
        {
            return _rep.Filtrar(idUsuario, filtro, campo, valor);
        }

        public IEnumerable<VisitaConsultaViewModelApi> FiltrarAPI(int idUsuario, VisitaFiltroViewModelApi filtro, string campo, string valor)
        {
            return _visitaRepositorioDapper.FiltrarAPI(idUsuario, filtro, campo, valor);
        }

        public Visita ObterPorId(int id)
        {
            var visita = _rep.ObterPorId(id);

            if (visita != null)
            {
                if (visita.Cliente == null)
                {
                    visita.Cliente = new ClienteServico().ObterPorId(visita.ClienteId);
                }

                if (visita.Status == null)
                {
                    visita.Status = new StatusServico().ObterPorId(visita.StatusId);
                }

                if (visita.Tipo == null)
                {
                    visita.Tipo = new TipoServico().ObterPorId(visita.TipoId);
                }

                if (visita.Usuario == null)
                {
                    visita.Usuario = new UsuarioServico().ObterPorId(visita.UsuarioId);
                }
            }

            return visita;
        }

        public void Excluir(int id)
        {
            var model = _rep.ObterPorId(id);
            _rep.Excluir(model);
        }

        public void Excluir(int idUsuario, int id)
        {
            try
            {
                _usuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
                var model = _rep.ObterPorId(id);
                _rep.Excluir(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Salvar(Visita visita, int usuarioId)
        {
            //model.HoraInicio = TimeSpan.Parse("07:35");
            //model.HoraFim = TimeSpan.Parse("08:30");

            if (visita.HoraInicio > visita.HoraFim)
                throw new Exception("Hora Inicial maior que Hora Final!");

            if (visita.TipoId == 0)
                throw new Exception("Informe o Tipo");

            double HoraInicio = Funcoes.Horas.HoraToDecimal(visita.HoraInicio.ToString());
            double HoraFim = Funcoes.Horas.HoraToDecimal(visita.HoraFim.ToString());
            int id = visita.Id;

            visita.TotalHoras = HoraFim - HoraInicio;
            using (var scope = new TransactionScope())
            {
                _rep.Salvar(visita);
                AtualizarVersaoCliente(visita);
                scope.Complete();
            }

            if (id == 0)
            {
                visita = ObterPorId(visita.Id);
                EnviarEmailVisita(visita, usuarioId);
            }

            return visita.Id;
        }

        public bool PermissaoAcesso(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Visita, EnTipoManutencao.Acessar);
        }

        public bool PermissaoIncluir(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Visita, EnTipoManutencao.Incluir);
        }

        public bool PermissaoEditar(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Visita, EnTipoManutencao.Editar);
        }

        public bool PermissaoExcluir(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Visita, EnTipoManutencao.Excluir);
        }

        public bool PermissaoRelatorio(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Visita, EnTipoManutencao.Imprimir);
        }

        private void AtualizarVersaoCliente(Visita visita)
        {
            var modelTipo = new TipoServico().ObterPorId(visita.TipoId);

            if (modelTipo != null)
            {
                var ParametroServico = new ParametroServico();
                bool resultado = TipoObrigatorio(modelTipo.Codigo);

                if (resultado == true && string.IsNullOrWhiteSpace(visita.Versao))
                    throw new Exception("Informe a Versão");
            }

            if (!string.IsNullOrWhiteSpace(visita.Versao))
            {
                var clienteServico = new ClienteServico();
                clienteServico.AtualizarVersao(visita.ClienteId, visita.Versao);

                //var modelCliente = clienteServico.ObterPorId(visita.ClienteId);

                //if (modelCliente != null)
                //{
                //    modelCliente.Versao = visita.Versao;
                //    clienteServico.Salvar(modelCliente);
                //}
            }
        }

        private bool TipoObrigatorio(int codigoTipo)
        {
            bool resultado = false;

            if (codigoTipo > 0)
            {
                var parametro = new ParametroServico().ObterPorParametro(51, 0);
                if (parametro.Codigo > 0)
                {
                    if (codigoTipo.ToString() == parametro.Valor)
                        resultado = true;
                }
            }

            return resultado;
        }

        private void RetornarEmailSupervisor(int usuarioId, Visita visita)
        {
            var notificar = new StatusServico().NotificarSupervisor(visita.StatusId);

            if (notificar)
            {
                var listaEmail = new DepartamentoEmailServico().RetornarEmail(usuarioId);
                foreach (var item in listaEmail)
                {
                    Adicionar(item.Email);
                }
            }
        }

        private void RetornarEmailConsultor(int usuarioId, Visita visita)
        {
            var notificar = new StatusServico().NotificarConsultor(visita.StatusId);

            if (notificar)
            {
                if (visita.Cliente == null)
                {
                    visita.Cliente = new ClienteServico().ObterPorId(visita.ClienteId);

                    if (visita.Cliente == null)
                        return;
                }

                int idUsuario = 0;
                if (visita.Cliente.UsuarioId != null)
                    idUsuario = Convert.ToInt32(visita.Cliente.UsuarioId);

                var usuarioModel = new UsuarioServico().ObterPorId(idUsuario);

                if (usuarioModel == null)
                    return;

                if (!string.IsNullOrEmpty(usuarioModel.Email))
                {
                    Adicionar(usuarioModel.Email);
                }
            }
        }

        private void RetornarEmailRevenda(int usuarioId, Visita visita)
        {
            var notificar = new StatusServico().NotificarRevenda(visita.StatusId);

            if (notificar)
            {
                if (visita.Cliente == null)
                    return;

                if (visita.Cliente.Revenda == null)
                    return;

                var listaEmail = new RevendaEmailServico().ObterPorRevenda(visita.Cliente.Revenda.Id);

                foreach (var item in listaEmail)
                {
                    Adicionar(item.Email);
                }
            }
        }

        public string RetornarEmailCliente(int usuarioId, Visita visita)
        {
            string emailConta = RetornarEmailConta(usuarioId);
            if (string.IsNullOrWhiteSpace(emailConta))
                return "";

            var listaEmail = BuscarEmailClientes(visita.Id);

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

                ContaEmailServico conta = new ContaEmailServico();
                conta.EnviarEmail(usuarioId, emailCliente, emailOculto, assunto, texto, "");
            }
        }

        private string RetornarAssunto(int visitaId)
        {
            return "Visita: " + visitaId.ToString("000000") + " Domper Consultoria e Sistemas Ltda.";
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

        private List<ClienteEmail> BuscarEmailClientes(int visitaId)
        {
            return _rep.RetornarEmailClientes(visitaId);
        }

        private void Adicionar(string email)
        {
            if (!_listaEmail.Contains(email))
            {
                _listaEmail.Add(email);
            }
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
    }
}
