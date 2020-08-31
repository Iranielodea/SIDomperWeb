using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoSolicitacao : IServicoSolicitacao
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<SolicitacaoConsultaViewModel> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;
        private List<string> _listaEmail;

        public ServicoSolicitacao(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<SolicitacaoConsultaViewModel> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Solicitacao;
            _listaEmail = new List<string>();
        }

        public Solicitacao Novo(int idUsuario)
        {
            var solicitacao = new Solicitacao();
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            solicitacao.UsuarioAbertura = _uow.RepositorioUsuario.find(idUsuario);
            var codStatus = int.Parse(_uow.RepositorioSolicitacao.StatusAbertura());

            solicitacao.Status = _uow.RepositorioStatus.First(x => x.Codigo == codStatus);
            return solicitacao;
        }

        public Solicitacao Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Solicitacao model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioSolicitacao.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<SolicitacaoConsultaViewModel> Filtrar(SolicitacaoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem)
        {
            var sb = new StringBuilder();

            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            sb.AppendLine(" SELECT");
            sb.AppendLine("  Sol_Id as Id,");
            sb.AppendLine("  Sol_Data as Data,");
            sb.AppendLine("  Sol_Hora as Hora,");
            sb.AppendLine("  Sol_Cliente as ClienteId,");
            sb.AppendLine("  Sol_Status as StatusId,");
            sb.AppendLine("  Sol_Titulo as Titulo,");
            sb.AppendLine("  CASE Sol_Nivel");
            sb.AppendLine("    WHEN 1 THEN '1-Baixo'");
            sb.AppendLine("    WHEN 2 THEN '2-Normal'");
            sb.AppendLine("    WHEN 3 THEN '3-Alto'");
            sb.AppendLine("    WHEN 4 THEN '4-Crítico'");
            sb.AppendLine("  END AS Nivel,");
            sb.AppendLine("  Cli_Codigo as ClienteCodigo,");
            sb.AppendLine("  Cli_Nome as RazaoSocial,");
            sb.AppendLine("  Cli_Fantasia as NomeFantasia,");
            sb.AppendLine("  Sta_Nome as StatusNome,");
            sb.AppendLine("  Tip_Nome as TipoNome,");
            sb.AppendLine("  Ver_Versao as Versao");
            sb.AppendLine(" FROM Solicitacao");
            sb.AppendLine("  INNER JOIN Cliente ON Sol_Cliente = Cli_Id");
            sb.AppendLine("  INNER JOIN Status ON Sol_Status = Sta_Id");
            sb.AppendLine("  LEFT JOIN Tipo ON Sol_Tipo = Tip_Id");
            sb.AppendLine("  LEFT JOIN Versao On Sol_VersaoId = Ver_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Sol_Id > 0");
            }

            sb.AppendLine(FiltrarDados(usuarioId, filtro));

            //_rep.context.Database.SqlQuery<SolicitacaoConsulta>(sb.ToString());

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        private string FiltrarDados(int idUsuario, SolicitacaoFiltroViewModel filtro)
        {
            var sb = new StringBuilder();

            sb.AppendLine(_uow.RepositorioUsuario.PermissaoUsuario(idUsuario));

            if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (filtro.DataInicial.Trim() != "/  /"))
                sb.AppendLine(" AND Sol_Data >=" + Funcoes.Utils.DataIngles(filtro.DataInicial));

            if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (filtro.DataFinal.Trim() != "/  /"))
                sb.AppendLine(" AND Sol_Data <=" + Funcoes.Utils.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioAbertura))
                sb.AppendLine(" AND Sol_UsuarioAbertura IN " + filtro.IdUsuarioAbertura);

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Sol_Cliente IN " + filtro.IdCliente);

            if (!string.IsNullOrWhiteSpace(filtro.IdModulo))
                sb.AppendLine(" AND Sol_Modulo IN " + filtro.IdModulo);

            if (!string.IsNullOrWhiteSpace(filtro.IdProduto))
                sb.AppendLine(" AND Sol_Produto IN " + filtro.IdProduto);

            if (!string.IsNullOrWhiteSpace(filtro.IdAnalista))
                sb.AppendLine(" AND Sol_Analista IN " + filtro.IdAnalista);

            if (!string.IsNullOrWhiteSpace(filtro.IdTipo))
                sb.AppendLine(" AND Sol_Tipo IN " + filtro.IdTipo);

            if (!string.IsNullOrWhiteSpace(filtro.IdDesenvolvedor))
                sb.AppendLine(" AND Sol_Desenvolvedor IN " + filtro.IdDesenvolvedor);

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Sol_Status IN " + filtro.IdStatus);

            //if (filtro.Nivel < 5)
            //    sb.AppendLine(" AND Sol_Nivel = " + filtro.Nivel);

            //if (filtro.ClienteFiltro.UsuarioId != "")
            //    sb.AppendLine(" AND Cli_Usuario IN " + filtro.ClienteFiltro.UsuarioId);

            if (!string.IsNullOrWhiteSpace(filtro.IdVersao))
                sb.AppendLine(" AND Sol_VersaoId IN " + filtro.IdVersao);

            if (filtro.Id > 0)
                sb.AppendLine(" AND Sol_Id = " + filtro.Id);

            return sb.ToString();
        }

        public Solicitacao ObterPorId(int id)
        {
            return _uow.RepositorioSolicitacao.find(id);
        }

        public void Salvar(Solicitacao model, int usuarioId)
        {

            if (model.Data == null)
                _uow.Notificacao.Add("Informe a Data da Abertura!");
            if (model.ClienteId == 0)
                _uow.Notificacao.Add("Informe o Cliente!");
            if (model.UsuarioAberturaId == 0)
                _uow.Notificacao.Add("Informe Usuário da Abertura!");
            if (string.IsNullOrWhiteSpace(model.Titulo))
                _uow.Notificacao.Add("Informe o Título!");
            if (string.IsNullOrWhiteSpace(model.Descricao))
                _uow.Notificacao.Add("Informe a Descrição!");
            if (model.StatusId == 0)
                _uow.Notificacao.Add("Informe o Status!");
            if (model.PrevisaoEntrega != null)
            {
                if (model.PrevisaoEntrega < model.Data)
                    _uow.Notificacao.Add("Previsão de Entrega menor que Data de Abertura!");
            }

            if (!string.IsNullOrWhiteSpace(model.Anexo))
            {
                if (!System.IO.File.Exists(model.Anexo))
                    _uow.Notificacao.Add("Arquivo do Anexo não Existe!");
            }

            int idStatusEncerramento = int.Parse(_uow.RepositorioSolicitacao.StatusEncerramento());

            if (idStatusEncerramento > 0)
            {
                if (idStatusEncerramento == model.StatusId)
                {
                    if (string.IsNullOrWhiteSpace(model.DescricaoLiberacao))
                        _uow.Notificacao.Add("Informe a Descrição da Análise antes de Encerrar!");
                }
            }

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            int id = model.Id;

            if (model.Id == 0)
                model.UsuarioAtendeAtualId = usuarioId;
            else
            {
                var solicitacao = ObterPorId(model.Id);

                solicitacao.AnalistaId = model.AnalistaId;
                solicitacao.Anexo = model.Anexo;
                solicitacao.CategoriaId = model.CategoriaId;
                solicitacao.ClienteId = model.ClienteId;
                solicitacao.Contato = model.Contato;
                solicitacao.Data = model.Data;
                solicitacao.Descricao = model.Descricao;
                solicitacao.DescricaoLiberacao = model.DescricaoLiberacao;
                solicitacao.DesenvolvedorId = model.DesenvolvedorId;
                solicitacao.Hora = model.Hora;
                solicitacao.ModuloId = model.ModuloId;
                solicitacao.Nivel = model.Nivel;
                solicitacao.PrevisaoEntrega = model.PrevisaoEntrega;
                solicitacao.ProdutoId = model.ProdutoId;
                solicitacao.StatusId = model.StatusId;
                solicitacao.TempoPrevisto = model.TempoPrevisto;
                solicitacao.TipoId = model.TipoId;
                solicitacao.Titulo = model.Titulo;
                solicitacao.UsuarioAberturaId = model.UsuarioAberturaId;
                solicitacao.UsuarioAtendeAtualId = model.UsuarioAtendeAtualId;
                solicitacao.Versao = model.Versao;
                solicitacao.VersaoId = model.VersaoId;

                AlterarCronograma(solicitacao, model);
                ExcluirCronograma(solicitacao, model);

                AlterarOcorrencia(solicitacao, model);
                ExcluirOcorrencia(solicitacao, model);
            }

            _uow.RepositorioSolicitacao.Salvar(model);
            _uow.SaveChanges();

            if (id == 0)
            {
                EnvioEmail(model, usuarioId);
            }
        }
        private void ExcluirOcorrencia(Solicitacao solicitacaoBanco, Solicitacao model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in solicitacaoBanco.SolicitacaoCronogramas)
            {
                var dados = model.SolicitacaoCronogramas.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _uow.Executar("DELETE FROM Solicitacao_Ocorrencia WHERE SCro_Id in (" + idDelecao + ")");
        }

        private void AlterarOcorrencia(Solicitacao solicitacaoBanco, Solicitacao model)
        {
            var temp = new SolicitacaoOcorrencia();
            foreach (var item in model.SolicitacaoOcorrencias)
            {
                item.SolicitacaoId = model.Id;

                if (model.Data > item.Data)
                    throw new Exception("Data de Previsão de Início menor que Data de Abertura!");

                if (string.IsNullOrWhiteSpace(item.Descricao))
                    throw new Exception("Informe a Descrição!");

                //if (!string.IsNullOrWhiteSpace(model.Anexo))
                //{
                //    if (!System.IO.File.Exists(model.Anexo))
                //        throw new Exception("Arquivo do Anexo Ocorrência Geral não Existe.!");
                //}

                if (item.Id <= 0)
                {
                    solicitacaoBanco.SolicitacaoOcorrencias.Add(item);
                }
                else
                {
                    temp = solicitacaoBanco.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Data = item.Data;
                        temp.Anexo = item.Anexo;
                        temp.Classificacao = item.Classificacao;
                        temp.Descricao = item.Descricao;
                        temp.Hora = item.Hora;
                        temp.TipoId = item.TipoId;
                        temp.UsuarioId = item.UsuarioId;
                    }
                }
            }
        }

        private void ExcluirCronograma(Solicitacao solicitacaoBanco, Solicitacao model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in solicitacaoBanco.SolicitacaoCronogramas)
            {
                var dados = model.SolicitacaoCronogramas.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _uow.Executar("DELETE FROM Solicitacao_Cronograma WHERE SOCro_Id in (" + idDelecao + ")");
        }

        private void AlterarCronograma(Solicitacao solicitacaoBanco, Solicitacao model)
        {
            var temp = new SolicitacaoCronograma();
            foreach (var item in model.SolicitacaoCronogramas)
            {
                item.SolicitacaoId = model.Id;
                if (item.UsuarioId == 0)
                    throw new Exception("Informe o Usuário!");

                if (item.Data == null)
                    throw new Exception("Informe uma Data!");

                if (item.HoraInicio != null && item.HoraFim != null)
                {
                    if (item.HoraInicio > item.HoraFim)
                        throw new Exception("Hora Inicial maior que Hora Final.");
                }

                if (item.Id <= 0)
                {
                    solicitacaoBanco.SolicitacaoCronogramas.Add(item);
                }
                else
                {
                    temp = solicitacaoBanco.SolicitacaoCronogramas.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Data = item.Data;
                        temp.HoraFim = item.HoraFim;
                        temp.HoraInicio = item.HoraInicio;
                        temp.UsuarioId = item.UsuarioId;
                    }
                }
            }
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public bool PermissaoAbertura(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.PermissaoAbertura(usuario);
        }

        public bool MostrarAnexos(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.MostrarAnexos(usuario);
        }

        public bool PermissaoAnalise(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.SolicitacaoPermissaoAnalise(usuario);
        }

        public bool PermissaoOcorrenciaGeral(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.SolicitacaoPermissaoOcorrenciaGeral(usuario);
        }

        public bool PermissaoOcorrenciaTecnica(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.SolicitacaoPermissaoOcorrenciaTecnica(usuario);
        }

        public bool PermissaoOcorrenciaRegra(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.SolicitacaoPermissaoOcorrenciaRegra(usuario);
        }

        public bool PermissaoStatus(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.SolicitacaoPermissaoStatus(usuario);
        }

        public bool PermissaoSolicitacaoTempo(Usuario usuario, int usuarioId)
        {
            return _uow.RepositorioUsuario.PermissaoSolicitacaoTempo(usuario, usuarioId);
        }

        public bool PermissaoConferenciaTempoGeral(Usuario usuario, int usuarioId)
        {
            return _uow.RepositorioUsuario.PermissaoConferenciaTempoGeral(usuario, usuarioId);
        }

        public bool PermissaoQuadro(Usuario usuario)
        {
            return _uow.RepositorioDepartamento.SolicitacaoPermissaoQuadro(usuario);
        }

        private bool PermissaoSolicitacao(int idUsuario, string permissao)
        {
            var usuarioPermissao = _uow.RepositorioUsuario.ObterPermissaoPorSigla(idUsuario, permissao);
            return (usuarioPermissao != null);
        }

        public string RetornarCaminhoAnexo()
        {
            return _uow.RepositorioParametro.ObterPorParametro(48, 0).Valor;
        }

        private void EnvioEmail(Solicitacao model, int idUsuario)
        {
            var usuario = _uow.RepositorioUsuario.find(idUsuario);
            string sEmail = RetornarEmail(model, idUsuario, usuario);
            string sEmailCliente = RetornarEmailsCliente(idUsuario, model, usuario);

            if (string.IsNullOrWhiteSpace(sEmailCliente))
                sEmailCliente = sEmail;

            if (!string.IsNullOrWhiteSpace(sEmailCliente))
            {
                string assunto = RetornarAssunto(model);
                string texto = TextoEmailCabecalho(model);
                texto += TextoEmailOcorrencia(model);
                texto += MensagemFinal();
                //_uow.RepositorioContaEmail.EnviarEmail(idUsuario, sEmailCliente, sEmail, assunto, texto, "");
            }
        }

        private string TextoEmailOcorrencia(Solicitacao model)
        {
            var sb = new StringBuilder();
            bool primeiraVez = true;
            model.SolicitacaoOcorrencias.Where(c => c.Classificacao == 1).OrderBy(x => x.Data);

            foreach (var item in model.SolicitacaoOcorrencias)
            {
                if (primeiraVez)
                {
                    sb.AppendLine("Ocorrência Geral");
                    primeiraVez = false;
                }
                sb.AppendLine($"Operador : {item.Usuario.Nome}");
                sb.AppendLine($"Data : {item.Data}");
                sb.AppendLine($"Hora : {item.Hora}");
                sb.AppendLine($"Descrição : {item.Descricao}");
            }
            return sb.ToString();
        }

        private string MensagemFinal()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Colocamo-nos a disposição para maiores esclarecimentos.");
            sb.AppendLine("");
            sb.AppendLine("Equipe Domper");
            sb.AppendLine("");
            sb.AppendLine("Esta mensagem é automática e foi gerada pelo Sistema Interno de Solicitações Domper.");
            sb.AppendLine("Por favor não responda este email.");
            return sb.ToString();
        }

        private string TextoEmailCabecalho(Solicitacao model)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Caro(a) : {model.Cliente.Nome} , segue abaixo informações referente a Solicitação realizada na Domper Consultoria e Sistemas:");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine($"Dados da Solicitação ({model.Status.Nome})");
            sb.AppendLine($"Nº da Solicitação : {model.Id.ToString("000000")}");
            sb.AppendLine($"Aberto por : {model.UsuarioAbertura.Nome}");
            sb.AppendLine($"Data Abertura : {model.Data} - Hora: {model.Hora}");
            sb.AppendLine($"Contato : {model.Contato}");
            sb.AppendLine($"Título : {model.Titulo}");
            sb.AppendLine($"Versão em Uso : {model.Versao}");
            sb.AppendLine($"Analista : {model.UsuarioAnalista.Nome}");
            sb.AppendLine($"Tempo Previsto : {model.TempoPrevisto}");
            sb.AppendLine($"Previsão de Entrega : {model.PrevisaoEntrega}");
            sb.AppendLine($"Desenvolvedor : {model.UsuarioDesenvolvedor.Nome}");
            sb.AppendLine($"Versão : {model.VersaoRelacao.VersaoStr}");
            sb.AppendLine($"Descrição : {model.Descricao}");
            sb.AppendLine("");
            return sb.ToString();
        }

        private string RetornarAssunto(Solicitacao model)
        {
            return "Solicitação" + model.Id.ToString("000000") + " DOMPER Consultoria e Sistemas Ltda.";
        }

        private string RetornarEmail(Solicitacao solicitacao, int idUsuario, Usuario usuario)
        {
            string emailUsuario = "";
            if (!string.IsNullOrWhiteSpace(usuario.ContaEmail.Email))
                emailUsuario = usuario.ContaEmail.Email;

            if (string.IsNullOrWhiteSpace(emailUsuario))
                return "";

            RetornarEmailSupervior(solicitacao, idUsuario, usuario);
            RetornarEmailConsultor(solicitacao, idUsuario, usuario);
            RetornarEmailRevenda(solicitacao, idUsuario, usuario);

            string email = OrganizarEmail();
            return email;
        }

        private string OrganizarEmail()
        {
            string email = "";
            foreach (var item in _listaEmail)
            {
                if (email == "")
                    email = email + item;
                else
                    email = email + ";" + item;
            }
            return email;
        }

        private void RetornarEmailRevenda(Solicitacao solicitacao, int idUsuario, Usuario usuarioModel)
        {
            if (solicitacao.Status != null || solicitacao.Status.NotificarRevenda == false)
                return;

            if (solicitacao.Cliente == null)
                return;

            if (solicitacao.Cliente.Revenda == null)
                return;

            string email = _uow.RepositorioRevenda.RetornarEmails(solicitacao.Cliente.Revenda);
            AdicionarEmail(email);
        }

        private void RetornarEmailConsultor(Solicitacao solicitacao, int idUsuario, Usuario usuarioModel)
        {
            if (solicitacao.Status != null || solicitacao.Status.NotificarConsultor == false)
                return;

            string emailCliente = "";
            if (solicitacao.Cliente != null)
            {
                if (solicitacao.Cliente.Usuario != null)
                    emailCliente = solicitacao.Cliente.Usuario.Email;
            }

            AdicionarEmail(emailCliente);
        }

        private void RetornarEmailSupervior(Solicitacao model, int idUsuario, Usuario usuario)
        {
            if (model.Status != null || model.Status.NotificarSupervisor == false)
                return;

            string email = "";
            if (usuario.Departamento == null)
                return;

            if (usuario.Departamento.DepartamentosEmail == null)
                return;

            email = _uow.RepositorioDepartamento.RetornarEmails(usuario.Departamento);

            AdicionarEmail(email);
        }

        private void AdicionarEmail(string email)
        {
            if (!_listaEmail.Contains(email))
                _listaEmail.Add(email);
        }

        private string RetornarEmailsCliente(int idUsuario, Solicitacao model, Usuario usuario)
        {
            string emailUsuario = "";
            if (usuario.ContaEmail != null)
                emailUsuario = usuario.ContaEmail.Email;

            if (string.IsNullOrWhiteSpace(emailUsuario))
                return "";

            if (model.Status != null || model.Status.NotificarCliente == false)
                return "";

            string emailCliente = _uow.RepositorioCliente.EmailsDoCliente(model.Cliente);

            if (string.IsNullOrWhiteSpace(emailCliente))
                emailCliente = emailUsuario;

            return emailCliente;
        }

        public SolicitacaoPermissaoViewModel BuscarPermissoes(int usuarioId)
        {
            var viewModel = new SolicitacaoPermissaoViewModel();

            var usuario = _uow.RepositorioUsuario.find(usuarioId);
            viewModel.PermissaoAbertura = PermissaoAbertura(usuario);
            viewModel.PermissaoAnalise = PermissaoAnalise(usuario);
            viewModel.PermissaoOcorrenciaGeral = PermissaoOcorrenciaGeral(usuario);
            viewModel.PermissaoOcorrenciaRegra = PermissaoOcorrenciaRegra(usuario);
            viewModel.PermissaoOcorrenciaTecnica = PermissaoOcorrenciaTecnica(usuario);
            viewModel.PermissaoStatus = PermissaoStatus(usuario);
            viewModel.PermissaoTempo = PermissaoSolicitacaoTempo(usuario, usuarioId);
            viewModel.PermissaoConfTempoGeral = PermissaoConferenciaTempoGeral(usuario, usuarioId);
            viewModel.MostrarAnexos = MostrarAnexos(usuario);
            viewModel.CaminhoAnexos = RetornarCaminhoAnexo();
            return viewModel;
        }

        private string RetornarSQLQuadro(int idUsuario)
        {
            var sb = new StringBuilder();
            sb.AppendLine(MontarQuadro(idUsuario, "Q01", 12));
            sb.AppendLine(MontarQuadro(idUsuario, "Q02", 13));
            sb.AppendLine(MontarQuadro(idUsuario, "Q03", 14));
            sb.AppendLine(MontarQuadro(idUsuario, "Q04", 15));
            sb.AppendLine(MontarQuadro(idUsuario, "Q05", 16));
            sb.AppendLine(MontarQuadro(idUsuario, "Q06", 17));
            sb.AppendLine(MontarQuadro(idUsuario, "Q07", 19));
            sb.AppendLine(MontarQuadro(idUsuario, "Q08", 20));
            sb.AppendLine(MontarQuadro(idUsuario, "Q09", 21));
            sb.AppendLine(MontarQuadro(idUsuario, "Q10", 22));
            sb.AppendLine(MontarQuadro(idUsuario, "Q11", 23));
            sb.AppendLine(MontarQuadro(idUsuario, "Q12", 24));
            return sb.ToString();
        }

        private string MontarQuadro(int idUsuario, string quadro, int parCodigo)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" '" + quadro + "' As Quadro,");
            sb.AppendLine(" (");
            sb.AppendLine("     SELECT 1 FROM Solicitacao_Tempo");
            sb.AppendLine("         WHERE Sol_Id = STemp_Solicitacao");
            sb.AppendLine("         AND STemp_Data IS NOT NULL");
            sb.AppendLine("         AND STemp_HoraFim IS NULL");
            sb.AppendLine(" ) AS Aberta,");
            sb.AppendLine(" Sol_Id as Id,");
            sb.AppendLine(" Sol_Titulo as Titulo,");
            sb.AppendLine(" Sol_UsuarioAtendeAtual as IdUsuarioAtendeAtual,");
            sb.AppendLine(" Sol_Nivel as Nivel,");
            sb.AppendLine(" Cli_Nome as ClienteNome,");
            sb.AppendLine(" Usu_Nome as UsuarioNome,");
            sb.AppendLine(" Sol_Status as IdStatus");
            sb.AppendLine(" FROM Solicitacao");
            sb.AppendLine(" INNER JOIN Cliente ON Sol_Cliente = Cli_Id");
            sb.AppendLine(" INNER JOIN Status ON Sol_Status = Sta_Id");
            sb.AppendLine(" INNER JOIN Parametros ON Sta_Codigo = COALESCE(Par_Valor, 0)");
            sb.AppendLine(" LEFT JOIN Usuario ON Sol_UsuarioAtendeAtual = Usu_Id");
            sb.AppendLine(" WHERE Par_Codigo = " + parCodigo);
            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" SELECT 1 FROM Usuario WHERE((Cli_Revenda = Usu_Revenda) OR(Usu_Revenda IS NULL))");
            sb.AppendLine(" AND Usu_Id = " + idUsuario + ")");
            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" SELECT 1 FROM Usuario WHERE((Cli_Id = Usu_Cliente) OR(Usu_Cliente IS NULL))");
            sb.AppendLine(" AND Usu_Id = " + idUsuario + ")");

            if (parCodigo < 24)
                sb.AppendLine(" UNION ");

            return sb.ToString();
        }
    }
}
