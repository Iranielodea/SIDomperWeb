using SIDomper.AdminWEB.Controllers;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIDomper.AdminWeb.Controllers
{
    public class ChamadoController : AbstractLogadoController
    {
        private readonly ChamadoServico _servico;
        private readonly ParametroServico _parametroServico;
        private readonly StatusServico _statusServico;

        public ChamadoController()
        {
            _servico = new ChamadoServico(Dominio.Enumeracao.EnumChamado.Chamado);
            _parametroServico = new ParametroServico();
            _statusServico = new StatusServico();
        }

        // GET: Chamado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quadro()
        {
            var quadroViewModel = _servico.AbrirQuadro(UsuarioId, 0);

            return View(quadroViewModel);
        }

        public ActionResult Editar()
        {
            var viewModel = new ChamadoEditarViewModel();
            var chamado = new Chamado();
            var usuarioServico = new UsuarioServico();

            string codStatusAbertura = _servico.StatusAbertura();


            viewModel.DataAbertura = DateTime.Now.Date;
            viewModel.HoraAbertura = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            viewModel.Chamado = chamado;
            viewModel.Chamado.Cliente = new Cliente();
            viewModel.Chamado.Modulo = new Modulo();
            viewModel.Chamado.Produto = new Produto();
            viewModel.Chamado.Tipo = new Tipo();
            viewModel.Chamado.Status = _statusServico.ObterPorCodigo(int.Parse(codStatusAbertura));
            viewModel.Chamado.UsuarioAbertura = usuarioServico.ObterPorId(UsuarioId);
            viewModel.Chamado.DataAbertura = DateTime.Now.Date;
            viewModel.Chamado.UsuarioAberturaId = UsuarioId;
            viewModel.Chamado.UsuarioAbertura.Nome = UsuarioNome;
            viewModel.Chamado.HoraAbertura = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            viewModel.Chamado.Nivel = 2;
            return View(viewModel);
        }

        public ActionResult ListarModulos(string term)
        {
            var servico = new ModuloServico();
            var modulos = servico.Listar(term);

            var result = new
            {
                results = modulos.Select(x => new
                {
                    id = x.Id.ToString(),
                    text = x.Nome
                })
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarTipos(string term)
        {
            var servico = new TipoServico();
            var tipos = servico.ListarTipos(term, Dominio.Enumeracao.EnTipos.Chamado);

            var result = new
            {
                results = tipos.Select(x => new
                {
                    id = x.Id.ToString(),
                    text = x.Nome
                })
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarClientes(string term)
        {
            var servico = new ClienteServico();
            var clientes = servico.Listar(UsuarioId, term);

            var result = new
            {
                results = clientes.Select(x => new
                {
                    id = x.Id.ToString(),
                    text = x.Nome
                })
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarDadosCliente(int id)
        {
            var servico = new ClienteServico();
            var clientes = servico.ObterPorId(id);


            List<Object> resultado = new List<object>();
            resultado.Add(new
            {
                //Nome = clientes.Nome,
                //Bairro = clientes.Bairro,
                //Endereco = clientes.Endereco,
                Fantasia = clientes.Fantasia
                //Dcto = clientes.Dcto,
                //IE = clientes.IE,
                //IdCidade = clientes.CidadeId,
                //NomeCidade = clientes.Cidade.Nome,
                //Cep = clientes.CEP,
                //Fone1 = clientes.Fone1,
                //Fone2 = clientes.Fone2,
                //celular = clientes.Celular,
                //OutroFone = clientes.OutroFone,
                //UF = clientes.Cidade.UF,
                //ContatoCompraVenda = clientes.ContatoCompraVenda,
                //FoneContatoCompraVenda = clientes.FoneContatoCompraVenda,
                //ContatoFinanceiro = clientes.ContatoFinanceiro,
                //FoneContatoFinanceiro = clientes.FoneContatoFinanceiro,
                //RepresentanteLegal = clientes.RepresentanteLegal,
                //CPFRepresentanteLegal = clientes.CPFRepresentanteLegal,
                //Enquadramento = clientes.Enquadramento
            });
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult BuscarDadosModulo(int idCliente, int idModulo)
        public JsonResult BuscarDadosModulo(int idModulo)
        {
            //idCliente = 71;
            var servico = new ClienteModuloServico();
            // var modulo = servico.ObterPorModulo(idCliente, idModulo);
            var modulo = servico.ObterPorId(67300);


            List<Object> result = new List<object>();
            result.Add(new
            {
                idProduto = modulo.ProdutoId
                //NomeProduto = modulo.Produto.Nome
            });

            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}