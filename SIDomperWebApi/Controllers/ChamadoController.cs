using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Funcoes;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/chamado")]
    public class ChamadoController : ApiController
    {
        private ChamadoServico _chamadoServico;
        private UsuarioServico _usuarioServico;
        private UsuarioPermissaoServico _usuarioPermissaoServico;
        private ChamadoViewModel _ChamadoViewModel;
        private StatusServico _statusServico;

        public ChamadoController()
        {
            _usuarioServico = new UsuarioServico();
            _usuarioPermissaoServico = new UsuarioPermissaoServico();
            _statusServico = new StatusServico();
            _ChamadoViewModel = new ChamadoViewModel();
        }

        [Route("Novo")]
        [HttpGet]
        public ChamadoViewModel Novo(int idUsuario, EnumChamado enChamadoAtividade,
            int idEncerramento, bool quadro, int idClienteAgenciamento, int idAgendamento)
        {
            try
            {
                _chamadoServico = new ChamadoServico(enChamadoAtividade);

                var model = _chamadoServico.Novo(idUsuario, quadro, idClienteAgenciamento, idAgendamento);
                if (model != null)
                {
                    //if (model.UsuarioAbertura != null)
                    //    DadosUsuario(_ChamadoViewModel, model);

                    //if (model.Cliente != null)
                    //    DadosCliente(_ChamadoViewModel, model);

                    //if (model.Tipo != null)
                    //    DadosTipo(_ChamadoViewModel, model);

                    PopularDados(_ChamadoViewModel, model, idUsuario);

                    //if (enChamadoAtividade == EnumChamado.Chamado)
                    //{
                    //    if (_ChamadoViewModel.UsuarioPermissaoAlterarDataHora == false)
                    //        _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _usuarioPermissaoServico.PermissaoAlterarDataHoraChamado(idUsuario);

                    //    _ChamadoViewModel.PermissaoAlterarOcorrenciaChamado = _usuarioPermissaoServico.PermissaoOcorrenciaChamadoAlterar(idUsuario);
                    //    _ChamadoViewModel.PermissaoExcluirOcorrenciaChamado = _usuarioPermissaoServico.PermissaoOcorrenciaChamadoExcluir(idUsuario);
                    //}
                    //else
                    //{
                    //    if (_ChamadoViewModel.UsuarioPermissaoAlterarDataHora == false)
                    //        _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _usuarioPermissaoServico.PermissaoAlterarDataHoraAtividade(idUsuario);

                    //    _ChamadoViewModel.PermissaoAlterarOcorrenciaAtividade = _usuarioPermissaoServico.PermissaoOcorrenciaAlterarAtividade(idUsuario);
                    //    _ChamadoViewModel.PermissaoExcluirOcorrenciaAtividade = _usuarioPermissaoServico.PermissaoOcorrenciaAtividadeExcluir(idUsuario);
                    //}

                    //_ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _ChamadoViewModel.UsuarioPermissaoAlterarDataHora;

                    //_ChamadoViewModel.Descricao = model.Descricao;

                    //var usuario = _usuarioServico.ObterPorId(idUsuario);
                    //if (usuario != null)
                    //    _ChamadoViewModel.UsuarioAdm = usuario.Adm;

                    NovoChamadoQuadro(_ChamadoViewModel, enChamadoAtividade, idEncerramento, _chamadoServico);
                }
                return _ChamadoViewModel;
            }
            catch (Exception ex)
            {
                _ChamadoViewModel.Mensagem = ex.Message;
                return _ChamadoViewModel;
            }
        }

        [Route("RetornoDadosAplicativo")]
        [HttpGet]
        public ChamadoAplicativoViewModel[] RetornarDadosAplicativo(string cnpj)
        {
            var lista = new List<ChamadoAplicativoViewModel>();
            _chamadoServico = new ChamadoServico();
            try
            {
                return _chamadoServico.RetornarDadosAplicativo(cnpj).ToArray();
            }
            catch(Exception ex)
            {
                lista.Add(new ChamadoAplicativoViewModel{Id = 0, Mensagem = ex.Message, Data=DateTime.Now, Status="" });
                return lista.ToArray();
            }
        }

        [Route("IncluirAplicativo")]
        [HttpPost]
        public ChamadoAplicativoResultadoOutPutViewModel IncluirAplicativo([FromBody] chamadoAplicativoInputViewModel inputModel)
        {
            var resposta = new ChamadoAplicativoResultadoOutPutViewModel();
            try
            {
                _chamadoServico = new ChamadoServico();

                _chamadoServico.SalvarAplicativo(inputModel);
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Resultado = ex.Message;
                return resposta;
            }
        }

        private void DadosModulo(ChamadoViewModel _ChamadoViewModel, Chamado model)
        {
            if (model.Modulo != null)
            {
                _ChamadoViewModel.ModuloId = model.ModuloId;
                _ChamadoViewModel.CodModulo = model.Modulo.Codigo;
                _ChamadoViewModel.NomeModulo = model.Modulo.Nome;
            }
        }

        private void DadosProduto(ChamadoViewModel _ChamadoViewModel, Chamado model)
        {
            if (model.Produto != null)
            {
                _ChamadoViewModel.ProdutoId = model.ProdutoId;
                _ChamadoViewModel.CodProduto = model.Produto.Codigo;
                _ChamadoViewModel.NomeProduto = model.Produto.Nome;
            }
        }

        private void DadosTipo(ChamadoViewModel _ChamadoViewModel, Chamado model)
        {
            _ChamadoViewModel.TipoId = model.TipoId;
            _ChamadoViewModel.CodTipo = model.Tipo.Codigo;
            _ChamadoViewModel.NomeTipo = model.Tipo.Nome;
        }

        private void DadosStatus(ChamadoViewModel _ChamadoViewModel, Chamado model)
        {
            _ChamadoViewModel.StatusId = model.StatusId;
            _ChamadoViewModel.CodStatus = model.Status.Codigo;
            _ChamadoViewModel.NomeStatus = model.Status.Nome;
        }

        private void DadosCliente(ChamadoViewModel _ChamadoViewModel, Chamado model)
        {
            _ChamadoViewModel.ClienteId = model.ClienteId;
            _ChamadoViewModel.CodCliente = model.Cliente.Codigo;
            _ChamadoViewModel.NomeCliente = model.Cliente.Nome;
            _ChamadoViewModel.NomeFantasia = model.Cliente.Fantasia;
            _ChamadoViewModel.Versao = model.Cliente.Versao;

            if (model.Cliente.Revenda != null)
                _ChamadoViewModel.NomeRevenda = model.Cliente.Revenda.Nome;

            if (model.Cliente.Usuario != null)
                _ChamadoViewModel.NomeConsultor = model.Cliente.Usuario.Nome;

            _ChamadoViewModel.Fone1 = model.Cliente.Fone1;
            _ChamadoViewModel.Fone2 = model.Cliente.Fone2;
            _ChamadoViewModel.Celular = model.Cliente.Celular;
            _ChamadoViewModel.OutroFone = model.Cliente.OutroFone;
            _ChamadoViewModel.ContatoFinanceiro = model.Cliente.ContatoFinanceiro;
            _ChamadoViewModel.ContatoCompraVenda = model.Cliente.ContatoCompraVenda;
        }

        private void DadosUsuario(ChamadoViewModel _ChamadoViewModel, Chamado model)
        {
            _ChamadoViewModel.UsuarioAberturaId = model.UsuarioAbertura.Id;
            _ChamadoViewModel.CodUsuario = model.UsuarioAbertura.Codigo;
            _ChamadoViewModel.NomeUsuario = model.UsuarioAbertura.Nome;
            _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = model.UsuarioAbertura.Adm;
        }

        //private void DadosOcorrencia(ChamadoViewModel chamado, Chamado model)
        //{
        //    foreach (var item in model.ChamadoOcorrencias)
        //    {
        //        chamado.
        //    }
        //    _ChamadoViewModel.UsuarioAberturaId = model.UsuarioAbertura.Id;
        //    _ChamadoViewModel.CodUsuario = model.UsuarioAbertura.Codigo;
        //    _ChamadoViewModel.NomeUsuario = model.UsuarioAbertura.Nome;
        //    _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = model.UsuarioAbertura.Adm;
        //}

        private void NovoChamadoQuadro(ChamadoViewModel model, EnumChamado enChamadoAtividade, int idEncerramento, ChamadoServico chamadoServico)
        {
            _chamadoServico = new ChamadoServico(enChamadoAtividade);
            string codStatus = "0";
            if (enChamadoAtividade == EnumChamado.Chamado)
                codStatus = _chamadoServico.StatusAbertura();

            if (idEncerramento > 0 || enChamadoAtividade == EnumChamado.Atividade)
                codStatus = _chamadoServico.StatusAberturaAtividade();

            int CodStatus;
            int.TryParse(codStatus, out CodStatus);

            if (CodStatus == 0)
                throw new Exception("Informe o Status para abertura nos Parâmetros do Sistema!");
            else
            {
                var Status = _statusServico.ObterPorCodigo(CodStatus);
                if (Status != null)
                {
                    model.StatusId = Status.Id;
                    model.CodStatus = Status.Codigo;
                    model.NomeStatus = Status.Nome;
                }
            }
        }

        private void PopularDados(ChamadoViewModel chamadoViewModel, Chamado chamado, int idUsuario)
        {
            if (chamado.UsuarioAbertura != null)
                DadosUsuario(_ChamadoViewModel, chamado);

            if (chamado.Cliente != null)
                DadosCliente(_ChamadoViewModel, chamado);

            if (chamado.Tipo != null)
                DadosTipo(_ChamadoViewModel, chamado);

            if (chamado.Modulo != null)
                DadosModulo(_ChamadoViewModel, chamado);

            if (chamado.Produto != null)
                DadosProduto(_ChamadoViewModel, chamado);

            if (chamado.Status != null)
                DadosStatus(_ChamadoViewModel, chamado);

            if (_ChamadoViewModel.TipoMovimento == (int)EnumChamado.Chamado)
            {
                if (_ChamadoViewModel.UsuarioPermissaoAlterarDataHora == false)
                    _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _usuarioPermissaoServico.PermissaoAlterarDataHoraChamado(idUsuario);

                _ChamadoViewModel.PermissaoAlterarOcorrenciaChamado = _usuarioPermissaoServico.PermissaoOcorrenciaChamadoAlterar(idUsuario);
                _ChamadoViewModel.PermissaoExcluirOcorrenciaChamado = _usuarioPermissaoServico.PermissaoOcorrenciaChamadoExcluir(idUsuario);
            }
            else
            {
                if (_ChamadoViewModel.UsuarioPermissaoAlterarDataHora == false)
                    _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _usuarioPermissaoServico.PermissaoAlterarDataHoraAtividade(idUsuario);

                _ChamadoViewModel.PermissaoAlterarOcorrenciaAtividade = _usuarioPermissaoServico.PermissaoOcorrenciaAlterarAtividade(idUsuario);
                _ChamadoViewModel.PermissaoExcluirOcorrenciaAtividade = _usuarioPermissaoServico.PermissaoOcorrenciaAtividadeExcluir(idUsuario);
            }

            _ChamadoViewModel.Descricao = chamado.Descricao;

            var usuario = _usuarioServico.ObterPorId(idUsuario);
            if (usuario != null)
                _ChamadoViewModel.UsuarioAdm = usuario.Adm;

            _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _ChamadoViewModel.UsuarioPermissaoAlterarDataHora;

            var usuarioOcorrencia = new Usuario();
            foreach (var chamadoOcorrencia in _ChamadoViewModel.ChamadoOcorrencias)
            {
                usuarioOcorrencia = _usuarioServico.ObterPorId(chamadoOcorrencia.UsuarioId);
                chamadoOcorrencia.CodUsuario = usuarioOcorrencia.Codigo;
                chamadoOcorrencia.NomeUsuario = usuarioOcorrencia.Nome;

                foreach (var colaborador in chamadoOcorrencia.ChamadoOcorrenciaColaboradores)
                {
                    usuario = _usuarioServico.ObterPorId(colaborador.UsuarioId);
                    colaborador.CodUsuario = usuario.Codigo;
                    colaborador.NomeUsuario = usuario.Nome;
                }
            }

            foreach(var item in _ChamadoViewModel.ChamadosStatus)
            {
                item.HoraTela = Utils.FormatarHHMMSS(item.Hora);
            }
            

            //var chamadoOcorrenciaServico = new ChamadoOcorrenciaServico();

            //var chamadoOcorrencia = chamadoOcorrenciaServico.ObterPorChamado(chamado.Id);

            //foreach (var model in chamadoOcorrencia)
            //{
            //    var viewModel = new ChamadoOcorrenciaViewModel();
            //    Utils.AutoMappear(model, viewModel);

            //    viewModel.CodUsuario = model.Usuario.Codigo;
            //    viewModel.NomeUsuario = model.Usuario.Nome;

            //    _ChamadoViewModel.ChamadoOcorrencias.Add(viewModel);
            //}
        }

        [Route("ObterPorId")]
        [HttpGet]
        public ChamadoViewModel ObterPorId(int id)
        {
            _chamadoServico = new ChamadoServico();
            try
            {
                string mensagem = "";
                var item = _chamadoServico.ObterPorId(id);
                //_ChamadoViewModel = item.Adapt<ChamadoViewModel>();
                Utils.AutoMappear(item, _ChamadoViewModel);

                PopularDados(_ChamadoViewModel, item, 0);

                //var usuario = new Usuario();
                //foreach (var item1 in _ChamadoViewModel.ChamadoOcorrencias)
                //{
                //    usuario = _usuarioServico.ObterPorId(item1.UsuarioId);
                //    item1.CodUsuario = usuario.Codigo;
                //    item1.NomeUsuario = usuario.Nome;
                //}

                _ChamadoViewModel.Mensagem = mensagem;
                return _ChamadoViewModel;
            }
            catch (Exception ex)
            {
                _ChamadoViewModel.Mensagem = ex.Message;
                return _ChamadoViewModel;
            }
        }

        [Route("Editar")]
        [HttpGet]
        public ChamadoViewModel Editar(int idUsuario, int id)
        {
            _chamadoServico = new ChamadoServico();
            try
            {
                string mensagem = "";
                var item = _chamadoServico.Editar(idUsuario, id, ref mensagem);
                _ChamadoViewModel = item.Adapt<ChamadoViewModel>();

                _ChamadoViewModel.ChamadosStatus.Clear();

                foreach (var chamadoStatus in item.ChamadosStatus)
                {
                    ChamadoStatusViewModel model = new ChamadoStatusViewModel();

                    model.Data = chamadoStatus.Data;
                    model.Hora = (TimeSpan)chamadoStatus.Hora;
                    model.NomeStatus = chamadoStatus.Status.Nome;
                    model.NomeUsuario = chamadoStatus.Usuario.Nome;                    
                    _ChamadoViewModel.ChamadosStatus.Add(model);
                }

                //Utils.AutoMappear(item, _ChamadoViewModel);

                

                PopularDados(_ChamadoViewModel, item, idUsuario);

                if (_ChamadoViewModel.UsuarioPermissaoAlterarDataHora == false)
                {
                    if (item.TipoMovimento == (int)EnumChamado.Chamado)
                        _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _usuarioPermissaoServico.PermissaoAlterarDataHoraChamado(idUsuario);
                    else
                        _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _usuarioPermissaoServico.PermissaoAlterarDataHoraAtividade(idUsuario);
                }

                _ChamadoViewModel.UsuarioPermissaoAlterarDataHora = _ChamadoViewModel.UsuarioPermissaoAlterarDataHora;

                _ChamadoViewModel.Mensagem = mensagem;
                return _ChamadoViewModel;
            }
            catch (Exception ex)
            {
                _ChamadoViewModel.Mensagem = ex.Message;
                return _ChamadoViewModel;
            }
        }

        [Route("RetornarAnexos")]
        [HttpGet]
        public ChamadoAnexoViewModel[] RetornarAnexos(int idChamado, EnumChamado enChamado)
        {
            try
            {
                _chamadoServico = new ChamadoServico(enChamado);
                var lista = _chamadoServico.RetornarAnexos(idChamado);
                var retorno = lista.Adapt<ChamadoAnexoViewModel[]>();
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ChamadoConsultaViewModel[] Filtrar([FromBody] ChamadoFiltroViewModel filtro, int idUsuario, string campo, string valor, bool contem, EnumChamado enChamado)
        {
            try
            {
                _chamadoServico = new ChamadoServico(enChamado);
                return _chamadoServico.Filtrar(filtro, campo, valor, idUsuario, contem, enChamado).ToArray();

                //_chamadoServico = new ChamadoServico(enChamado);
                //var FiltroChamado = filtro.Adapt<ChamadoFiltro>();
                //var Lista = _chamadoServico.Filtrar(filtro, campo, valor,idUsuario, contem, enChamado);
                //var model = new List<ChamadoConsultaViewModel>();

                //foreach (var item in Lista)
                //{
                //    var viewModel = new ChamadoConsultaViewModel();
                //    Utils.AutoMappear(item, viewModel);
                //    model.Add(viewModel);
                //}

                //return model.ToArray();
            }
                catch (Exception ex)
            {
                        throw new Exception(ex.Message);
            }
        }
        [Route("BuscarModuloProduto")]
        [HttpGet]
        public ChamadoViewModel BuscarModuloProduto(int idCliente, int idModulo)
        {
            var clienteModuloServico = new ClienteModuloServico();
            var chamadoViewModel = new ChamadoViewModel();


            try
            {
                var model = clienteModuloServico.ObterPorModulo(idCliente, idModulo);

                if (model != null)
                {
                    chamadoViewModel.ModuloId = model.ModuloId;
                    chamadoViewModel.CodModulo = model.Modulo.Codigo;
                    chamadoViewModel.NomeModulo = model.Modulo.Nome;

                    if (model.Produto != null)
                    {
                        chamadoViewModel.ProdutoId = model.ProdutoId;
                        chamadoViewModel.CodProduto = model.Produto.Codigo;
                        chamadoViewModel.NomeProduto = model.Produto.Nome;
                    }
                }
                return chamadoViewModel;
            }
            catch (Exception ex)
            {
                chamadoViewModel.Mensagem = ex.Message;
                return chamadoViewModel;
            }
        }

        [HttpPost]
        public ChamadoViewModel Incluir([FromBody]ChamadoViewModel model, int idUsuario, bool ocorrencia)
        {
            var chamadoViewModel = new ChamadoViewModel();
            _chamadoServico = new ChamadoServico();
            try
            {
                var chamado = model.Adapt<Chamado>();
                _chamadoServico.Salvar(chamado, idUsuario, ocorrencia);
                chamadoViewModel = chamado.Adapt<ChamadoViewModel>();
                return chamadoViewModel;
            }
            catch (Exception ex)
            {
                chamadoViewModel.Mensagem = ex.Message;
                return chamadoViewModel;
            }
        }

        [HttpPut]
        public ChamadoViewModel Update([FromBody]ChamadoViewModel model, int idUsuario, bool ocorrencia)
        {
            _chamadoServico = new ChamadoServico();
            var chamadoViewModel = new ChamadoViewModel();
            try
            {
                var chamado = model.Adapt<Chamado>();
                _chamadoServico.Salvar(chamado, idUsuario, ocorrencia);
                chamadoViewModel = chamado.Adapt<ChamadoViewModel>();
                return chamadoViewModel;
            }
            catch (Exception ex)
            {
                chamadoViewModel.Mensagem = ex.Message;
                return chamadoViewModel;
            }
        }

        [HttpDelete]
        public ChamadoViewModel Delete(int idUsuario, int id)
        {
            _chamadoServico = new ChamadoServico();
            var model = new ChamadoViewModel();
            try
            {
                _chamadoServico.Excluir(idUsuario, id);
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        /*

        SALVAR
            Se for Quadro
                fechar a tela
            Se encerrarAgendamento
                Funcoes.IdSelecionado = id

        =================================================
        TELA OCORRENCIAS
        NOVO
            Buscar dados do usuario logado
            Buscar dados do cliente do chamado

        EDITAR
            Ver autoriazacao para editar

        SALVAR
            Se Inclusao entao abrir tela de status
            Se deu certo
                Se quadro e ocorrencia
                    Salvar tudo
                    se inclusao
                        enviar email
         */
    }
}
