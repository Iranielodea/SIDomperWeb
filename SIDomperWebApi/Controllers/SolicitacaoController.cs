using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Funcoes;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/solicitacao")]
    public class SolicitacaoController : ApiController
    {
        //private readonly SolicitacaoServico _solicitacaoServico;
        //private readonly UsuarioServico _usuarioServico;
        private readonly IServicoSolicitacao _servicoSolicitacao;
        private readonly IServicoCliente _servicoCliente;
        private readonly IServicoUsuario _servicoUsuario;

        public SolicitacaoController(IServicoSolicitacao servicoSolicitacao,
            IServicoCliente servicoCliente, IServicoUsuario servicoUsuario)
        {
            //_solicitacaoServico = new SolicitacaoServico();
            //_usuarioServico = new UsuarioServico();
            _servicoSolicitacao = servicoSolicitacao;
            _servicoCliente = servicoCliente;
            _servicoUsuario = servicoUsuario;
        }

        [Route("ObterPorId")]
        [HttpGet]
        public SolicitacaoViewModel ObterPorId(int id)
        {
            var viewModel = new SolicitacaoViewModel();
            try
            {
                var model = _servicoSolicitacao.ObterPorId(id);
                viewModel = model.Adapt<SolicitacaoViewModel>();
                return viewModel;
            }
            catch (Exception ex)
            {
                viewModel.Mensagem = ex.Message;
                return viewModel;
            }
        }

        [Route("Editar")]
        [HttpGet]
        public SolicitacaoViewModel Editar(int idUsuario, int id)
        {
            var viewModel = new SolicitacaoViewModel();
            try
            {
                string mensagem = "";
                var model = _servicoSolicitacao.Editar(id, idUsuario, ref mensagem);
                viewModel = model.Adapt<SolicitacaoViewModel>();
                PopularSolicitacao(viewModel, model, idUsuario);
                viewModel.Mensagem = mensagem;
                return viewModel;
            }
            catch (Exception ex)
            {
                viewModel.Mensagem = ex.Message;
                return viewModel;
            }
        }

        [Route("Novo")]
        [HttpGet]
        public SolicitacaoViewModel Novo(int idUsuario)
        {
            var viewModel = new SolicitacaoViewModel();
            try
            {
                var model = _servicoSolicitacao.Novo(idUsuario);
                viewModel = model.Adapt<SolicitacaoViewModel>();
                viewModel.UsuarioAberturaId = model.UsuarioAbertura.Id;
                viewModel.UsuarioAberturaCodigo = model.UsuarioAbertura.Codigo;
                viewModel.UsuarioAberturaNome = model.UsuarioAbertura.Nome;
                viewModel.StatusId = model.Status.Id;
                viewModel.StatusCodigo = model.Status.Codigo;
                viewModel.StatusNome = model.Status.Nome;
                return viewModel;
            }
            catch (Exception ex)
            {
                viewModel.Mensagem = ex.Message;
                return viewModel;
            }
        }

        [Route("Filtrar")]
        [HttpPost]
        public IEnumerable<SolicitacaoConsultaViewModel> Filtrar([FromBody]SolicitacaoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem = true)
        {
            try
            {
                return _servicoSolicitacao.Filtrar(filtro, campo, texto, usuarioId, contem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Incluir")]
        [HttpPost]
        public SolicitacaoViewModel Incluir([FromBody]SolicitacaoViewModel viewModel, int usuarioId)
        {
            try
            {
                var model = viewModel.Adapt<Solicitacao>();
                _servicoSolicitacao.Salvar(model, usuarioId);
                viewModel = model.Adapt<SolicitacaoViewModel>();
                return viewModel;
            }
            catch (Exception ex)
            {
                viewModel.Mensagem = ex.Message;
                return viewModel;
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public SolicitacaoViewModel Update([FromBody]SolicitacaoViewModel viewModel, int usuarioId)
        {
            try
            {
                var model = viewModel.Adapt<Solicitacao>();
                _servicoSolicitacao.Salvar(model, usuarioId);
                viewModel = model.Adapt<SolicitacaoViewModel>();
                return viewModel;
            }
            catch (Exception ex)
            {
                viewModel.Mensagem = ex.Message;
                return viewModel;
            }
        }

        [HttpDelete]
        public SolicitacaoViewModel Delete(int idUsuario, int id)
        {
            var viewModel = new SolicitacaoViewModel();
            try
            {
                var model = _servicoSolicitacao.ObterPorId(id);
                _servicoSolicitacao.Excluir(model, idUsuario);
                return viewModel;
            }
            catch (Exception ex)
            {
                viewModel.Mensagem = ex.Message;
                return viewModel;
            }
        }

        [Route("BuscarModuloProduto")]
        [HttpGet]
        public SolicitacaoViewModel BuscarModuloProduto(int idCliente, int idModulo)
        {
            var clienteModuloServico = new ClienteModuloServico();
            var solicitacaoViewModel = new SolicitacaoViewModel();
            try
            {
                var cliente = _servicoCliente.ObterPorId(idCliente); // clienteModuloServico.ObterPorModulo(idCliente, idModulo);
                var model = cliente.ClienteModulos.FirstOrDefault(x => x.ModuloId == idModulo);

                if (model != null)
                {
                    solicitacaoViewModel.ModuloId = model.ModuloId;
                    solicitacaoViewModel.ModuloCodigo = model.Modulo.Codigo;
                    solicitacaoViewModel.ModuloNome = model.Modulo.Nome;

                    if (model.Produto != null)
                    {
                        solicitacaoViewModel.ProdutoId = model.ProdutoId;
                        solicitacaoViewModel.ProdutoCodigo = model.Produto.Codigo;
                        solicitacaoViewModel.ProdutoNome = model.Produto.Nome;
                    }
                }
                return solicitacaoViewModel;
            }
            catch (Exception ex)
            {
                solicitacaoViewModel.Mensagem = ex.Message;
                return solicitacaoViewModel;
            }
        }

        private void PopularSolicitacao(SolicitacaoViewModel viewModel, Solicitacao model, int usuarioId)
        {
            if (model.UsuarioAnalista != null)
            {
                viewModel.AnalistaCodigo = model.UsuarioAnalista.Codigo;
                viewModel.AnalistaNome = model.UsuarioAnalista.Nome;
            }

            if (model.Categoria != null)
            {
                viewModel.CategoriaCodigo = model.Categoria.Codigo;
                viewModel.CategoriaNome = model.Categoria.Nome;
            }

            if (model.Cliente != null)
            {
                viewModel.ClienteCodigo = model.Cliente.Codigo;
                viewModel.ClienteNome = model.Cliente.Nome;
            }

            if (model.UsuarioDesenvolvedor !=  null)
            {
                viewModel.DesenvolvedorCodigo = model.UsuarioDesenvolvedor.Codigo;
                viewModel.DesenvolvedorNome = model.UsuarioDesenvolvedor.Nome;
            }

            if (model.Modulo != null)
            {
                viewModel.ModuloCodigo = model.Modulo.Codigo;
                viewModel.ModuloNome = model.Modulo.Nome;
            }

            if (model.Produto != null)
            {
                viewModel.ProdutoCodigo = model.Produto.Codigo;
                viewModel.ProdutoNome = model.Produto.Nome;
            }

            if (model.Status != null)
            {
                viewModel.StatusCodigo = model.Status.Codigo;
                viewModel.StatusNome = model.Status.Nome;
            }

            if (model.Tipo != null)
            {
                viewModel.TipoCodigo = model.Tipo.Codigo;
                viewModel.TipoNome = model.Tipo.Nome;
            }

            if (model.VersaoRelacao != null)
            {
                viewModel.VersaoDescricao = model.VersaoRelacao.VersaoStr;
            }

            viewModel.SolicitacaoPermissaoViewModel = _servicoSolicitacao.BuscarPermissoes(usuarioId);

            if (viewModel.SolicitacaoCronogramas != null)
            {
                foreach (var item in viewModel.SolicitacaoCronogramas)
                {
                    item.CodigoUsuario = item.Usuario.Codigo;
                    item.NomeUsuario = item.Usuario.Nome;
                }
            }

            if (viewModel.SolicitacaoOcorrencias !=  null)
            {
                foreach (var item in viewModel.SolicitacaoOcorrencias)
                {
                    item.CodigoUsuario = item.Usuario.Codigo;
                    item.NomeUsuario = item.Usuario.Nome;
                }
            }

            if (viewModel.SolicitacaoStatus != null)
            {
                foreach (var item in viewModel.SolicitacaoStatus)
                {
                    item.NomeStatus = item.Status.Nome;
                    item.NomeUsuario = item.Usuario.Nome;
                    item.HoraStr = Utils.FormatarHHMMSS(item.Hora.Value);
                }
            }
        }

        [Route("PermissaoSolicitacaoQuadro")]
        [HttpGet]
        public SolicitacaoPermissaoViewModel PermissaoSolicitacaoQuadro(int usuarioId)
        {
            var viewModel = new SolicitacaoPermissaoViewModel();
            var usuario = _servicoUsuario.ObterPorId(usuarioId);

            viewModel.PermissaoAbertura = _servicoSolicitacao.PermissaoAbertura(usuario); // _solicitacaoServico.PermissaoAbertura(usuario);
            viewModel.PermissaoAnalise = _servicoSolicitacao.PermissaoAnalise(usuario); // _solicitacaoServico.PermissaoAnalise(usuario);
            viewModel.PermissaoOcorrenciaGeral = _servicoSolicitacao.PermissaoOcorrenciaGeral(usuario); // _solicitacaoServico.PermissaoOcorrenciaGeral(usuario);
            viewModel.PermissaoOcorrenciaRegra = _servicoSolicitacao.PermissaoOcorrenciaRegra(usuario); // _solicitacaoServico.PermissaoOcorrenciaRegra(usuario);
            viewModel.PermissaoOcorrenciaTecnica = _servicoSolicitacao.PermissaoOcorrenciaTecnica(usuario); // _solicitacaoServico.PermissaoOcorrenciaTecnica(usuario);
            viewModel.PermissaoStatus = _servicoSolicitacao.PermissaoStatus(usuario); // _solicitacaoServico.PermissaoStatus(usuario);
            viewModel.PermissaoTempo = _servicoSolicitacao.PermissaoSolicitacaoTempo(usuario, usuarioId); // _solicitacaoServico.PermissaoSolicitacaoTempo(usuario);
            viewModel.PermissaoConfTempoGeral = _servicoSolicitacao.PermissaoConferenciaTempoGeral(usuario, usuarioId);  //_solicitacaoServico.PermissaoConferenciaTempoGeral(usuario);
            viewModel.MostrarAnexos = _servicoSolicitacao.MostrarAnexos(usuario); // _solicitacaoServico.MostrarAnexos(usuario);
            viewModel.CaminhoAnexos = _servicoSolicitacao.RetornarCaminhoAnexo(); // _solicitacaoServico.RetornarCaminhoAnexo();
            return viewModel;
        }
    }
}
