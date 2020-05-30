using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly ClienteServico _clienteServico;

        public ClienteController()
        {
            _clienteServico = new ClienteServico();
        }

        // GET: Cliente
        [HttpGet]
        public List<Cliente> Get()
        {
            var lista = _clienteServico.Listar(1, "");            
            return lista;
        }

        [HttpGet]
        public ClienteViewModelApi ObterPorId(int id)
        {
            var model = new ClienteViewModelApi();
            try
            {
                var item = _clienteServico.ObterPorId(id);
                model = item.Adapt<ClienteViewModelApi>();
                model.NomeUsuario = item.Usuario.Nome;

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ClienteViewModelApi Editar(int idUsuario, int idCliente)
        {
            var model = new ClienteViewModelApi();
            try
            {
                bool permissao = true;
                var item = _clienteServico.Editar(idUsuario, idCliente, ref permissao);
                model = item.Adapt<ClienteViewModelApi>();
                if (permissao == false)
                    model.Mensagem = "Usuário sem permissão!";

                if (item.Usuario != null)
                {
                    model.CodigoUsuario = item.Usuario.Codigo;
                    model.NomeUsuario = item.Usuario.Nome;
                }

                if (model.ClienteModulos !=  null)
                {
                    var modulo = new ClienteModulo();

                    foreach (var climodulo in model.ClienteModulos)
                    {
                        modulo = item.ClienteModulos.FirstOrDefault(x => x.Id == climodulo.Id);
                        climodulo.CodModulo = modulo.Modulo.Codigo;
                        climodulo.NomeModulo = modulo.Modulo.Nome;
                        if (modulo.Produto != null)
                        {
                            climodulo.CodProduto = modulo.Produto.Codigo;
                            climodulo.NomeProduto = modulo.Produto.Nome;
                        }
                    }
                }

                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ClienteViewModelApi Novo(string novo, int idCliente)
        {
            var model = new ClienteViewModelApi();
            try
            {
                var item = _clienteServico.Novo(idCliente);
                model = item.Adapt<ClienteViewModelApi>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpGet]
        public ClienteViewModelApi ObterPorCodigo(int codigo)
        {
            var model = new ClienteViewModelApi();
            try
            {
                var prod = _clienteServico.ObterPorCodigo(codigo);
                model = prod.Adapt<ClienteViewModelApi>();
                model.NomeUsuario = prod.Usuario.Nome;
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [HttpPost]
        public ClienteConsultaViewModelApi[] Filtrar([FromBody] ClienteFiltroViewModelApi filtro, int idUsuario, bool contem = true)
        {
            try
            {
                return _clienteServico.Filtrar(idUsuario, filtro, 1, filtro.Campo, filtro.Valor, contem).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ClienteViewModelApi Incluir(ClienteViewModelApi model)
        {
            var clienteViewModel = new ClienteViewModelApi();
            try
            {
                var cliente = model.Adapt<Cliente>();
                _clienteServico.SalvarAPI(cliente);
                clienteViewModel = cliente.Adapt<ClienteViewModelApi>();
                return clienteViewModel;
            }
            catch (Exception ex)
            {
                clienteViewModel.Mensagem = ex.Message;
                return clienteViewModel;
            }
        }

        [HttpPut]
        public ClienteViewModelApi Update(ClienteViewModelApi model)
        {
            var clienteViewModel = new ClienteViewModelApi();
            try
            {
                var cliente = model.Adapt<Cliente>();
                _clienteServico.SalvarAPI(cliente);
                clienteViewModel = cliente.Adapt<ClienteViewModelApi>();
                return clienteViewModel;
            }
            catch (Exception ex)
            {
                clienteViewModel.Mensagem = ex.Message;
                return clienteViewModel;
            }
        }

        [HttpDelete]
        public ClienteViewModelApi Delete(int idCliente, int id)
        {
            var model = new ClienteViewModelApi();
            try
            {
                var cliente = _clienteServico.ObterPorId(id);
                _clienteServico.Excluir(idCliente, cliente);
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