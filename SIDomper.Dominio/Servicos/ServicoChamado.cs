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
    public class ServicoChamado : IServicoChamado
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ChamadoConsultaViewModel> _repositoryReadOnly;
        private readonly IRepositoryReadOnly<ChamadoAplicativoViewModel> _repositoryAplicativoReadOnly;
        private readonly IRepositoryReadOnly<ChamadoAnexo> _repositoryAnexoReadOnly;
        private readonly IRepositoryReadOnly<ChamadoOcorrencia> _repositoryProbemaSolucaoReadOnly;
        private readonly IRepositoryReadOnly<QuadroViewModelChamado> _repositoryQuadroReadOnly;
        private readonly IServicoEscala _servicoEscala;
        List<string> _listaEmail;
        List<string> _listaEmailCliente;

        public ServicoChamado(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ChamadoConsultaViewModel> repositoryReadOnly,
           IRepositoryReadOnly<ChamadoAplicativoViewModel> repositoryAplicativoReadOnly,
           IRepositoryReadOnly<ChamadoAnexo> repositoryAnexoReadOnly,
           IRepositoryReadOnly<ChamadoOcorrencia> repositoryProbemaSolucaoReadOnly,
           IRepositoryReadOnly<QuadroViewModelChamado> repositoryQuadroReadOnly,
           IServicoEscala servicoEscala
           )
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _repositoryAplicativoReadOnly = repositoryAplicativoReadOnly;
            _repositoryAnexoReadOnly = repositoryAnexoReadOnly;
            _repositoryProbemaSolucaoReadOnly = repositoryProbemaSolucaoReadOnly;
            _repositoryQuadroReadOnly = repositoryQuadroReadOnly;
            _servicoEscala = servicoEscala;
            _listaEmail = new List<string>();
            _listaEmailCliente = new List<string>();
        }

        public ChamadoQuadroViewModel AbrirQuadro(int idUsuario, int idRevenda, EnumChamado enumChamado)
        {
            var quadroViewModel = new ChamadoQuadroViewModel();

            var lista = QuadroChamado(idUsuario, idRevenda, enumChamado).ToList();

            quadroViewModel.Quadro1 = lista.Where(x => x.QuadroTela == "Q1").OrderBy(x => x.Id).ToList();
            quadroViewModel.Quadro2 = lista.Where(x => x.QuadroTela == "Q2").OrderBy(x => x.Id).ToList();
            quadroViewModel.Quadro3 = lista.Where(x => x.QuadroTela == "Q3").OrderBy(x => x.Id).ToList();
            quadroViewModel.Quadro4 = lista.Where(x => x.QuadroTela == "Q4").OrderBy(x => x.Id).ToList();
            quadroViewModel.Quadro5 = lista.Where(x => x.QuadroTela == "Q5").OrderBy(x => x.Id).ToList();
            quadroViewModel.Quadro6 = lista.Where(x => x.QuadroTela == "Q6").OrderBy(x => x.Id).ToList();

            var listaStatus = BuscarTitulosQuadro(enumChamado);

            quadroViewModel.Titulo1 = listaStatus[0].Nome;
            quadroViewModel.Titulo2 = listaStatus[1].Nome;
            quadroViewModel.Titulo3 = listaStatus[2].Nome;
            quadroViewModel.Titulo4 = listaStatus[3].Nome;
            quadroViewModel.Titulo5 = listaStatus[4].Nome;
            quadroViewModel.Titulo6 = listaStatus[5].Nome;

            quadroViewModel.CodigoStatusQuadro1 = listaStatus[0].Codigo;
            quadroViewModel.CodigoStatusQuadro2 = listaStatus[1].Codigo;
            quadroViewModel.CodigoStatusQuadro3 = listaStatus[2].Codigo;
            quadroViewModel.CodigoStatusQuadro4 = listaStatus[3].Codigo;
            quadroViewModel.CodigoStatusQuadro5 = listaStatus[4].Codigo;
            quadroViewModel.CodigoStatusQuadro6 = listaStatus[5].Codigo;

            int codigoStatusAbertura;
            int codigoStatusOcorrencia;

            if (enumChamado == EnumChamado.Chamado)
            {
                int.TryParse(StatusAbertura(), out codigoStatusAbertura);
                int.TryParse(StatusAtendimentoChamado(), out codigoStatusOcorrencia);
            }
            else
            {
                int.TryParse(StatusAberturaAtividade(), out codigoStatusAbertura);
                int.TryParse(StatusAtendimentoAtividade(), out codigoStatusOcorrencia);
            }

            var status = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusOcorrencia);

            string statusAbertura = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusAbertura).Nome;

            string statusOcorrencia = status.Nome; // _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusOcorrencia).Nome;
            quadroViewModel.StatusChamadoAtendimentoCodigo = status.Codigo;

            PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo1, quadroViewModel.Quadro1);
            PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo2, quadroViewModel.Quadro2);
            PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo3, quadroViewModel.Quadro3);
            PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo4, quadroViewModel.Quadro4);
            PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo5, quadroViewModel.Quadro5);
            PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo6, quadroViewModel.Quadro6);

            return quadroViewModel;
        }

        public Chamado Editar(int id, int idUsuario, EnProgramas enProgramas, ref string mensagem)
        {
            mensagem = "OK";
            var model = ObterPorId(id);
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, enProgramas))
            {
                mensagem = Mensagem.UsuarioSemPermissao;
            }
            else
            {
                if (model.UsuarioAberturaId != idUsuario)
                    mensagem = Mensagem.UsuarioSemPermissao;
            }

            return model;
        }

        public void Excluir(Chamado model, int idUsuario, EnProgramas enProgramas)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, enProgramas))
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

            if (filtro.Id > 0)
                sb.AppendLine(" WHERE Cha_Id = " + filtro.Id);
            else
            {

                if (!string.IsNullOrWhiteSpace(texto))
                    sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
                else
                {
                    sb.AppendLine(" WHERE Cha_Id > 0");
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
            }

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Chamado Novo(int idUsuario, bool quadro, int idClienteAgendamento, int idAgendamento, EnProgramas enProgramas, EnumChamado enumChamado)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var model = new Chamado();
            var modelTipo = _uow.RepositorioTipo.RetornarUmRegistro(enumChamado);
            if (modelTipo != null)
                model.Tipo = modelTipo;

            var usuario = _uow.RepositorioUsuario.find(idUsuario);
            if (usuario != null)
            {
                model.UsuarioAbertura = usuario;
                if (usuario.ClienteId != null && usuario.ClienteId > 0)
                    model.Cliente = usuario.Clientes.FirstOrDefault(x => x.Id == usuario.ClienteId.Value);
            }

            var obsModel = _uow.RepositorioObservacao.ObterPadrao((int)enumChamado);
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

        public void Relatorio(int idUsuario, EnProgramas enProgramas)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, enProgramas))
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
            sb.AppendLine(" AND Cha_TipoMovimento = 1");
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

                    AlterarOcorrencia(chamado, model);
                    ExcluirOcorrencias(chamado, model);
                    ExcluirOcorrenciaColaborador(chamado, model);

                    _uow.RepositorioChamado.Salvar(model);
                }

                // O Status do Chamado é salvo via trigger na tabela Chamado

                _uow.SaveChanges();

                if (id <= 0) // inclusao
                {
                    if (ocorrencia == false)
                    {
                        //var usuario = _uow.RepositorioUsuario.find(idUsuario);

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

        private void ExcluirOcorrenciaColaborador(Chamado chamadoBanco, Chamado model)
        {
            string idDelecao = "";
            int i = 1;

            var listaColaboradores = new List<ChamadoOcorrenciaColaborador>();
            foreach (var item in model.ChamadoOcorrencias)
            {
                foreach (var item2 in item.ChamadoOcorrenciaColaboradores)
                {
                    listaColaboradores.Add(item2);
                }
            }

            foreach (var ocorrencia in chamadoBanco.ChamadoOcorrencias)
            {
                foreach (var colaborador in ocorrencia.ChamadoOcorrenciaColaboradores)
                {
                    var dados = listaColaboradores.FirstOrDefault(x => x.Id == colaborador.Id);
                    if (dados == null)
                    {
                        if (colaborador.Id > 0)
                        {
                            if (i == 1)
                                idDelecao += colaborador.Id;
                            else
                                idDelecao += "," + colaborador.Id;
                            i++;
                        }
                    }
                }
            }

            if (idDelecao != "")
                _uow.Executar("DELETE FROM Chamado_Ocorr_Colaborador WHERE ChaOCol_Id in (" + idDelecao + ")");
        }

        private void ExcluirOcorrencias(Chamado chamadoBanco, Chamado model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in chamadoBanco.ChamadoOcorrencias)
            {
                var dados = model.ChamadoOcorrencias.FirstOrDefault(x => x.Id == itemBanco.Id);
                if (dados == null)
                {
                    if (itemBanco.Id > 0)
                    {
                        if (i == 1)
                            idDelecao += itemBanco.Id;
                        else
                            idDelecao += "," + itemBanco.Id;
                        i++;
                    }
                }
            }

            if (idDelecao != "")
                _uow.Executar("DELETE FROM Chamado_Ocorrencia WHERE ChOco_Id in (" + idDelecao + ")");
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

        public IEnumerable<SMSOutPutViewModel> EnviarSMS(int idChamado)
        {
            var lista = new List<SMSOutPutViewModel>();

            var numeroTelefone = _servicoEscala.EnviarSMS();
            if (numeroTelefone != "")
            {
                var sms = new SMSOutPutViewModel();
                sms.msg = "Novo Chamado ID: " + idChamado.ToString("000000");
                sms.number = numeroTelefone;

                lista.Add(sms);
            }
            return lista.ToArray();
        }

        public void UpdateHoraUsuarioAtual(int idChamado, EnumChamado enumChamado, int idUsuario, int idStatus)
        {
            string codigoStatus = "";

            if (enumChamado == EnumChamado.Chamado)
                codigoStatus = _uow.RepositorioChamado.StatusAtendimentoChamado();
            else
                codigoStatus = _uow.RepositorioChamado.StatusAtendimentoAtividade();

            if (!string.IsNullOrWhiteSpace(codigoStatus))
            {
                int.TryParse(codigoStatus, out int codStatus);

                var modelStatus = _uow.RepositorioStatus.First(x => x.Codigo == codStatus);

                if (modelStatus == null)
                    throw new Exception("Informe o Status Atendimento na Tabela de Parâmetros !");

                var model = _uow.RepositorioChamado.First(x => x.Id == idChamado && x.StatusId == idStatus && x.UsuarioAtendeAtualId == idUsuario);
                if (model != null)
                {
                    DateTime hora = DateTime.Now;
                    model.HoraAtendeAtual = TimeSpan.Parse(hora.ToShortTimeString());
                    model.StatusId = idStatus;
                    model.UsuarioAtendeAtualId = idUsuario;
                    model.Id = idChamado;

                    Salvar(model);
                }
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

            string email = _uow.RepositorioRevenda.RetornarEmails(model.Cliente.Revenda);

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

            string email = _uow.RepositorioDepartamento.RetornarEmails(usuario.Departamento);

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

        private void AlterarOcorrencia(Chamado chamadoBanco, Chamado model)
        {
            var temp = new ChamadoOcorrencia();
            foreach (var item in model.ChamadoOcorrencias)
            {
                item.HoraFim = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                if (item.UsuarioId == 0)
                    throw new Exception("Informe o Usuário!");

                if (item.Data < model.DataAbertura)
                    throw new Exception("Data de Ocorrência menor que Data de Abertura!");

                //TODO: ver esta consistencia da hora final
                //if (item.HoraInicio > item.HoraFim)
                //    throw new Exception("Hora Inicial maior que Hora Final na Ocorrência!");

                if (string.IsNullOrWhiteSpace(item.DescricaoTecnica) && string.IsNullOrWhiteSpace(item.DescricaoSolucao))
                    throw new Exception("Informe uma descrição!");

                double HoraInicio = Funcoes.Utils.HoraToDecimal(item.HoraInicio.ToString());
                double HoraFim = Funcoes.Utils.HoraToDecimal(item.HoraFim.ToString());

                item.TotalHoras = HoraFim - HoraInicio;

                if (item.Id <= 0)
                    chamadoBanco.ChamadoOcorrencias.Add(item);
                else
                {
                    temp = chamadoBanco.ChamadoOcorrencias.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Anexo = item.Anexo;
                        temp.Data = item.Data;
                        temp.DescricaoSolucao = item.DescricaoSolucao;
                        temp.DescricaoTecnica = item.DescricaoTecnica;
                        temp.Documento = item.Documento;
                        temp.HoraFim = item.HoraFim;
                        temp.HoraInicio = item.HoraInicio;
                        temp.TotalHoras = item.TotalHoras;
                        temp.UsuarioColab1 = item.UsuarioColab1;
                        temp.UsuarioColab2 = item.UsuarioColab2;
                        temp.UsuarioColab3 = item.UsuarioColab3;
                        temp.UsuarioId = item.UsuarioId;
                        temp.Versao = item.Versao;

                        AlterarOcorrenciaColaborador(temp, item);
                    }
                }
            }
        }

        private void AlterarOcorrenciaColaborador(ChamadoOcorrencia chamadoOcorrenciaBanco, ChamadoOcorrencia model)
        {
            foreach (var colaborador in model.ChamadoOcorrenciaColaboradores)
            {
                if (colaborador.Id <= 0)
                {
                    chamadoOcorrenciaBanco.ChamadoOcorrenciaColaboradores.Add(colaborador);
                }
                else
                {
                    var temp = chamadoOcorrenciaBanco.ChamadoOcorrenciaColaboradores.FirstOrDefault(x => x.Id == colaborador.Id);
                    if (temp != null)
                    {
                        temp.HoraInicio = colaborador.HoraInicio;
                        temp.HoraFim = colaborador.HoraFim;
                        temp.TotalHoras = colaborador.TotalHoras;
                        temp.UsuarioId = colaborador.UsuarioId;
                    }
                }
            }
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

        public int SalvarAplicativo(ChamadoAplicativoInputViewModel chamadoInputModel)
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
                    TipoId = 2,

                    UsuarioAberturaId = idUsuario
                };

                var cliente = _uow.RepositorioCliente.ObterPorDocumento(Funcoes.Utils.FormatarCNPJ(chamadoInputModel.CNPJ));
                if (cliente != null)
                    chamado.ClienteId = cliente.Id;

                //var modelTipo = _uow.RepositorioTipo.RetornarUmRegistro(EnumChamado.Chamado);
                //if (modelTipo != null)
                //    chamado.TipoId = modelTipo.Id;

                var codStatusAbertura = _uow.RepositorioChamado.StatusAbertura();

                if (string.IsNullOrWhiteSpace(codStatusAbertura))
                    throw new Exception("Informe o código do Status de Abertura. (Parâmetro 9,1)");


                int.TryParse(codStatusAbertura, out int codigoStatusAbertura);
                var status = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusAbertura);
                if (status != null)
                    chamado.StatusId = status.Id;

                Salvar(chamado);

                return chamado.Id;
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

        public string CaminhoAnexo()
        {
            return _uow.RepositorioChamado.CaminhoAnexo();
        }

        public IEnumerable<ChamadoOcorrencia> ListarProblemaSolucao(ChamadoFiltro filtro, string texto, int idUsuario, EnumChamado tipo)
        {
            string sConsulta = _uow.RepositorioUsuario.PermissaoUsuario(idUsuario);

            var sb = new StringBuilder();

            sb.AppendLine(" SELECT ");
            sb.AppendLine("   ChOco_Chamado,");
            sb.AppendLine("   ChOco_Data,");
            sb.AppendLine("   ChOco_HoraInicio,");
            sb.AppendLine("   ChOco_HoraFim,");
            sb.AppendLine("   ChOco_DescricaoSolucao,");
            sb.AppendLine("   ChOco_DescricaoTecnica,");
            sb.AppendLine("   Usu_Nome");
            sb.AppendLine(" FROM Chamado_Ocorrencia");
            sb.AppendLine("   INNER JOIN Chamado ON ChOco_Chamado = Cha_Id");
            sb.AppendLine("   INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("   INNER JOIN Usuario ON ChOco_Usuario = Usu_Id	");
            sb.AppendLine(" WHERE ((ChOco_DescricaoTecnica LIKE " + texto + ") OR (ChOco_DescricaoSolucao LIKE " + texto + "))");
            sb.AppendLine(sConsulta);

            if (tipo == EnumChamado.Chamado)
                sb.AppendLine(" AND cha_TipoMovimento = 1");
            else
                sb.AppendLine(" AND cha_TipoMovimento = 2");

            if (filtro.IdCliente != "")
                sb.AppendLine(" AND Cha_Cliente IN " + filtro.IdCliente);

            sb.AppendLine(" ORDER BY ChOco_Data");

            return _repositoryProbemaSolucaoReadOnly.GetAll(sb.ToString());
        }

        private List<Status> BuscarTitulosQuadro(EnumChamado enumChamado)
        {
            var listaParametros = new List<Parametro>();
            if (enumChamado == EnumChamado.Chamado)
                listaParametros = BuscarTitulosChamados().ToList();
            else
                listaParametros = BuscarTitulosAtividades().ToList();

            var listaStatus = _uow.RepositorioStatus.Get(x => x.Ativo == true);
            var lista = new List<Status>();

            foreach (var item in listaParametros)
            {
                int codigo = Convert.ToInt32(item.Valor);
                var model = listaStatus.First(x => x.Codigo == codigo);
                lista.Add(model);
            }

            return lista;
        }

        private IEnumerable<Parametro> BuscarTitulosChamados()
        {
            var parametro = _uow.RepositorioParametro.Get(x => x.Codigo == 3 || x.Codigo == 4 || x.Codigo == 5 || x.Codigo == 6 || x.Codigo == 7 || x.Codigo == 8);
            return parametro.OrderBy(x => x.Codigo);
        }

        private IEnumerable<Parametro> BuscarTitulosAtividades()
        {
            var parametro = _uow.RepositorioParametro.Get(x => x.Codigo == 25 || x.Codigo == 26 || x.Codigo == 27 || x.Codigo == 28 || x.Codigo == 29 || x.Codigo == 30);
            return parametro.OrderBy(x => x.Codigo);
        }

        private void PreencherQuadro(string nomeStatusAbertura, string nomeStatusOcorrencia, string tituloQuadro, List<QuadroViewModelChamado> quadro)
        {
            /*
                    se titulo1 = statusAbertura
                        ler quadro1 calcularTempo
                    se titulo1 = statusOcorrencia
                        ler quadro1 calcularPar10
                    se nao
                        ler quadro1 = tempoOutro
                 */

            foreach (var item in quadro)
            {
                try
                {
                    if (tituloQuadro == nomeStatusAbertura)
                        item.Tempo = CalcularTempo(DateTime.Parse(item.DataAbertura.ToString()), TimeSpan.Parse(item.HoraAbertura.ToString()));
                    else if (tituloQuadro == nomeStatusOcorrencia)
                        item.Tempo = CalcularTempoParametro10(TimeSpan.Parse(item.HoraAtendeAtual.ToString()));
                    else
                        item.Tempo = CalcularTempo(DateTime.Parse(item.UltimaData), TimeSpan.Parse(item.UltimaHora.ToString()));
                }
                catch (Exception)
                {
                    item.Tempo = "";
                }
            }
        }

        public string CalcularTempoParametro10(TimeSpan horaAtendimento)
        {
            try
            {
                TimeSpan horaAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                TimeSpan tempo = Funcoes.Utils.CalcularHoras(horaAtual, horaAtendimento);
                return Funcoes.Utils.FormatarHora(tempo);
            }
            catch
            {
                return "00:00";
            }
        }

        public string CalcularTempo(DateTime dataChamado, TimeSpan horaChamado)
        {
            try
            {
                if (DateTime.Now.Date == dataChamado)
                {
                    TimeSpan horaAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                    TimeSpan hora = Funcoes.Utils.CalcularHoras(horaChamado, horaAtual);
                    return Funcoes.Utils.FormatarHora(hora);
                }
                else
                {
                    double dias = Funcoes.Utils.CalcularDatas(dataChamado, DateTime.Now.Date);
                    return dias.ToString();
                }
            }
            catch
            {
                return "00:00";
            }
        }

        public void NovoChamadoQuadro(ChamadoViewModel model, EnumChamado enChamadoAtividade, int idEncerramento)
        {
            string codStatus = "0";
            if (enChamadoAtividade == EnumChamado.Chamado)
                codStatus = _uow.RepositorioChamado.StatusAbertura();

            if (idEncerramento > 0 || enChamadoAtividade == EnumChamado.Atividade)
                codStatus = _uow.RepositorioChamado.StatusAberturaAtividade();

            int.TryParse(codStatus, out int CodStatus);

            if (CodStatus == 0)
                throw new Exception("Informe o Status para abertura nos Parâmetros do Sistema!");
            else
            {
                var Status = _uow.RepositorioStatus.First(x => x.Codigo == CodStatus);
                if (Status != null)
                {
                    model.StatusId = Status.Id;
                    model.CodStatus = Status.Codigo;
                    model.NomeStatus = Status.Nome;
                }
            }
        }

        private IEnumerable<QuadroViewModelChamado> QuadroChamado(int idUsuario, int idRevenda, EnumChamado tipo)
        {
            var sb = new StringBuilder();

            if (tipo == EnumChamado.Chamado)
                sb.AppendLine(RetornarChamadoQuadro(idUsuario, idRevenda));
            else
                sb.AppendLine(RetornarAtividadeQuadro(idUsuario, idRevenda));

            var lista = _repositoryQuadroReadOnly.GetAll(sb.ToString());

            return lista;
        }

        private string RetornarAtividadeQuadro(int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 25, "'Q1' AS QuadroTela,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 26, "'Q2' AS QuadroTela,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 27, "'Q3' AS QuadroTela,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 28, "'Q4' AS QuadroTela,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 29, "'Q5' AS QuadroTela,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 30, "'Q6' AS QuadroTela,", EnumChamado.Atividade));

            return sb.ToString();
        }

        private string RetornarChamadoQuadro(int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 3, "'Q1' AS QuadroTela,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 4, "'Q2' AS QuadroTela,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 5, "'Q3' AS QuadroTela,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 6, "'Q4' AS QuadroTela,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 7, "'Q5' AS QuadroTela,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 8, "'Q6' AS QuadroTela,", EnumChamado.Chamado));

            return sb.ToString();
        }

        private string RetornarSQLQuadro(int idUsuario, int idRevenda, int codigoParametro, string campoQuadro, EnumChamado tipo)
        {
            string sConsulta = _uow.RepositorioUsuario.PermissaoUsuario(idUsuario);

            var sb = new StringBuilder();

            sb.AppendLine(" SELECT");
            sb.Append(campoQuadro);
            sb.AppendLine("	Cha_Id as Id,");
            sb.AppendLine("	Cha_DataAbertura as DataAbertura,");
            sb.AppendLine("	Cha_HoraAbertura as HoraAbertura,");
            sb.AppendLine("	Cli_Nome as NomeCliente,");
            sb.AppendLine("	Cli_Perfil as Perfil,");
            sb.AppendLine("	CASE cha_Nivel");
            sb.AppendLine("		WHEN 1 THEN '1-Baixo'");
            sb.AppendLine("		WHEN 2 THEN '2-Normal'");
            sb.AppendLine("		WHEN 3 THEN '3-Alto'");
            sb.AppendLine("		WHEN 4 THEN '4-Crítico'");
            sb.AppendLine("	END as NivelDescricao,");
            sb.AppendLine("  Cha_Nivel as Nivel,");
            sb.AppendLine("  Cha_UsuarioAtendeAtual as UsuarioAtendeAtualId,");
            sb.AppendLine("  Sta_Codigo as CodigoStatus,");
            sb.AppendLine("  Cli_Codigo as CodigoCliente,");
            sb.AppendLine("	Tip_Nome as NomeTipo,");
            sb.AppendLine("  UltimaHora = dbo.Func_Chamado_BuscarUltimaHoraOcorrencia (Cha_Id),");
            sb.AppendLine("	cha_HoraAtendeAtual as HoraAtendeAtual,");
            sb.AppendLine("  (");
            sb.AppendLine("	   SELECT MAX(CHAO.ChOco_Data) FROM dbo.Chamado_Ocorrencia AS CHAO");
            sb.AppendLine("		WHERE CHAO.ChOco_Chamado = dbo.Chamado.Cha_Id");
            sb.AppendLine(" 	) AS UltimaData,");
            sb.AppendLine("  Par_Codigo as CodigoParametro,");
            sb.AppendLine("	Usu_Nome as NomeUsuario");
            sb.AppendLine("FROM Chamado");
            sb.AppendLine("	INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("	INNER JOIN Tipo ON Cha_Tipo = Tip_Id");
            sb.AppendLine("	INNER JOIN Status ON Cha_Status = Sta_Id");
            sb.AppendLine("	LEFT JOIN Parametros ON Sta_Codigo = COALESCE(Par_Valor, 0)");
            sb.AppendLine("  LEFT JOIN Usuario ON Cha_UsuarioAtendeAtual = Usu_Id");
            sb.AppendLine("WHERE par_Codigo = " + codigoParametro);
            sb.AppendLine(sConsulta);

            if (idRevenda > 0)
                sb.AppendLine("AND (Cli_Revenda = " + idRevenda + ")");

            sb.AppendLine(" --=============================================================================");

            if (tipo == EnumChamado.Chamado)
            {
                if (codigoParametro < 8)
                    sb.AppendLine(" UNION ");
            }
            else
            {
                if (codigoParametro < 30)
                    sb.AppendLine(" UNION ");
            }
            return sb.ToString();
        }

        public string StatusAbertura()
        {
            return _uow.RepositorioChamado.StatusAbertura();
        }

        public string StatusAtendimentoChamado()
        {
            return _uow.RepositorioChamado.StatusAtendimentoChamado();
        }

        public string StatusAberturaAtividade()
        {
            return _uow.RepositorioChamado.StatusAberturaAtividade();
        }

        public string StatusAtendimentoAtividade()
        {
            return _uow.RepositorioChamado.StatusAtendimentoAtividade();
        }

        public bool PermissaoAlterarDataHoraChamado(int idUsuario)
        {
            return PermissaoChamado(idUsuario, "Lib_Chamado_Ocorr_Alt_Data_Hora");
        }

        private bool PermissaoChamado(int idUsuario, string permissao)
        {
            var usuarioPermissao = _uow.RepositorioUsuario.ObterPermissaoPorSigla(idUsuario, permissao);
            return (usuarioPermissao != null);
        }

        public bool PermissaoOcorrenciaChamadoAlterar(int idUsuario)
        {
            return PermissaoChamado(idUsuario, "Lib_Chamado_Ocorr_Alt");
        }

        public bool PermissaoOcorrenciaChamadoExcluir(int idUsuario)
        {
            return PermissaoChamado(idUsuario, "Lib_Chamado_Ocorr_Exc");
        }

        public bool PermissaoAlterarDataHoraAtividade(int idUsuario)
        {
            return PermissaoChamado(idUsuario, "Lib_Atividade_Ocorr_Alt_Data_Hora");
        }

        public bool PermissaoOcorrenciaAlterarAtividade(int idUsuario)
        {
            return PermissaoChamado(idUsuario, "Lib_Atividade_Ocorr_Alt");
        }

        public bool PermissaoOcorrenciaAtividadeExcluir(int idUsuario)
        {
            return PermissaoChamado(idUsuario, "Lib_Atividade_Ocorr_Exc");
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            return _uow.RepositorioUsuario.find(id);
        }

        private bool VerificarChamadoAberto(int idUsuario)
        {
            var sql = VerificarChamadoAtividadEmAberto(EnumChamado.Chamado, 2, idUsuario);
            var resultado = _repositoryReadOnly.GetAll(sql);
            return (resultado.FirstOrDefault().Id > 0);
        }

        private bool VerificarAtividadeAberto(int idUsuario)
        {
            var sql = VerificarChamadoAtividadEmAberto(EnumChamado.Atividade, 28, idUsuario);

            var resultado = _repositoryReadOnly.GetAll(sql);
            return (resultado.FirstOrDefault().Id > 0);
        }

        private string VerificarChamadoAtividadEmAberto(EnumChamado enumChamado, int idStatus, int idUsuario)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT COUNT(Cha_Id) AS Id FROM CHAMADO");
            sb.AppendLine($" WHERE Cha_Status = {idStatus}"); // (28=Atividade) (2-Chamado)
            sb.AppendLine($" AND Cha_TipoMovimento = {enumChamado}"); // (2=Atividade) (1=Chamado)
            sb.AppendLine($" AND cha_UsuarioAtendeAtual = {idUsuario}");
            return sb.ToString();
        }

        private bool VerificarSolicitacaoAberto(int idUsuario)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT TOP(1) STemp_Solicitacao AS Id FROM Solicitacao_Tempo");
            sb.AppendLine(" INNER JOIN Solicitacao_Ocorrencia ON STemp_Solicitacao = SOcor_Solicitacao");
            sb.AppendLine(" INNER JOIN Solicitacao ON SOcor_Solicitacao = Sol_Id");
            sb.AppendLine($" WHERE STemp_UsuarioOperacional = {idUsuario}");
            sb.AppendLine("  AND Sol_Status IN (14,16,18)");
            sb.AppendLine("  AND STemp_HoraFim IS NULL");

            var resultado = _repositoryReadOnly.GetAll(sb.ToString());
            return (resultado.FirstOrDefault().Id > 0);
        }

        public ChamadoConsultaViewModel VerificarTarefaEmAberto(int idUsuario, EnProgramas enProgramas)
        {
            bool resultado = false;
            if (enProgramas == EnProgramas.Chamado)
            {
                resultado = VerificarAtividadeAberto(idUsuario);
                if (resultado == false)
                    resultado = VerificarSolicitacaoAberto(idUsuario);
            }

            if (enProgramas == EnProgramas.Atividade)
            {
                resultado = VerificarChamadoAberto(idUsuario);
                if (resultado == false)
                    resultado = VerificarSolicitacaoAberto(idUsuario);
            }

            if (enProgramas == EnProgramas.Solicitacao)
            {
                resultado = VerificarAtividadeAberto(idUsuario);
                if (resultado == false)
                    resultado = VerificarChamadoAberto(idUsuario);
            }

            var consulta = new ChamadoConsultaViewModel();

            if (resultado)
                consulta.Id = 1;
            else
                consulta.Id = 0;

            return consulta;
        }

        public bool PermissaoChamadoQuadro(Usuario usuario)
        {
            if (usuario.Adm)
                return true;
            return usuario.Departamento.ChamadoQuadro;
        }

        public bool PermissaoAtividadeQuadro(Usuario usuario)
        {
            if (usuario.Adm)
                return true;
            return usuario.Departamento.AtividadeQuadro;
        }
    }
}
