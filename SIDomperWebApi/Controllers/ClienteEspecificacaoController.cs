using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class ClienteEspecificacaoController : ApiController
    {
        private readonly ClienteEspecificacaoServico _clienteEspecificacaoServico;

        public ClienteEspecificacaoController(IServicoClienteEspecificacao clienteEspecificacao)
        {
            _clienteEspecificacaoServico = new ClienteEspecificacaoServico();
        }

        [HttpGet]
        public ClienteEspecificacaoViewModel Novo(string novo, int idUsuario)
        {
            var model = new ClienteEspecificacaoViewModel();
            try
            {
                var item = _clienteEspecificacaoServico.Novo(idUsuario);
                model = item.Adapt<ClienteEspecificacaoViewModel>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ClienteEspecificacaoViewModel ObterPorId(int id)
        {
            var model = new ClienteEspecificacaoViewModel();
            try
            {
                var item = _clienteEspecificacaoServico.ObterPorId(id);
                model = item.Adapt<ClienteEspecificacaoViewModel>();

                model.CodUsuario = item.Usuario.Codigo;
                model.NomeUsuario = item.Usuario.Nome;

                model.CodCliente = item.Cliente.Codigo;
                model.NomeCliente = item.Cliente.Nome;

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public IEnumerable<ClienteEspecificacaoConsultaViewModel> Filtrar(int idCliente)
        {
            try
            {
                var lista = _clienteEspecificacaoServico.Filtrar(idCliente);
                var model = lista.Adapt<ClienteEspecificacaoConsultaViewModel[]>();
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ClienteEspecificacaoViewModel Incluir(ClienteEspecificacaoViewModel model)
        {
            var clienteEspecificacaoViewModel = new ClienteEspecificacaoViewModel();
            try
            {
                var clienteEspecificacao = model.Adapt<ClienteEspecifiacao>();
                _clienteEspecificacaoServico.Salvar(clienteEspecificacao);
                clienteEspecificacaoViewModel = clienteEspecificacao.Adapt<ClienteEspecificacaoViewModel>();
                return clienteEspecificacaoViewModel;
            }
            catch (Exception ex)
            {
                clienteEspecificacaoViewModel.Mensagem = ex.Message;
                return clienteEspecificacaoViewModel;
            }
        }

        [HttpPut]
        public ClienteEspecificacaoViewModel Update(ClienteEspecificacaoViewModel model)
        {
            var clienteEspecificacaoViewModel = new ClienteEspecificacaoViewModel();
            try
            {
                var clienteEspecificacao = model.Adapt<ClienteEspecifiacao>();
                _clienteEspecificacaoServico.Salvar(clienteEspecificacao);
                clienteEspecificacaoViewModel = clienteEspecificacao.Adapt<ClienteEspecificacaoViewModel>();
                return clienteEspecificacaoViewModel;
            }
            catch (Exception ex)
            {
                clienteEspecificacaoViewModel.Mensagem = ex.Message;
                return clienteEspecificacaoViewModel;
            }
        }

        [HttpDelete]
        public ClienteEspecificacaoViewModel Delete(int idUsuario, int id)
        {
            var model = new ClienteEspecificacaoViewModel();
            try
            {
                var cliente = _clienteEspecificacaoServico.ObterPorId(id);
                _clienteEspecificacaoServico.Excluir(cliente);
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

    }
}
