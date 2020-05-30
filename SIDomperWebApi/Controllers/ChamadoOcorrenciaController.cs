using Mapster;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/ChamadoOcorrencia")]
    public class ChamadoOcorrenciaController : ApiController
    {
        private UsuarioServico _usuarioServico;
        private ChamadoOcorrenciaServico _chamadoOcorrenciaServico;

        public ChamadoOcorrenciaController()
        {
            _usuarioServico = new UsuarioServico();
            _chamadoOcorrenciaServico = new ChamadoOcorrenciaServico();
        }

        [HttpGet]
        public ChamadoOcorrenciaViewModel Novo(string novo, int idUsuario)
        {
            var chamadoOcorrenciaViewModel = new ChamadoOcorrenciaViewModel();
            try
            {
                 var model = _chamadoOcorrenciaServico.Novo(idUsuario);
                chamadoOcorrenciaViewModel.UsuarioId = model.UsuarioId;
                chamadoOcorrenciaViewModel.CodUsuario = model.Usuario.Codigo;
                chamadoOcorrenciaViewModel.NomeUsuario = model.Usuario.Nome;
                return chamadoOcorrenciaViewModel;

            }
            catch(Exception ex)
            {
                chamadoOcorrenciaViewModel.Mensagem = ex.Message;
                return chamadoOcorrenciaViewModel;
            }
        }

        [HttpGet]
        public ChamadoOcorrenciaViewModel ObterPorId(int id)
        {
            var model = new ChamadoOcorrenciaViewModel();
            try
            {
                string mensagem = "";
                var item = _chamadoOcorrenciaServico.ObterPorId(id);
                model = item.Adapt<ChamadoOcorrenciaViewModel>();
                model.CodUsuario = item.Usuario.Codigo;
                model.NomeUsuario = item.Usuario.Nome;
                model.Mensagem = mensagem;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ChamadoOcorrenciaViewModel PermissaoAlterarDataHora(int idUsuarioLogado, int idUsuarioGravado, EnumChamado enChamado)
        {
            var model = new ChamadoOcorrenciaViewModel();
            try
            {
                string Msg = "";
                var usuario = _usuarioServico.ObterPorId(idUsuarioLogado);
                var permissao = _chamadoOcorrenciaServico.PermissaoChamadoOcorrenciaDataHora(idUsuarioGravado, ref Msg, enChamado, usuario);

                model.Mensagem = Msg;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ChamadoOcorrenciaViewModel PermissaoAlterarExcluirOcorrencia(int idUsuarioLogado, int idOcorrencia, EnumChamado tipo, int idUsuarioGravado, EnTipoManutencao enTipoManutencao)
        {
            var model = new ChamadoOcorrenciaViewModel();
            try
            {
                bool permissao;
                var usuario = _usuarioServico.ObterPorId(idUsuarioLogado);

                if (enTipoManutencao == EnTipoManutencao.Editar)
                    permissao = _chamadoOcorrenciaServico.PermissaoChamadoOcorrenciaAlterar(idUsuarioGravado, idOcorrencia, tipo, usuario);
                else
                    permissao = _chamadoOcorrenciaServico.PermissaoChamadoOcorrenciaExcluir(idUsuarioGravado, idOcorrencia, tipo, usuario);

                model.Mensagem = "OK";
                if (permissao == false)
                    model.Mensagem = "Usuário sem Permissão!";

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("RetornarProblemasSolucoes")]
        [HttpGet]
        public ProblemaSolucaoViewModel[] RetornarProblemasSolucoes(string texto, int idUsuario, int idCliente, EnumChamado enumChamado)
        {
            try
            {
                _chamadoOcorrenciaServico = new ChamadoOcorrenciaServico();
                var lista = _chamadoOcorrenciaServico.ProblemaSolucao(texto, idUsuario, idCliente, EnumChamado.Chamado);
                var viewModel = lista.Adapt<ProblemaSolucaoViewModel[]>();
                return viewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
