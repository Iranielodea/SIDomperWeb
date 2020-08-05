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
    public class ServicoChamado : IServicoChamado
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ChamadoConsultaViewModel> _repositoryReadOnly;
        private readonly IRepositoryReadOnly<ChamadoAplicativoViewModel> _repositoryAplicativoReadOnly;
        private readonly IRepositoryReadOnly<ChamadoAnexo> _repositoryAnexoReadOnly;
        private readonly EnProgramas _enProgramas;
        private readonly EnumChamado _enumChamadoAtividade;
        List<string> _listaEmail;
        List<string> _listaEmailCliente;

        public ServicoChamado(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ChamadoConsultaViewModel> repositoryReadOnly,
           EnumChamado enumChamado, IRepositoryReadOnly<ChamadoAplicativoViewModel> repositoryAplicativoReadOnly,
           IRepositoryReadOnly<ChamadoAnexo> repositoryAnexoReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Chamado;
            _enumChamadoAtividade = enumChamado;
            _repositoryAplicativoReadOnly = repositoryAplicativoReadOnly;
            _repositoryAnexoReadOnly = repositoryAnexoReadOnly;

            _listaEmail = new List<string>();
            _listaEmailCliente = new List<string>();

            if (enumChamado == EnumChamado.Chamado)
                _enProgramas = EnProgramas.Chamado;
            else
                _enProgramas = EnProgramas.Atividade;
        }

        public ChamadoQuadroViewModel AbrirQuadro(int idUsuario, int idRevenda)
        {
            throw new NotImplementedException();
        }

        public Chamado Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            var model = ObterPorId(id);
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
            {
                if (model.UsuarioAberturaId != idUsuario)
                    mensagem = Mensagem.UsuarioSemPermissao;
            }

            return model;
        }

        public void Excluir(Chamado model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioChamado.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ChamadoConsultaViewModel> Filtrar(ChamadoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem, EnumChamado tipo)
        {
            var sb = new StringBuilder();
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'" + texto + "%'";

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Cha_Id as Id,");
            sb.AppendLine(" '' as Descricao,");
            sb.AppendLine(" Cha_DataAbertura as DataAbertura,");
            sb.AppendLine(" Cha_HoraAbertura as HoraAbertura,");
            sb.AppendLine(" Sta_Nome as NomeStatus,");
            sb.AppendLine(" Cha_Status as IdStatus,");
            sb.AppendLine(" Tip_Nome as NomeTipo,");
            sb.AppendLine(" Cli_Nome as RazaoSocial,");
            sb.AppendLine(" Cli_Fantasia as Fantasia,");
            sb.AppendLine(" CASE Cha_Nivel");
            sb.AppendLine("   WHEN 1 THEN '1-Baixo'");
            sb.AppendLine("   WHEN 2 THEN '2-Normal'");
            sb.AppendLine("   WHEN 3 THEN '3-Alto'");
            sb.AppendLine("   WHEN 4 THEN '4-Crítico'");
            sb.AppendLine(" END AS Nivel,");
            sb.AppendLine(" Usu_Nome as NomeUsuario");
            sb.AppendLine(" FROM Chamado");
            sb.AppendLine("	INNER JOIN Status  ON Cha_Status = Sta_Id");
            sb.AppendLine("	INNER JOIN Tipo    ON Cha_Tipo = Tip_Id");
            sb.AppendLine(" INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("	INNER JOIN Usuario ON Cha_UsuarioAbertura = Usu_Id");
            sb.AppendLine(" LEFT JOIN Revenda ON Cli_Revenda = Rev_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Cha_Id > 0");
            }

            if (filtro.Id > 0)
                sb.AppendLine(" AND Cha_Id = " + filtro.Id);

            if (tipo == EnumChamado.Chamado)
                sb.AppendLine(" AND Cha_TipoMovimento = 1");
            else
                sb.AppendLine(" AND Cha_TipoMovimento = 2");

            sb.AppendLine(_uow.RepositorioUsuario.PermissaoUsuario(usuarioId));

            if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (filtro.DataInicial.Trim() != "/  /"))
                sb.AppendLine(" AND Cha_DataAbertura >=" + Funcoes.Utils.DataIngles(filtro.DataInicial));

            if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (filtro.DataFinal.Trim() != "/  /"))
                sb.AppendLine(" AND Cha_DataAbertura <=" + Funcoes.Utils.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Cha_Cliente IN " + filtro.IdCliente);

            if (!string.IsNullOrWhiteSpace(filtro.IdTipo))
                sb.AppendLine(" AND Cha_Tipo IN " + filtro.IdTipo);

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Cha_Status IN " + filtro.IdStatus);

            if (!string.IsNullOrWhiteSpace(filtro.IdModulo))
                sb.AppendLine(" AND Cha_Modulo IN " + filtro.IdModulo);

            if (!string.IsNullOrWhiteSpace(filtro.IdRevenda))
                sb.AppendLine(" AND Cha_Revenda IN " + filtro.IdRevenda);

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioAbertura))
                sb.AppendLine(" AND Cha_UsuarioAbertura IN " + filtro.IdUsuarioAbertura);

            if (filtro.ClienteFiltro.UsuarioId > 0)
                sb.AppendLine(" AND Cli_Usuario IN " + filtro.ClienteFiltro.UsuarioId);
            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Chamado Novo(int idUsuario, bool quadro, int idClienteAgendamento, int idAgendamento)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var model = new Chamado();
            var modelTipo = _uow.RepositorioTipo.RetornarUmRegistro(_enumChamadoAtividade);
            if (modelTipo != null)
                model.Tipo = modelTipo;

            var usuario = _uow.RepositorioUsuario.find(idUsuario);
            if (usuario != null)
            {
                model.UsuarioAbertura = usuario;
                if (usuario.ClienteId != null && usuario.ClienteId > 0)
                    model.Cliente = usuario.Clientes.FirstOrDefault(x => x.Id == usuario.ClienteId.Value);
            }

            var obsModel = _uow.RepositorioObservacao.ObterPadrao((int)_enumChamadoAtividade);
            if (obsModel != null)
                model.Descricao = obsModel.Descricao;

            if (quadro && idClienteAgendamento > 0)
                model.Cliente = _uow.RepositorioCliente.find(idClienteAgendamento);

            if (idAgendamento > 0)
                BuscarAgendamento(idAgendamento, model);

            model.DataAbertura = DateTime.Now.Date;

            return model;
        }

        private void BuscarAgendamento(int idAgendamento, Chamado model)
        {
            var Agendamento = _uow.RepositorioAgendamento.find(idAgendamento);
            model.DataAbertura = Agendamento.Data;
            model.Descricao = Agendamento.Descricao;
        }

        public Chamado ObterPorId(int id)
        {
            return _uow.RepositorioChamado.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public IEnumerable<ChamadoAplicativoViewModel> RetornarDadosAplicativo(string cnpj)
        {
            string novoCnpj;
            if (cnpj.Length == 11)
                novoCnpj = Funcoes.Utils.FormatarCPF(cnpj);
            else
                novoCnpj = Funcoes.Utils.FormatarCNPJ(cnpj);

            // lista 20 chamados independente de quantas
            // ocorrencias tenha
            var sb = new StringBuilder();
            sb.AppendLine("SELECT TOP(20) WITH TIES");
            sb.AppendLine(" Cha_Id as Id,");
            sb.AppendLine(" Cha_DataAbertura as Data,");
            sb.AppendLine(" Cha_Contato as Contato,");
            sb.AppendLine(" Sta_Nome as Status, ");
            sb.AppendLine(" ChOco_DescricaoTecnica as DescricaoProblema,");
            sb.AppendLine(" ChOco_DescricaoSolucao as DescricaoSolucao ");
            sb.AppendLine("FROM Chamado");
            sb.AppendLine(" LEFT JOIN Chamado_Ocorrencia ON Cha_Id = ChOco_Chamado");
            sb.AppendLine(" INNER JOIN Status ON Cha_Status = Sta_Id");
            sb.AppendLine(" INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine(" WHERE Cli_Dcto = '" + novoCnpj + "'");
            sb.AppendLine(" ORDER BY Cha_Id DESC");

            return _repositoryAplicativoReadOnly.GetAll(sb.ToString());
        }

        public void Salvar(Chamado model, int idUsuario, bool ocorrencia)
        {
            try
            {
                int id = model.Id;

                ValidarSalvar(model);

                if (model.Id == 0)
                {
                    model.UsuarioAtendeAtualId = idUsuario;
                    model.HoraAtendeAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                    _uow.RepositorioChamado.Salvar(model);
                }
                else
                {
                    var chamado = ObterPorId(model.Id);
                    if (chamado == null)
                        chamado = new Chamado();

                    chamado.ClienteId = model.ClienteId;
                    chamado.Contato = model.Contato;
                    chamado.DataAbertura = model.DataAbertura;
                    chamado.Descricao = model.Descricao;
                    chamado.HoraAbertura = model.HoraAbertura;
                    chamado.HoraAtendeAtual = model.HoraAtendeAtual;
                    chamado.ModuloId = model.ModuloId;
                    chamado.Nivel = model.Nivel;
                    chamado.Origem = model.Origem;
                    chamado.ProdutoId = model.ProdutoId;
                    chamado.StatusId = model.StatusId;
                    chamado.TipoId = model.TipoId;
                    chamado.TipoMovimento = model.TipoMovimento;
                    chamado.UsuarioAberturaId = model.UsuarioAberturaId;
                    chamado.UsuarioAtendeAtualId = model.UsuarioAtendeAtualId;

                    //AlterarOcorrencia(chamado, model);
                    //ExcluirOcorrencias(model);

                    //_rep.Salvar(chamado);
                    _uow.RepositorioChamado.Salvar(model);
                }

                // O Status do Chamado é salvo via trigger na tabela Chamado

                _uow.SaveChanges();

                if (id <= 0) // inclusao
                {
                    if (ocorrencia == false)
                    {
                        var usuario = _uow.RepositorioUsuario.find(idUsuario);

                        // TODO: tirar os comentarios
                        //if (model.TipoMovimento == (int)EnumChamado.Chamado)
                        //    EnviarEmail(model, idUsuario, usuario, EnumChamado.Chamado);
                        //else
                        //    EnviarEmail(model, idUsuario, usuario, EnumChamado.Atividade);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EnviarEmail(Chamado model, int usuarioId, Usuario usuario, EnumChamado enChamado)
        {
            string emailOculto = BuscarEmail(model, usuarioId, usuario);
            string emailCliente = RetornarEmailCliente(usuarioId, model);

            if (string.IsNullOrEmpty(emailCliente))
                emailCliente = emailOculto;

            if (!string.IsNullOrEmpty(emailCliente))
            {
                string texto = TextoEmail(model, enChamado);
                string assunto = RetornarAssunto(model, enChamado);
                
                _uow.RepositorioContaEmail.EnviarEmail(usuarioId, emailCliente, emailOculto, assunto, texto, "");
            }
        }

        private string RetornarAssunto(Chamado model, EnumChamado enChamado)
        {
            string titulo = "Chamado: ";
            if (enChamado == EnumChamado.Atividade)
                titulo = "Atividade: ";
            return titulo + model.Id.ToString("000000") + " DOMPER Consultoria e Sistemas Ltda.";
        }

        private string TextoEmail(Chamado chamado, EnumChamado enChamado)
        {
            string titulo1 = "Chamado: ";
            string titulo2 = " Chamados ";
            if (enChamado == EnumChamado.Atividade)
            {
                titulo1 = "Atividade: ";
                titulo2 = " Atividades ";
            }

            var sb = new StringBuilder();
            sb.AppendLine("Caro(a) : " + chamado.Cliente.Nome + ", seguem abaixo informações referente ao chamado realizado na Domper Consultoria e Sistemas:");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Nº " + titulo1 + chamado.Id.ToString("000000"));
            sb.AppendLine("Data Abertura: " + chamado.DataAbertura.Date.ToShortDateString() + " - Hora: " + chamado.HoraAbertura.ToString("hh:mm"));
            sb.AppendLine("Aberto por: " + chamado.UsuarioAbertura.Nome);
            sb.AppendLine("Contato: " + chamado.Contato);
            sb.AppendLine("Descrição: " + chamado.Descricao);

            sb.AppendLine("Dados do Atendimento (" + chamado.Status.Nome + ")");
            sb.AppendLine("");
            sb.AppendLine("");

            foreach (var item in chamado.ChamadoOcorrencias)
            {
                sb.AppendLine("Usuário : " + item.Usuario.Nome);
                sb.AppendLine("Data Ocorrência: " + item.Data.ToShortDateString());
                sb.AppendLine("Hora Inicial: " + item.HoraInicio.Hours);
                sb.AppendLine("Hora Final: " + item.HoraFim.Hours);
                sb.AppendLine("Solução: " + item.DescricaoSolucao);
            }

            sb.AppendLine("Colocamo-nos a disposição para maiores esclarecimentos.");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Equipe Domper");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Esta mensagem é automática e foi gerada pelo Sistema Interno de " + titulo2 + " Domper.");
            sb.AppendLine("");
            sb.AppendLine("Por favor não responda este email.");

            return sb.ToString();
        }

        private string RetornarEmailCliente(int usuarioId, Chamado chamado)
        {
            string emailConta = RetornarEmailConta(usuarioId);
            if (string.IsNullOrWhiteSpace(emailConta))
                return "";

            int contadorEmail = 0;

            foreach (var item in chamado.Cliente.Emails)
            {
                if (item.Notificar)
                {
                    AdicionarEmailCliente(item.Email);
                    contadorEmail++;
                }
            }

            if (contadorEmail == 0)
                AdicionarEmailCliente(emailConta);

            return RetornaListaEmail(_listaEmailCliente);
        }

        private void AdicionarEmailCliente(string email)
        {
            if (!_listaEmailCliente.Contains(email))
                _listaEmailCliente.Add(email);
        }

        private string BuscarEmail(Chamado model, int usuarioId, Usuario usuario)
        {
            if (TemContaEmail(usuarioId))
            {
                RetornarEmailSupervior(model, usuario);
                RetornarEmailConsultor(model, usuario);
                RetornarEmailRevenda(model, usuario);
            }

            return RetornaListaEmail(_listaEmail);
        }

        private void RetornarEmailRevenda(Chamado model, Usuario usuario)
        {
            if (model.Status != null || model.Status.NotificarRevenda == false)
                return;

            if (model.Cliente == null)
                return;

            if (model.Cliente.Revenda == null)
                return;

            if (model.Cliente.Revenda.RevendaEmails == null)
                return;

            string email = "";
            foreach (var item in model.Cliente.Revenda.RevendaEmails)
            {
                if (email == "")
                    email = item.Email;
                else
                    email = email + ";" + item.Email;
            }

            AdicionarEmail(email);
        }

        private void RetornarEmailConsultor(Chamado model, Usuario usuario)
        {
            if (model.Status != null || model.Status.NotificarConsultor == false)
                return;

            string emailCliente = "";
            if (model.Cliente != null)
            {
                if (model.Cliente.Usuario != null)
                    emailCliente = model.Cliente.Usuario.Email;
            }

            AdicionarEmail(emailCliente);
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

        private void RetornarEmailSupervior(Chamado model, Usuario usuario)
        {
            if (model.Status != null || model.Status.NotificarSupervisor == false)
                return;

            if (usuario.Departamento == null)
                return;

            if (usuario.Departamento.DepartamentosEmail == null)
                return;

            string email = "";
            foreach (var item in usuario.Departamento.DepartamentosEmail)
            {
                if (email == "")
                    email = email + item.Email;
                else
                    email = email + ";" + item.Email;
            }


            AdicionarEmail(email);
        }

        private void AdicionarEmail(string email)
        {
            if (!_listaEmail.Contains(email))
                _listaEmail.Add(email);
        }

        public string RetornarEmail(Departamento departamento)
        {
            string email = "";
            foreach (var item in departamento.DepartamentosEmail)
            {
                if (email == "")
                    email = email + item.Email;
                else
                    email = email + ";" + item.Email;
            }

            return email;
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

        public void Salvar(Chamado model)
        {
            try
            {
                ValidarSalvar(model);
                _uow.RepositorioChamado.Salvar(model);
                _uow.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AlterarOcorrencia(Chamado chamado, Chamado model)
        {
            foreach (var item in model.ChamadoOcorrencias)
            {
                item.HoraFim = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                if (item.UsuarioId == 0)
                    throw new Exception("Informe o Usuário!");

                //if (item.Data < model.DataAbertura)
                //    throw new Exception("Data de Ocorrência menor que Data de Abertura!");
                //if (item.HoraInicio > item.HoraFim)
                //    throw new Exception("Hora Inicial maior que Hora Final na Ocorrência!");

                //if (string.IsNullOrWhiteSpace(item.DescricaoTecnica) && string.IsNullOrWhiteSpace(item.DescricaoSolucao))
                //    throw new Exception("Informe uma descrição!");

                double HoraInicio = Funcoes.Utils.HoraToDecimal(item.HoraInicio.ToString());
                double HoraFim = Funcoes.Utils.HoraToDecimal(item.HoraFim.ToString());

                item.TotalHoras = HoraFim - HoraInicio;

                if (item.Id <= 0)
                    chamado.ChamadoOcorrencias.Add(item);
                else
                {

                    //ExcluirOcorrenciasColaborador(item);

                    //temp = _repChamadoOcorrencia.ObterPorId(item.Id);
                    //var temp = chamado.ChamadoOcorrencias.FirstOrDefault(x => x.Id == item.Id);
                    //temp = model.ChamadoOcorrencias.FirstOrDefault(x => x.Id == item.Id);
                    var temp = chamado.ChamadoOcorrencias.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp = item;
                        //temp.Anexo = item.Anexo;
                        //temp.Data = item.Data;
                        //temp.DescricaoSolucao = item.DescricaoSolucao;
                        //temp.DescricaoTecnica = item.DescricaoTecnica;
                        //temp.Documento = item.Documento;
                        //temp.HoraFim = item.HoraFim;
                        //temp.HoraInicio = item.HoraInicio;
                        //temp.TotalHoras = item.TotalHoras;
                        //temp.UsuarioColab1 = item.UsuarioColab1;
                        //temp.UsuarioColab2 = item.UsuarioColab2;
                        //temp.UsuarioColab3 = item.UsuarioColab3;
                        //temp.UsuarioId = item.UsuarioId;
                        //temp.Versao = item.Versao;

                        //_repChamadoOcorrencia.Salvar(temp);
                        //_repChamadoOcorrencia.Commit();
                        //AlterarOcorrenciaColaborador(temp);
                        //ExcluirOcorrenciasColaborador(temp);

                        //foreach (var colab in temp.ChamadoOcorrenciaColaboradores)
                        //{
                        //    _repChamadoOcorrenciaColaboradorEF.Salvar(colab);
                        //}

                        //_repChamadoOcorrenciaColaboradorEF.Commit();

                        //AlterarOcorrenciaColaborador(temp);
                    }
                }
            }
            //_uow.SaveChanges();
            //_repChamadoOcorrencia.Commit();
            //_repChamadoOcorrenciaColaboradorEF.Commit();

            //if (model.ChamadoOcorrencias.Count() > 0)
            //    _repChamadoOcorrencia.Commit();
        }

        private void ValidarSalvar(Chamado model)
        {
            if (model.DataAbertura == null)
                _uow.Notificacao.Add("Informe a Data da Abertura do Chamado!");
            if (model.HoraAbertura == null)
                _uow.Notificacao.Add("Informe a Hora da Abertura do Chamado!");
            if (model.ClienteId == 0)
                _uow.Notificacao.Add(" Informe o Cliente do Chamado!");
            if (model.UsuarioAberturaId == 0)
                _uow.Notificacao.Add(" Informe o Usuário de Abertura do Chamado!");
            if (model.TipoId == 0)
                _uow.Notificacao.Add(" Informe o Tipo do Chamado!");
            if (model.StatusId == 0)
                _uow.Notificacao.Add(" Informe o Status do Chamado!");
            if (string.IsNullOrWhiteSpace(model.Descricao))
                _uow.Notificacao.Add(" Informe a Descrição do Chamado!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());
        }

        public void SalvarAplicativo(ChamadoAplicativoInputViewModel chamadoInputModel)
        {
            try
            {
                string codigoUsuario = _uow.RepositorioParametro.ObterPorParametro(54, 0).Valor;
                if (string.IsNullOrWhiteSpace(codigoUsuario))
                    throw new Exception("Informe o Código do Usuário do Aplicativo (parâmetro 54)");

                int.TryParse(codigoUsuario, out int codUsuario);

                var usuario = _uow.RepositorioUsuario.First(x => x.Codigo == codUsuario);

                int idUsuario = usuario.Id;

                var chamado = new Chamado
                {
                    DataAbertura = DateTime.Now,
                    HoraAbertura = TimeSpan.Parse(DateTime.Now.ToShortTimeString()),

                    Contato = chamadoInputModel.Contato,
                    Descricao = chamadoInputModel.Descricao,
                    Nivel = 2,
                    TipoMovimento = 1,
                    Origem = 4,

                    UsuarioAberturaId = idUsuario
                };

                var cliente = _uow.RepositorioCliente.ObterPorDocumento(Funcoes.Utils.FormatarCNPJ(chamadoInputModel.CNPJ));
                if (cliente != null)
                    chamado.ClienteId = cliente.Id;

                var modelTipo = _uow.RepositorioTipo.RetornarUmRegistro(_enumChamadoAtividade);
                if (modelTipo != null)
                    chamado.TipoId = modelTipo.Id;

                var codStatusAbertura = _uow.RepositorioParametro.ObterPorParametro(9, 1).Valor;

                if (string.IsNullOrWhiteSpace(codStatusAbertura))
                    throw new Exception("Informe o código do Status de Abertura. (Parâmetro 9,1)");


                int.TryParse(codStatusAbertura, out int codigoStatusAbertura);
                var status = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusAbertura);
                if (status != null)
                    chamado.StatusId = status.Id;

                Salvar(chamado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ChamadoAnexo> RetornarAnexos(int chamadoId)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Cha_Id as Id,");
            sb.AppendLine(" Cha_DataAbertura as DataAbertura,");
            sb.AppendLine(" Cha_HoraAbertura as HoraAbertura,");
            sb.AppendLine(" Cha_Contato as Contato,");
            sb.AppendLine(" Cli_Nome as NomeCliente,");
            sb.AppendLine(" ChOco_Docto as DoctoOcorrencia,");
            sb.AppendLine(" ChOco_Data as DataOcorrencia, ");
            sb.AppendLine(" ChOco_Anexo as NomeAnexo ");
            sb.AppendLine("FROM Chamado");
            sb.AppendLine(" INNER JOIN Chamado_Ocorrencia ON Cha_Id = ChOco_Chamado");
            sb.AppendLine(" INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine(" WHERE Cha_Id = " + chamadoId);
            sb.AppendLine(" ORDER BY ChOco_Data");

            return _repositoryAnexoReadOnly.GetAll(sb.ToString());
        }

        public ClienteModulo ObterPorModulo(int idCliente, int idModulo)
        {
            var cliente = _uow.RepositorioCliente.First(x => x.Id == idCliente);
            return cliente.ClienteModulos.FirstOrDefault(m => m.ModuloId == idModulo);
        }
    }
}
