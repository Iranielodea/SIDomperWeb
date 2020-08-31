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
    public class ChamadoServico
    {
        private readonly ChamadoEF _rep;
        private readonly UsuarioServico _repUsuario;
        private readonly ChamadoOcorrenciaEF _repChamadoOcorrencia;
        private readonly AgendamentoServico _agendamentoServico;
        private readonly UsuarioPermissaoServico _usuarioPermissaoServico;
        private readonly ChamadoOcorrenciaColaboradorEF _repChamadoOcorrenciaColaboradorEF;
        private readonly EnProgramas _tipoPrograma;
        private readonly EnumChamado _tipoChamadoAtividade;
        List<string> _listaEmail;
        List<string> _listaEmailCliente;
        private readonly ChamadoRepositorioDapper _chamadoRepositorioDapper;


        public ChamadoServico(EnumChamado enChamadoAtividade = EnumChamado.Chamado)
        {
            _chamadoRepositorioDapper = new ChamadoRepositorioDapper();
            _rep = new ChamadoEF();
            _repUsuario = new UsuarioServico();
            _agendamentoServico = new AgendamentoServico();
            _usuarioPermissaoServico = new UsuarioPermissaoServico();
            _repChamadoOcorrencia = new ChamadoOcorrenciaEF();
            _repChamadoOcorrenciaColaboradorEF = new ChamadoOcorrenciaColaboradorEF();

            _listaEmail = new List<string>();
            _listaEmailCliente = new List<string>();

            if (enChamadoAtividade == EnumChamado.Chamado)
            {
                _tipoChamadoAtividade = EnumChamado.Chamado;
                _tipoPrograma = EnProgramas.Chamado;
            }
            else
            {
                _tipoChamadoAtividade = EnumChamado.Atividade;
                _tipoPrograma = EnProgramas.Atividade;
            }
        }

        public Chamado ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<ChamadoConsultaViewModel> Filtrar(ChamadoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem, EnumChamado tipo)
        {
            return _chamadoRepositorioDapper.Filtrar(filtro, campo, texto, usuarioId, contem, tipo);
            //return _repADO.Filtrar(filtro, campo, texto, usuarioId, contem, tipo);
        }

        public IEnumerable<ChamadoConsultaViewModel> FiltrarPorId(int id, int idUsuario)
        {
            var filtro = new ChamadoFiltroViewModel
            {
                Id = id
            };
            return _chamadoRepositorioDapper.Filtrar(filtro, "Cha_Id", "", idUsuario, false, EnumChamado.Chamado);

            //return _repADO.Filtrar(filtro, "Cha_Id", "", idUsuario, false, EnumChamado.Chamado);
        }

        public Chamado Novo(int idUsuario, bool quadro, int idClienteAgendamento, int idAgendamento)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new Chamado();
            var tipoServico = new TipoServico();

            var modelTipo = tipoServico.RetornarUmRegistro(_tipoChamadoAtividade);
            if (modelTipo != null)
                model.Tipo = modelTipo;

            var usuario = _repUsuario.ObterPorId(idUsuario);
            if (usuario != null)
            {
                model.UsuarioAbertura = usuario;
                if (usuario.ClienteId != null && usuario.ClienteId > 0)
                    model.Cliente = usuario.Clientes.FirstOrDefault(x => x.Id == usuario.ClienteId.Value);
            }

            var observacaoServico = new ObservacaoServico();
            var obsModel = observacaoServico.ObterPadrao((int)EnumChamado.Chamado);
            if (obsModel != null)
                model.Descricao = obsModel.Descricao;

            if (quadro && idClienteAgendamento > 0)
                model.Cliente = new ClienteServico().ObterPorId(idClienteAgendamento);

            if (idAgendamento > 0)
                BuscarAgendamento(idAgendamento, model);

            model.DataAbertura = DateTime.Now.Date;

            return model;
        }

        private void BuscarAgendamento(int idAgendamento, Chamado model)
        {
            var Agendamento = _agendamentoServico.ObterPorId(idAgendamento);
            model.DataAbertura = Agendamento.Data;
            model.Descricao = Agendamento.Descricao;
        }

        public Chamado Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao;
            var model = new Chamado();
            model = _rep.ObterPorId(id);

            var Usuario = _repUsuario.ObterPorId(idUsuario);
            if (Usuario.Adm)
            {
                permissao = true;
                permissaoMensagem = "OK";
            }
            else
            {
                permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
                if (permissao)
                    permissao = (model.UsuarioAberturaId == idUsuario);

                permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            }
            return model;
        }

        public void Salvar(Chamado model)
        {
            try
            {
                ValidarSalvar(model);
                _rep.Salvar(model);
                _rep.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SalvarAplicativo(ChamadoAplicativoInputViewModel chamadoInputModel)
        {
            try
            {
                string codigoUsuario = UsuarioAplicativo();
                if (string.IsNullOrWhiteSpace(codigoUsuario))
                    throw new Exception("Informe o Código do Usuário do Aplicativo (parâmetro 54)");

                var usuario = _repUsuario.ObterPorCodigo(int.Parse(codigoUsuario));

                int idUsuario = usuario.Id;

                var clienteServico = new ClienteServico();
                var tipoServico = new TipoServico();

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

                var cliente = clienteServico.ObterPorCNPJ(chamadoInputModel.CNPJ);
                if (cliente != null)
                    chamado.ClienteId = cliente.Id;

                var modelTipo = tipoServico.RetornarUmRegistro(_tipoChamadoAtividade);
                if (modelTipo != null)
                    chamado.TipoId = modelTipo.Id;

                var codStatusAbertura = StatusAbertura();

                if (string.IsNullOrWhiteSpace(codStatusAbertura))
                    throw new Exception("Informe o código do Status de Abertura. (Parâmetro 9,1)");

                var statusServico = new StatusServico();

                var status = statusServico.ObterPorCodigo(int.Parse(codStatusAbertura));
                if (status != null)
                    chamado.StatusId = status.Id;

                Salvar(chamado);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ChamadoAplicativoViewModel> RetornarDadosAplicativo(string cnpj)
        {
            return _chamadoRepositorioDapper.RetornarDadosAplicativo(cnpj);
        }

        private void ValidarSalvar(Chamado model)
        {
            string resultado = "";
            if (model.DataAbertura == null)
                resultado = "Informe a Data da Abertura do Chamado! \n";
            if (model.HoraAbertura == null)
                resultado = resultado + "Informe a Hora da Abertura do Chamado! \n";
            if (model.ClienteId == 0)
                resultado = resultado + " Informe o Cliente do Chamado! \n";
            if (model.UsuarioAberturaId == 0)
                resultado = resultado + " Informe o Usuário de Abertura do Chamado! \n";
            if (model.TipoId == 0)
                resultado = resultado + " Informe o Tipo do Chamado! \n";
            if (model.StatusId == 0)
                resultado = resultado + " Informe o Status do Chamado! \n";
            if (string.IsNullOrWhiteSpace(model.Descricao))
                resultado = resultado + " Informe a Descrição do Chamado! \n";

            if (resultado.Length > 0)
                throw new Exception(resultado);
        }

        public void Salvar(Chamado model, int idUsuario, bool ocorrencia)
        {
            try
            {
                int id = model.Id;

                ValidarSalvar(model);

                using (var trans = new TransactionScope())
                {
                    if (model.Id == 0)
                    {
                        model.UsuarioAtendeAtualId = idUsuario;
                        model.HoraAtendeAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                        _rep.Salvar(model);
                    }
                    else
                    {
                        //var chamado = ObterPorId(model.Id);
                        //if (chamado == null)
                        //    chamado = new Chamado();

                        //if (model.ChamadoOcorrencias.Count() > 0)
                        //{
                        
                        AlterarOcorrencia(model);
                        ExcluirOcorrencias(model);
                        //}

                        //chamado.ClienteId = model.ClienteId;
                        //chamado.Contato = model.Contato;
                        //chamado.DataAbertura = model.DataAbertura;
                        //chamado.Descricao = model.Descricao;
                        //chamado.HoraAbertura = model.HoraAbertura;
                        //chamado.HoraAtendeAtual = model.HoraAtendeAtual;
                        //chamado.ModuloId = model.ModuloId;
                        //chamado.Nivel = model.Nivel;
                        //chamado.ProdutoId = model.ProdutoId;
                        //chamado.StatusId = model.StatusId;
                        //chamado.TipoId = model.TipoId;
                        //chamado.TipoMovimento = model.TipoMovimento;
                        //chamado.UsuarioAberturaId = model.UsuarioAberturaId;
                        //chamado.UsuarioAtendeAtualId = model.UsuarioAtendeAtualId;

                        //_rep.Salvar(chamado);
                        _rep.Salvar(model);
                    }

                    // O Status do Chamado é salvo via trigger na tabela Chamado

                    _rep.Commit();
                    trans.Complete();
                }

                if (id <= 0) // inclusao
                {
                    if (ocorrencia == false)
                    {
                        var usuario = _repUsuario.ObterPorId(idUsuario);

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

        private void AlterarOcorrencia(Chamado model)
        {
            var temp = new ChamadoOcorrencia();
            foreach (var item in model.ChamadoOcorrencias)
            {
                item.HoraFim = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                if (item.UsuarioId == 0)
                    throw new Exception("Informe o Usuário!");

                //if (item.Data < model.DataAbertura)
                //    throw new Exception("Data de Ocorrência menor que Data de Abertura!");
                //if (item.HoraInicio > item.HoraFim)
                //    throw new Exception("Hora Inicial maior que Hora Final na Ocorrência!");

                if (item.UsuarioId == 0)
                    throw new Exception("Informe o Usuário!");
                //if (string.IsNullOrWhiteSpace(item.DescricaoTecnica) && string.IsNullOrWhiteSpace(item.DescricaoSolucao))
                //    throw new Exception("Informe uma descrição!");

                double HoraInicio = Funcoes.Horas.HoraToDecimal(item.HoraInicio.ToString());
                double HoraFim = Funcoes.Horas.HoraToDecimal(item.HoraFim.ToString());

                item.TotalHoras = HoraFim - HoraInicio;

                if (item.Id <= 0)
                {
                    _repChamadoOcorrencia.Salvar(item);
                    //chamado.ChamadoOcorrencias.Add(item);
                }
                else
                {
                    //ExcluirOcorrenciasColaborador(item);

                    temp = _repChamadoOcorrencia.ObterPorId(item.Id);
                    //var temp = chamado.ChamadoOcorrencias.FirstOrDefault(x => x.Id == item.Id);
                    //temp = model.ChamadoOcorrencias.FirstOrDefault(x => x.Id == item.Id);
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

                        _repChamadoOcorrencia.Salvar(temp);
                        //_repChamadoOcorrencia.Commit();
                        AlterarOcorrenciaColaborador(temp);
                        ExcluirOcorrenciasColaborador(temp);

                        //foreach (var colab in temp.ChamadoOcorrenciaColaboradores)
                        //{
                        //    _repChamadoOcorrenciaColaboradorEF.Salvar(colab);
                        //}

                        //_repChamadoOcorrenciaColaboradorEF.Commit();

                        //AlterarOcorrenciaColaborador(temp);
                    }
                }
            }
            _repChamadoOcorrencia.Commit();
            _repChamadoOcorrenciaColaboradorEF.Commit();

            //if (model.ChamadoOcorrencias.Count() > 0)
            //    _repChamadoOcorrencia.Commit();
        }

        private void ExcluirOcorrencias(Chamado model)
        {
            string idDelecao = "";
            int i = 1;
            var banco = _rep.ObterPorId(model.Id);
            foreach (var itemBanco in banco.ChamadoOcorrencias)
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
                _rep.ExcluirOcorrenciaIds(idDelecao);
        }

        private void AlterarOcorrenciaColaborador(ChamadoOcorrencia chamadoOcorrencia)
        {
            var temp = new ChamadoOcorrenciaColaborador();
            foreach (var item in chamadoOcorrencia.ChamadoOcorrenciaColaboradores)
            {
                double HoraInicio = 0;
                double HoraFim = 0;

                if (item.HoraInicio != null)
                    HoraInicio = Funcoes.Horas.HoraToDecimal(item.HoraInicio.ToString());

                if (item.HoraFim != null)
                    HoraFim = Funcoes.Horas.HoraToDecimal(item.HoraFim.ToString());

                if (item.HoraInicio != null && item.HoraFim != null)
                    item.TotalHoras = HoraFim - HoraInicio;

                if (item.Id == 0)
                {
                    if (item.UsuarioId == 0)
                        throw new Exception("Informe o Usuário!");
                    _repChamadoOcorrenciaColaboradorEF.Salvar(item);
                }
                else
                {
                    temp = chamadoOcorrencia.ChamadoOcorrenciaColaboradores.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp = item;
                        if (temp.UsuarioId == 0)
                            throw new Exception("Informe o Usuário!");

                        _repChamadoOcorrenciaColaboradorEF.Salvar(temp);
                        //temp.UsuarioId = item.UsuarioId;
                        //temp.HoraFim = item.HoraFim;
                        //temp.HoraInicio = item.HoraInicio;
                        //temp.TotalHoras = item.TotalHoras;
                        //temp.UsuarioId = item.UsuarioId;
                    }
                }
            }
            // _repChamadoOcorrenciaColaboradorEF.Commit();
        }

        private void ExcluirOcorrenciasColaborador(ChamadoOcorrencia chamadoOcorrencia)
        {
            string idDelecao = "";
            int i = 1;
            var banco = _repChamadoOcorrenciaColaboradorEF.ObterPorOcorrencia(chamadoOcorrencia.Id);
            foreach (var itemBanco in banco)
            {
                var dados = chamadoOcorrencia.ChamadoOcorrenciaColaboradores.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _rep.ExcluirOcorrenciaColaboradorIds(idDelecao);
        }

        public void Excluir(int idUsuario, Chamado model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            try
            {
                _rep.Excluir(model);
                _rep.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int idUsuario, int id)
        {
            try
            {
                _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
                var model = _rep.ObterPorId(id);
                _rep.Excluir(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UsuarioIgualCadastro(int id, int usuarioId, int tipoOperacao)
        {
            //tipoOperacao = 2 - Edicao 3 - Exclusao

            bool resultado = false;
            if (tipoOperacao == 2 || tipoOperacao == 3)
            {
                var model = ObterPorId(id);
                if (model != null)
                {
                    resultado = (model.UsuarioAberturaId == usuarioId);
                }
            }
            return resultado;
        }

        public double BuscarTotalHoras(int chamadoId)
        {
            //ChamadoOcorrenciaServico servicoOcorrencia = new ChamadoOcorrenciaServico();

            //var lista = servicoOcorrencia.ObterPorChamado(chamadoId);
            //return lista.Sum(x => x.TotalHoras);

            return _repChamadoOcorrencia.BuscarTotalHorasChamado(chamadoId);
        }

        public int RetornarStatus(int chamadoId)
        {
            var model = _rep.ObterPorId(chamadoId);
            if (model != null)
                return model.StatusId;
            else
                return 0;
        }

        public void ExcluirUmaOcorrencia(Chamado model, int idOcorrencia)
        {
            _rep.ExcluirUmaOcorrencia(model, idOcorrencia);
            _rep.Commit();
        }

        public void ExcluirOcorrenciasDoChamado(Chamado model)
        {
            _rep.ExcluirOcorrenciasDoChamado(model);
            _rep.Commit();
        }

        public ChamadoQuadroViewModel AbrirQuadro(int idUsuario, int idRevenda)
        {
            var lista = new List<QuadroViewModelChamado>();
            var quadroViewModel = new ChamadoQuadroViewModel();

            if (_tipoPrograma == EnProgramas.Chamado)
            {
                //lista = _repADO.QuadroChamado(idUsuario, idRevenda, EnumChamado.Chamado).ToList();
                lista = _chamadoRepositorioDapper.QuadroChamado(idUsuario, idRevenda, EnumChamado.Chamado).ToList();

                quadroViewModel.Quadro1 = lista.Where(x => x.QuadroTela == "Q1").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro2 = lista.Where(x => x.QuadroTela == "Q2").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro3 = lista.Where(x => x.QuadroTela == "Q3").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro4 = lista.Where(x => x.QuadroTela == "Q4").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro5 = lista.Where(x => x.QuadroTela == "Q5").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro6 = lista.Where(x => x.QuadroTela == "Q6").OrderBy(x => x.Id).ToList();

                var listaStatus = BuscarTitulosQuadro();

                quadroViewModel.Titulo1 = listaStatus[0].Nome;
                quadroViewModel.Titulo2 = listaStatus[1].Nome;
                quadroViewModel.Titulo3 = listaStatus[2].Nome;
                quadroViewModel.Titulo4 = listaStatus[3].Nome;
                quadroViewModel.Titulo5 = listaStatus[4].Nome;
                quadroViewModel.Titulo6 = listaStatus[5].Nome;

                var codStatusAbertura = StatusAbertura();
                var codStatusOcorrencia = StatusAtendimentoChamado();

                var statusServico = new StatusServico();

                var modelServico = statusServico.ObterPorCodigo(int.Parse(codStatusAbertura));
                string statusAbertura = modelServico.Nome;

                modelServico = statusServico.ObterPorCodigo(int.Parse(codStatusOcorrencia));
                string statusOcorrencia = modelServico.Nome;

                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo1, quadroViewModel.Quadro1);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo2, quadroViewModel.Quadro2);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo3, quadroViewModel.Quadro3);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo4, quadroViewModel.Quadro4);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo5, quadroViewModel.Quadro5);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo6, quadroViewModel.Quadro6);
            }
            else
                lista = _chamadoRepositorioDapper.QuadroChamado(idUsuario, idRevenda, EnumChamado.Atividade).ToList();

            return quadroViewModel;
            //return _repADO.QuadroChamado(idUsuario, idRevenda, EnumChamado.Atividade).ToList();
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
                if (tituloQuadro == nomeStatusAbertura)
                    item.Tempo = CalcularTempo(DateTime.Parse(item.DataAbertura), TimeSpan.Parse(item.HoraAbertura.ToString()));
                else if (tituloQuadro == nomeStatusOcorrencia)
                    item.Tempo = CalcularTempoParametro10(TimeSpan.Parse(item.HoraAtendeAtual.ToString()));
                else
                    item.Tempo = CalcularTempo(DateTime.Parse(item.UltimaData), TimeSpan.Parse(item.UltimaHora.ToString()));
            }
        }

        private string Titulo(int codigo, List<Status> listagemStatus)
        {
            string sNome = "";
            foreach (var item in listagemStatus)
            {
                if (codigo == item.Codigo)
                {
                    sNome = item.Nome;
                    break;
                }
            }

            return sNome;

            //var modelParametro = _parametroServico.ObterPorParametro(codigo, 1);
            //var modelStatus = _statusServico.ObterPorCodigo(Convert.ToInt32(modelParametro.Valor));

            //return modelStatus.Nome;
        }

        public string StatusAbertura()
        {
            return RetornarParametro(9, 1);
        }

        public string StatusAberturaAtividade()
        {
            return RetornarParametro(31, 111);
        }

        public string StatusAtendimentoAtividade()
        {
            return RetornarParametro(32, 111);
        }

        public string StatusAtendimentoChamado()
        {
            return RetornarParametro(10, 1);
        }

        private string UsuarioAplicativo()
        {
            return RetornarParametro(54, 0);
        }

        public void UpdateHoraUsuarioAtual(int idChamado, EnumChamado enumChamado, int idUsuario)
        {
            string codigoStatus = "";

            if (enumChamado == EnumChamado.Chamado)
                codigoStatus = StatusAtendimentoChamado();
            else
                codigoStatus = StatusAtendimentoAtividade();

            if (!string.IsNullOrWhiteSpace(codigoStatus))
            {
                var servicoStatus = new StatusServico();
                var modelStatus = servicoStatus.ObterPorCodigo(Convert.ToInt32(codigoStatus));

                if (modelStatus == null)
                    throw new Exception("Informe o Status Atendimento na Tabela de Parâmetros !");

                _rep.UpdateHoraUsuarioAtual(idChamado, enumChamado, idUsuario, modelStatus.Id);
                _rep.Commit();
            }
        }

        public string RetornarEmailsCliente(int idUsuario, Chamado model)
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

        public string RetornarEmail(Chamado chamado, int idUsuario)
        {
            var usuarioModel = _repUsuario.ObterPorId(idUsuario);
            string emailUsuario = _repUsuario.EmailDoUsuario(usuarioModel);

            if (string.IsNullOrWhiteSpace(emailUsuario))
                return "";

            RetornarEmailSupervior(chamado, idUsuario, usuarioModel);
            RetornarEmailConsultor(chamado, idUsuario, usuarioModel);
            RetornarEmailRevenda(chamado, idUsuario, usuarioModel);

            string email = OrganizarEmail();
            return email;
        }

        public string CaminhoAnexo()
        {
            return RetornarParametro(49, 0);
        }

        public List<ChamadoOcorrencia> ListarProblemaSolucao(ChamadoFiltro filtro, string texto, int idUsuario, EnumChamado tipo)
        {
            return _rep.ListarProblemaSolucao(filtro, texto, idUsuario, tipo).ToList();
        }

        public bool PermissaoAbertura(int idUsuario, Usuario usuario, EnumChamado tipo)
        {
            if (tipo == EnumChamado.Chamado)
                return usuario.Departamento.ChamadoAbertura;
            else
                return usuario.Departamento.AtividadeAbertura;
        }

        public bool PermissaoOcorrencia(int idUsuario, Usuario usuario, EnumChamado tipo)
        {
            if (tipo == EnumChamado.Chamado)
                return usuario.Departamento.ChamadoOcorrencia;
            else
                return usuario.Departamento.AtividadeOcorrencia;
        }

        public bool PermissaoStatus(int idUsuario, Usuario usuario, EnumChamado tipo)
        {
            if (tipo == EnumChamado.Chamado)
                return usuario.Departamento.ChamadoStatus;
            else
                return usuario.Departamento.AtividadeStatus;
        }

        public bool PermissaoQuadro(int idUsuario, Usuario usuario, EnumChamado tipo)
        {
            if (tipo == EnumChamado.Chamado)
                return usuario.Departamento.ChamadoQuadro;
            else
                return usuario.Departamento.AtividadeQuadro;
        }

        private List<Status> BuscarTitulosQuadro()
        {
            var parametroServico = new ParametroServico();
            var listaParametros = parametroServico.BuscarTitulosChamados().OrderBy(x => x.Codigo);

            var statusServico = new StatusServico();
            var listaStatus = statusServico.ListarTodos();
            var lista = new List<Status>();

            foreach (var item in listaParametros)
            {
                var model = listaStatus.First(x => x.Codigo == Convert.ToInt32(item.Valor));
                lista.Add(model);
            }

            return lista;
        }

        private string RetornarParametro(int codigo, int programa)
        {
            ParametroServico parametroServico = new ParametroServico();
            var model = parametroServico.ObterPorParametro(codigo, programa);
            return model.Valor;
        }

        private void RetornarEmailSupervior(Chamado model, int idUsuario, Usuario usuario)
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

        private void RetornarEmailConsultor(Chamado model, int idUsuario, Usuario usuario)
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

        private void RetornarEmailRevenda(Chamado model, int idUsuario, Usuario usuario)
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

        private void AdicionarEmail(string email)
        {
            if (!_listaEmail.Contains(email))
                _listaEmail.Add(email);
        }

        public string CalcularTempo(DateTime dataChamado, TimeSpan horaChamado)
        {
            try
            {
                if (DateTime.Now.Date == dataChamado)
                {
                    TimeSpan horaAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                    TimeSpan hora = Funcoes.Horas.CalcularHoras(horaChamado, horaAtual);
                    return Funcoes.Horas.FormatarHora(hora);
                }
                else
                {
                    double dias = Funcoes.FuncaoGeral.CalcularDatas(dataChamado, DateTime.Now.Date);
                    return dias.ToString();
                }
            }
            catch
            {
                return "00:00";
            }
        }

        public string CalcularTempoParametro10(TimeSpan horaAtendimento)
        {
            try
            {
                TimeSpan horaAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                TimeSpan tempo = Funcoes.Horas.CalcularHoras(horaAtual, horaAtendimento);
                return Funcoes.Horas.FormatarHora(tempo);
            }
            catch
            {
                return "00:00";
            }
        }

        public string RetornarCalculoTempo(Quadro quadro)
        {
            if (quadro.UltimaHora != "")
            {
                TimeSpan ultimaHora = TimeSpan.Parse(quadro.UltimaHora);
                return CalcularTempo(Convert.ToDateTime(quadro.UltimaData), ultimaHora);
            }
            else
            {
                TimeSpan horaAbertura = TimeSpan.Parse(quadro.HoraAbertura);
                return CalcularTempo(Convert.ToDateTime(quadro.DataAbertura), horaAbertura);
            }
        }

        private string RetornarEmailConta(int usuarioId)
        {
            var usuario = new UsuarioServico().ObterPorId(usuarioId);

            string sRetorno = "";
            if (usuario.ContaEmail != null)
                sRetorno = usuario.ContaEmail.Email;

            return sRetorno;
        }

        private bool TemContaEmail(int usuarioId)
        {
            string resultado = RetornarEmailConta(usuarioId);

            if (string.IsNullOrEmpty(resultado))
                return false;
            else
                return true;
        }

        private string BuscarEmail(Chamado model, int usuarioId, Usuario usuario)
        {
            if (TemContaEmail(usuarioId))
            {
                RetornarEmailSupervior(model, usuarioId, usuario);
                RetornarEmailConsultor(model, usuarioId, usuario);
                RetornarEmailRevenda(model, usuarioId, usuario);
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

        public void EnviarEmail(Chamado model, int usuarioId, Usuario usuario, EnumChamado enChamado)
        {
            string emailOculto = BuscarEmail(model, usuarioId, usuario);
            string emailCliente = RetornarEmailCliente(usuarioId, model);

            if (string.IsNullOrEmpty(emailCliente))
                emailCliente = emailOculto;

            if (!string.IsNullOrEmpty(emailCliente))
            {
                string texto = TextoEmail(model, enChamado);
                string assunto = RetornarAssunto(model, enChamado);

                ContaEmailServico conta = new ContaEmailServico();
                conta.EnviarEmail(usuarioId, emailCliente, emailOculto, assunto, texto, "");
            }
        }

        private string RetornarAssunto(Chamado chamado, EnumChamado enChamado)
        {
            string titulo = "Chamado: ";
            if (enChamado == EnumChamado.Atividade)
                titulo = "Atividade: ";

            return titulo + chamado.Id.ToString("000000") + " DOMPER Consultoria e Sistemas Ltda.";
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

        public string RetornarEmailCliente(int usuarioId, Chamado chamado)
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

        public List<ChamadoAnexo> RetornarAnexos(int chamadoId)
        {
            return _rep.RetornarAnexos(chamadoId);
        }
    }
}
