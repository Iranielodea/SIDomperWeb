using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.EF;
using SIDomper.Infra.RepositorioDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace SIDomper.Servicos.Regras
{
    public class SolicitacaoServico
    {
        private readonly SolicitacaoEF _rep;
        private readonly SolicitacaoOcorrenciaEF _repOcorrencia;
        private readonly SolicitacaoCronogramaEF _repCronograma;
        private readonly SolicitacaoStatusEF _repSolicitacaoStatus;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;
        private readonly ParametroServico _parametro;
        private readonly UsuarioPermissaoServico _usuarioPermissao;
        private readonly SolicitacaoRepositorioDapper _solicitacaoRepositorioDapper;
        List<string> _listaEmail;

        public SolicitacaoServico()
        {
            _rep = new SolicitacaoEF();
            _tipoPrograma = EnProgramas.Solicitacao;
            _repUsuario = new UsuarioServico();
            _parametro = new ParametroServico();
            _listaEmail = new List<string>();
            _usuarioPermissao = new UsuarioPermissaoServico();
            _solicitacaoRepositorioDapper = new SolicitacaoRepositorioDapper();
            _repOcorrencia = new SolicitacaoOcorrenciaEF();
            _repCronograma = new SolicitacaoCronogramaEF();
            _repSolicitacaoStatus = new SolicitacaoStatusEF();
        }

        public Solicitacao Novo(int usuarioId)
        {
            var usuario = _repUsuario.ObterPorId(usuarioId);

            _repUsuario.PermissaoMensagem(usuario.Id, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new Solicitacao();

            model.UsuarioAbertura = usuario;
            //model.UsuarioAberturaId = usuario.Id;
            //model.UsuarioAbertura.Nome = usuario.Nome;
            //model.UsuarioAbertura.Codigo = usuario.Codigo;
            model.Status = StatusAbertura();

            return model;
        }

        public Solicitacao Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);
        }

        public IEnumerable<SolicitacaoConsultaViewModel> Filtrar(SolicitacaoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem)
        {
            return _solicitacaoRepositorioDapper.Filtrar(filtro, campo, texto, usuarioId, contem);
        }

        public Solicitacao ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public void Excluir(int idUsuario, Solicitacao model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Solicitacao model, int idUsuario)
        {
            if (model.Data == null)
                throw new Exception("Informe a Data da Abertura!");
            if (model.ClienteId == 0)
                throw new Exception("Informe o Cliente!");
            if (model.UsuarioAberturaId == 0)
                throw new Exception("Informe Usuário da Abertura!");
            if (string.IsNullOrWhiteSpace(model.Titulo))
                throw new Exception("Informe o Título!");
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");
            if (model.StatusId == 0)
                throw new Exception("Informe o Status!");
            if (model.PrevisaoEntrega != null)
            {
                if (model.PrevisaoEntrega < model.Data)
                    throw new Exception("Previsão de Entrega menor que Data de Abertura!");
            }

            if (!string.IsNullOrWhiteSpace(model.Anexo))
            {
                if (!System.IO.File.Exists(model.Anexo))
                    throw new Exception("Arquivo do Anexo não Existe!");
            }

            int idStatusEncerramento = StatusEncerramento();

            if (idStatusEncerramento > 0)
            {
                if (idStatusEncerramento == model.StatusId)
                {
                    if (string.IsNullOrWhiteSpace(model.DescricaoLiberacao))
                        throw new Exception("Informe a Descrição da Análise antes de Encerrar!");
                }
            }

            using (var trans = new TransactionScope())
            {
                if (model.Id == 0)
                {
                    model.UsuarioAtendeAtualId = idUsuario;
                }
                else
                {
                    AlterarCronograma(model);
                    ExcluirCronograma(model);

                    AlterarOcorrencia(model);
                    ExcluirOcorrencias(model);
                }
                _rep.Salvar(model);
                _rep.Commit();
                _repOcorrencia.Commit();
                _repCronograma.Commit();
                trans.Complete();
            }
        }

        private void AlterarOcorrencia(Solicitacao model)
        {
            var temp = new SolicitacaoOcorrencia();
            foreach (var item in model.SolicitacaoOcorrencias)
            {
                item.SolicitacaoId = model.Id;
                if (item.UsuarioId == 0)
                    throw new Exception("Informe o Usuário!");

                if (string.IsNullOrWhiteSpace(item.Descricao))
                    throw new Exception("Informe uma descrição!");

                if (item.Id <= 0)
                {
                    _repOcorrencia.Salvar(item);
                }
                else
                {
                    temp = _repOcorrencia.ObterPorId(item.Id);
                    if (temp != null)
                    {
                        temp = item;
                        _repOcorrencia.Salvar(temp);
                    }
                }
            }
            _repOcorrencia.Commit();
        }

        private void AlterarCronograma(Solicitacao model)
        {
            var temp = new SolicitacaoCronograma();
            foreach (var item in model.SolicitacaoCronogramas)
            {
                item.SolicitacaoId = model.Id;
                if (item.UsuarioId == 0)
                    throw new Exception("Informe o Usuário!");

                if (item.Data == null)
                    throw new Exception("Informe uma Data!");

                if (item.Id <= 0)
                {
                    _repCronograma.Salvar(item);
                }
                else
                {
                    temp = _repCronograma.ObterPorId(item.Id);
                    if (temp != null)
                    {
                        temp = item;
                        _repCronograma.Salvar(temp);
                    }
                }
            }
            _repOcorrencia.Commit();
        }

        private void ExcluirCronograma(Solicitacao model)
        {
            string idDelecao = "";
            int i = 1;
            var banco = _rep.ObterPorId(model.Id);
            foreach (var itemBanco in banco.SolicitacaoCronogramas)
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
                _repCronograma.ExcluirOcorrenciaIds(idDelecao);
        }

        private void ExcluirOcorrencias(Solicitacao model)
        {
            string idDelecao = "";
            int i = 1;
            var banco = _rep.ObterPorId(model.Id);
            foreach (var itemBanco in banco.SolicitacaoOcorrencias)
            {
                var dados = model.SolicitacaoOcorrencias.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _repOcorrencia.ExcluirOcorrenciaIds(idDelecao);
        }

        public string RetornarCaminhoAnexo()
        {
            return _parametro.ObterPorParametro(48, 0).Valor;
        }

        private int StatusEncerramento()
        {
            var modelParametro = _parametro.ObterPorParametro(46, 3);
            var StatusServico = new StatusServico();
            var model = StatusServico.ObterPorCodigo(Convert.ToInt32(modelParametro.Valor));
            return model.Id;
        }

        private Status StatusAbertura()
        {
            var modelParametro = _parametro.ObterPorParametro(18, 3);
            var StatusServico = new StatusServico();
            return  StatusServico.ObterPorCodigo(Convert.ToInt32(modelParametro.Valor));
        }

        private Status StatusOcorrencia()
        {
            var modelParametro = _parametro.ObterPorParametro(19, 3);
            var StatusServico = new StatusServico();
            return StatusServico.ObterPorCodigo(Convert.ToInt32(modelParametro.Valor));
        }

        private void ValidarCronograma(Solicitacao solicitacao, SolicitacaoCronograma model)
        {
            if (model.UsuarioId == 0)
                throw new Exception("Informe o Usuário!");

            if (model.HoraInicio != null && model.HoraFim != null)
            {
                if (model.HoraInicio > model.HoraFim)
                    throw new Exception("Hora Inicial maior que Hora Final.");
            }
        }

        public void AdicionarCronograma(Solicitacao solicitacao, SolicitacaoCronograma model)
        {
            ValidarCronograma(solicitacao, model);

            _rep.AdicionarCronograma(model);
        }

        public void AlterarCronograma(Solicitacao model, SolicitacaoCronograma solicitacaoCronograma)
        {
            ValidarCronograma(model, solicitacaoCronograma);

            _rep.AlterarCronograma(model, solicitacaoCronograma);
        }

        public void ExcluirCronograma(int id)
        {
            if (id > 0)
                _rep.ExcluirCronograma(id);
        }

        private void ValidarOcorrencia(Solicitacao solicitacao, SolicitacaoOcorrencia model)
        {
            if(model.Data < solicitacao.Data)
                throw new Exception("Data de Previsão de Início menor que Data de Abertura!");

            if (!string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");

            if (!string.IsNullOrWhiteSpace(model.Anexo))
            {
                if (!System.IO.File.Exists(model.Anexo))
                    throw new Exception("Arquivo do Anexo Ocorrência Geral não Existe.!");
            }
        }

        public SolicitacaoOcorrencia NovaOcorrencia(SolicitacaoOcorrencia solicitacaoOcorrencia, Usuario usuario)
        {            
            solicitacaoOcorrencia.Usuario = usuario;
            return solicitacaoOcorrencia;
        }

        public void AdicionarOcorrencia(Solicitacao solicitacao, SolicitacaoOcorrencia model, int classificacao = 2)
        {
            ValidarOcorrencia(solicitacao, model);

            model.Classificacao = classificacao; //1-geral 2-tecnica
            _rep.AdicionarOcorrencia(model);
        }

        public void AlterarOcorrencia(Solicitacao model, SolicitacaoOcorrencia solicitacaoOcorrencia)
        {
            ValidarOcorrencia(model, solicitacaoOcorrencia);

            _rep.AlterarOcorrencia(model, solicitacaoOcorrencia);
        }

        public void ExcluirOcorrencia(int id)
        {
            if (id > 0)
                _rep.ExcluirOcorrencia(id);
        }

        public bool PermissaoAbertura(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitaAbertura);
        }

        public bool MostrarAnexos(Usuario usuario)
        {
            if (usuario.Adm)
                return true;
            return (usuario.Departamento.MostrarAnexos);
        }

        public bool PermissaoAnalise(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitaAnalise);
        }

        public bool PermissaoOcorrenciaGeral(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoOcorrenciaGeral);
        }

        public bool PermissaoOcorrenciaTecnica(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoOcorrenciaTecnica);
        }

        public bool PermissaoOcorrenciaRegra(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoOcorrenciaRegra);
        }

        public bool PermissaoStatus(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoStatus);
        }

        public bool PermissaoSolicitacaoTempo(Usuario usuario)
        {
            if (usuario.Adm)
                return true;
            return _usuarioPermissao.PermissaoSolicitacaoTempo(usuario.Id);
        }

        public bool PermissaoConferenciaTempoGeral(Usuario usuario)
        {
            if (usuario.Adm)
                return true;
            return _usuarioPermissao.PermissaoConferenciaTempoGeral(usuario.Id);
        }

        public bool PermissaoQuadro(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoQuadro);
        }

        public string RetornarEmail(Solicitacao solicitacao, int idUsuario)
        {
            var usuarioModel = _repUsuario.ObterPorId(idUsuario);
            string emailUsuario = _repUsuario.EmailDoUsuario(usuarioModel);

            if (string.IsNullOrWhiteSpace(emailUsuario))
                return "";

            RetornarEmailSupervior(solicitacao, idUsuario, usuarioModel);
            RetornarEmailConsultor(solicitacao, idUsuario, usuarioModel);
            RetornarEmailRevenda(solicitacao, idUsuario, usuarioModel);

            string email = OrganizarEmail();
            return email;
        }

        public string RetornarEmailsCliente(int idUsuario, Solicitacao model)
        {
            var usuarioModel = _repUsuario.ObterPorId(idUsuario);
            string emailUsuario = _repUsuario.EmailDoUsuario(usuarioModel);

            if (string.IsNullOrWhiteSpace(emailUsuario))
                return "";

            if (model.Status != null || model.Status.NotificarCliente == false)
                return "";

            var clienteServico = new ClienteServico();

            if (model.Status.NotificarCliente == false)
                return "";

            string emailCliente = clienteServico.EmailsDoCliente(model.Cliente);

            if (string.IsNullOrWhiteSpace(emailCliente))
                emailCliente = emailUsuario;

            return emailCliente;
        }

        private string RetornarParametro(int codigo, int programa)
        {
            ParametroServico parametroServico = new ParametroServico();
            var model = parametroServico.ObterPorParametro(codigo, programa);
            return model.Valor;
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

            var departamentoServico = new DepartamentoServico();

            email = departamentoServico.RetornarEmail(usuario.Departamento);

            AdicionarEmail(email);
        }

        private void RetornarEmailConsultor(Solicitacao model, int idUsuario, Usuario usuario)
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

        private void AdicionarEmail(string email)
        {
            if (!_listaEmail.Contains(email))
                _listaEmail.Add(email);
        }

        private void RetornarEmailRevenda(Solicitacao model, int idUsuario, Usuario usuario)
        {
            if (model.Status != null || model.Status.NotificarRevenda == false)
                return;

            if (model.Cliente == null)
                return;

            if (model.Cliente.Revenda == null)
                return;

            if (model.Cliente.Revenda.RevendaEmails == null)
                return;

            var revendaServico = new RevendaServico();
            string email = revendaServico.RetornarEmails(model.Cliente.Revenda);
            AdicionarEmail(email);
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

        public void UpdateHoraUsuarioAtual(int idSolicitacao, int idUsuario)
        {
            var model = ObterPorId(idSolicitacao);
            model.UsuarioAtendeAtualId = idUsuario;

        }

        public void UpdateStatus(int idSolicitacao, int idUsuario, int idStatus)
        {
            var model = ObterPorId(idSolicitacao);
            model.StatusId = idStatus;
            model.UsuarioAtendeAtualId = idUsuario;
        }

        public bool OcorrenciaUsuarioIgualCadastro(SolicitacaoOcorrencia model, int idUsuario, int tipoOperacao)
        {
            if (tipoOperacao == 2 || tipoOperacao == 3)
                return (model.UsuarioId == idUsuario);
            else
                return true;
        }

        public bool SolicitacaoUsuarioIgualCadastro(Solicitacao model, int idUsuario, int tipoOperacao)
        {
            if (tipoOperacao == 2 || tipoOperacao == 3)
                return (model.UsuarioAberturaId == idUsuario);
            else
                return true;
        }

        public IEnumerable<QuadroSolicitacaoViewModel> Quadro(int idUsuario)
        {
            return _solicitacaoRepositorioDapper.Quadro(idUsuario, new Usuario(), 0);
        }
    }
}
