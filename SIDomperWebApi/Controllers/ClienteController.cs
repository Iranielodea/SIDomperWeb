using Mapster;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Linq;
using System.Web.Http;

namespace SIDomperWebApi.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        //private readonly ClienteServico _clienteServico;
        private readonly IServicoCliente _servicoCliente;

        public ClienteController(IServicoCliente servicoCliente)
        {
            //_clienteServico = new ClienteServico();
            _servicoCliente = servicoCliente;
        }

        // GET: Cliente
        //[HttpGet]
        //public List<Cliente> Get()
        //{
        //    var lista = _servicoCliente.Listar(1, "");
        //    //var lista = _clienteServico.Listar(1, "");
        //    return lista;
        //}

        [Route("ObterPorId")]
        [HttpGet]
        public ClienteViewModelApi ObterPorId(int id)
        {
            var model = new ClienteViewModelApi();
            try
            {
                var item = _servicoCliente.ObterPorId(id);
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

        [Route("Editar")]
        [HttpGet]
        public ClienteViewModelApi Editar(int idUsuario, int idCliente)
        {
            var model = new ClienteViewModelApi();
            try
            {
                string mensagem = "";
                var item = _servicoCliente.Editar(idCliente, idUsuario, ref mensagem);
                model = item.Adapt<ClienteViewModelApi>();

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

        [Route("ImportarXML")]
        [HttpPost]
        public void ImportarXML()
        {
            var listaxml = _servicoCliente.ImportarXml(@"C:\Projetos\Domper\SIDomperWeb\Banco\269.xml");
        }

        [Route("Login")]
        [HttpGet]
        public ClienteLoginViewModel Login(string cnpj)
        {
            var clienteLoginViewModel = new ClienteLoginViewModel();
            try
            {
                clienteLoginViewModel = _servicoCliente.Login(cnpj);
                return clienteLoginViewModel;
            }
            catch(Exception ex)
            {
                clienteLoginViewModel.Resultado = ex.Message;
                return clienteLoginViewModel;
            }
        }

        [Route("Novo")]
        [HttpGet]
        public ClienteViewModelApi Novo(int idUsuario)
        {
            var model = new ClienteViewModelApi();
            try
            {
                var item = _servicoCliente.Novo(idUsuario);
                model = item.Adapt<ClienteViewModelApi>();
                return model;
            }
            catch (Exception ex)
            {
                model.Mensagem = ex.Message;
                return model;
            }
        }

        [Route("ObterPorCodigo")]
        [HttpGet]
        public ClienteViewModelApi ObterPorCodigo(int codigo)
        {
            var model = new ClienteViewModelApi();
            try
            {
                var prod = _servicoCliente.ObterPorCodigo(codigo);
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

        [Route("Filtrar")]
        [HttpPost]
        public ClienteConsultaViewModelApi[] Filtrar([FromBody] ClienteFiltroViewModelApi filtro, int idUsuario, bool contem = true)
        {
            try
            {
                return _servicoCliente.Filtrar(idUsuario, filtro, 1, filtro.Campo, filtro.Valor, contem).ToArray();
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
                _servicoCliente.Salvar(cliente);
                //_clienteServico.SalvarAPI(cliente);
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
                _servicoCliente.Salvar(cliente);
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
        public ClienteViewModelApi Delete(int id, int idCliente)
        {
            var model = new ClienteViewModelApi();
            try
            {
                _servicoCliente.Excluir(_servicoCliente.ObterPorId(id), idCliente);
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