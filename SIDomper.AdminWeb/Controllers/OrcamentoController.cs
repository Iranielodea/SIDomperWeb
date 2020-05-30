using SIDomper.AdminWEB.Controllers;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Servicos.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SIDomper.AdminWeb.Controllers
{
    public class OrcamentoController : AbstractLogadoController
    {
        private readonly OrcamentoServico _servico;
        private readonly ModuloServico _moduloServico;
        private readonly ProdutoServico _produtoServico;
        private readonly OrcamentoViewModel _orcamentoViewModel;

        public OrcamentoController()
        {
            _servico = new OrcamentoServico();
            _moduloServico = new ModuloServico();
            _produtoServico = new ProdutoServico();
            _orcamentoViewModel = new OrcamentoViewModel();
            
        }
        // GET: Orcamento
        public ActionResult Index()
        {
            //if (!_servico.PermissaoAcesso(UsuarioId))
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            PreencherCombo(_orcamentoViewModel);
            _orcamentoViewModel.Campo = "Cli_Nome";
            _orcamentoViewModel.Texto = "ABCDEF";
            _orcamentoViewModel.ListaConsulta = Filtrar(_orcamentoViewModel, _orcamentoViewModel.Filtro);
            _orcamentoViewModel.Texto = "";

            return View(_orcamentoViewModel);
        }

        [HttpPost]
        public ActionResult Index(OrcamentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ListaConsulta = Filtrar(model, model.Filtro);
                    PreencherCombo(model);

                    return View(model);
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return View(model);
        }

        private void PreencherCombo(OrcamentoViewModel model)
        {
            model.Campos.Add(new OrcamentoCamposPesquisaViewModel { Campo = "Orc_Data", Descricao = "Data" });
            model.Campos.Add(new OrcamentoCamposPesquisaViewModel { Campo = "Orc_Numero", Descricao = "Numero" });
            model.Campos.Add(new OrcamentoCamposPesquisaViewModel { Campo = "Cli_Nome", Descricao = "Cliente" });
            model.Campos.Add(new OrcamentoCamposPesquisaViewModel { Campo = "Usu_Nome", Descricao = "Consultor" });
        }

        private List<OrcamentoConsulta> Filtrar(OrcamentoViewModel model, OrcamentoFiltro filtro)
        {
            var lista = _servico.Filtrar(UsuarioId, filtro, model.Campo, model.Texto);
            return lista;
        }

        public ActionResult ListarProdutos()
        {
            var model = new OrcamentoNovoViewModel();
            model.Orcamento.Bairro = "Centro";
            model.Orcamento.Data = DateTime.Now.Date;
            model.Produtos = _produtoServico.Listar("");
            return View("EditarItem", model);
        }

        public ActionResult Novo()
        {
            OrcamentoEditarViewModel model = new OrcamentoEditarViewModel();

            model.DataEmissao = DateTime.Now.Date;
            model.Orcamento.SubTipo = 1;
            model.Orcamento.Data = model.DataEmissao;
            model.Orcamento.Enquadramento = "01";
            model.Situacao = "1";
            model.Orcamento.UsuarioId = UsuarioId;
            model.NomeUsuario = UsuarioNome;
            model.NomeCliente = "";
            model.NomeCidade = "";

            model.Orcamento.Cliente = new Cliente();
            model.ListaTipos = ListarTipo();

            return View(model);


            //var model = new OrcamentoNovoViewModel();
            //model.Orcamento.Bairro = "Centro";
            //model.Orcamento.Data = DateTime.Now.Date;
            //model.Produtos = _produtoServico.Listar("");

            //OrcamentoNovoViewModel carrinho = Session["Orcamento"] != null ? (OrcamentoNovoViewModel)Session["Orcamento"] : new OrcamentoNovoViewModel();


            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        if (!_servico.PermissaoIncluir(UsuarioId))
            //        {
            //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Usuário sem Permissão!");
            //        }

            //        var TipoServico = new TipoServico();
            //        var listaTipos = TipoServico.ListarOrcamentos("");

            //        var tipo = new Tipo();
            //        listaTipos.Insert(0, tipo);


            //        model.Orcamento.Data = DateTime.Now.Date;
            //        //model.Orcamento.DataSituacao = 
            //        model.Orcamento.UsuarioId = UsuarioId;
            //        model.Orcamento.Situacao = 1;
            //        model.Orcamento.Observacao = _servico.ObservacaoPadrao().Descricao;
            //        model.Orcamento.EmailEnviado = false;


            //        model.ListaTipos = listaTipos.ToList();

            //    }
            //    catch(Exception ex)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            //    }
            //}

            //return View("Editar", model);
        }

        [HttpPost]
        public ActionResult Novo(OrcamentoEditarViewModel model)
        {
            var clienteServico = new ClienteServico();
            var usuarioServico = new UsuarioServico();
            var cidadeServico = new CidadeServico();
            
            model.Orcamento.Data = model.DataEmissao;
            model.Orcamento.DataSituacao = model.DataSituacao;

            var clienteModel = clienteServico.ObterPorId(model.Orcamento.ClienteId.Value);

            if (clienteModel != null)
            {
                foreach (var itemEmail in clienteModel.Emails)
                {
                    var modelEmail = new OrcamentoEmail();
                    modelEmail.Email = itemEmail.Email;
                    modelEmail.Orcamento = model.Orcamento;
                    model.Orcamento.OrcamentoEmails.Add(modelEmail);
                }

                foreach (var itemContato in clienteModel.Contatos)
                {
                    var modelContato = new Contato();
                    modelContato.Email = itemContato.Email;
                    modelContato.Fone1 = itemContato.Fone1;
                    modelContato.Fone2 = itemContato.Fone2;
                    modelContato.Nome = itemContato.Nome;
                    modelContato.Orcamento = model.Orcamento;
                    model.Orcamento.Contatos.Add(modelContato);
                }
            }

            model.Orcamento.Enquadramento = clienteModel.Enquadramento;
            model.Orcamento.RazaoSocial = clienteModel.Nome;
            model.Orcamento.SubTipo = 2;

            _servico.Salvar(model.Orcamento);

            var servico2 = new OrcamentoServico();
            model.Orcamento = servico2.ObterPorId(model.Orcamento.Id);

            model.DataEmissao = model.Orcamento.Data;
            model.DataSituacao = model.Orcamento.DataSituacao;
            model.ListaTipos = ListarTipo();

            model.NomeUsuario = model.Orcamento.Usuario.Nome;

            if (model.Orcamento.Cliente != null)
                model.NomeCliente = model.Orcamento.Cliente.Nome;

            if (model.Orcamento.Cidade != null)
            {
                model.NomeCidade = model.Orcamento.Cidade.Nome;
                model.UF = model.Orcamento.Cidade.UF;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult PesquisarCliente(int id)
        {
            OrcamentoEditarViewModel model = new OrcamentoEditarViewModel();
            var clienteServico = new ClienteServico();
            var clienteModel = clienteServico.ObterPorId(id);

            model.Orcamento.Fantasia = clienteModel.Fantasia;
            model.Orcamento.Dcto = clienteModel.Dcto;
            model.Orcamento.IE = clienteModel.IE;
            model.Orcamento.Logradouro = clienteModel.Logradouro;
            model.Orcamento.Bairro = clienteModel.Bairro;
            //model.Orcamento.Cidade.Nome = clienteModel.Cidade.Nome;


            return RedirectToAction("Novo", "Orcamento",model);
        }

        public ActionResult NovoModulo()
        {
            OrcamentoNovoViewModel viewModel = new OrcamentoNovoViewModel();
            viewModel.Modulos = _moduloServico.Listar("");

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NovoModulo(OrcamentoNovoViewModel viewModel)
        {
            Session["Orcamento"] = viewModel;

            return RedirectToAction("MontarOrcamento", viewModel);
        }

        public ActionResult MontarOrcamento(OrcamentoNovoViewModel viewModel)
        {

            return View(viewModel);
        }

        private List<Tipo> ListarTipo()
        {
            var TipoServico = new TipoServico();
            return TipoServico.ListarOrcamentos("");
        }

        public ActionResult Editar(int id)
        {
            OrcamentoEditarViewModel model = new OrcamentoEditarViewModel();

            model.Orcamento = _servico.ObterPorId(id);
            model.DataEmissao = model.Orcamento.Data;
            model.DataSituacao = model.Orcamento.DataSituacao;

            if (ModelState.IsValid)
            {
                try
                {
                    if (!_servico.PermissaoEditar(UsuarioId))
                    {
                        return RedirectToAction("Index", "Login");
                    }

                    model.ListaTipos = ListarTipo();

                    return View("Novo", model);
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return View("Novo", model);
            }
        }

        [HttpPost]
        public ActionResult Editar(OrcamentoEditarViewModel viewModel)
        {
            var model = new Orcamento();

            model = viewModel.Orcamento;
            model.Data = viewModel.DataEmissao;
            model.DataSituacao = viewModel.DataSituacao;

            if (ModelState.IsValid)
            {
                try
                {
                    //_servico.Salvar(model);
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
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

        public ActionResult ListarCidades(string term)
        {
            var servico = new CidadeServico();
            var cidade = servico.Listar(term);

            var result = new
            {
                results = cidade.Select(x => new
                {
                    id = x.Id.ToString(),
                    text = x.Nome
                })
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarDadosCidade(int id)
        {
            var servico = new CidadeServico();
            var cidade = servico.ObterPorId(id);

            List<Object> resultado = new List<object>();
            resultado.Add(new
            {
                UF = cidade.UF
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarDadosCliente(int id)
        {
            var servico = new ClienteServico(); 
            var clientes = servico.ObterPorId(id);

            List<Object> resultado = new List<object>();
            resultado.Add(new
            {
                Nome = clientes.Nome,
                Bairro = clientes.Bairro,
                Endereco = clientes.Endereco,
                Fantasia = clientes.Fantasia,
                Dcto = clientes.Dcto,
                IE = clientes.IE,
                IdCidade = clientes.CidadeId,
                DescCidade = clientes.Cidade.Nome,
                Cep = clientes.CEP,
                Fone1 = clientes.Fone1,
                Fone2 = clientes.Fone2,
                celular = clientes.Celular,
                OutroFone = clientes.OutroFone,
                UF = clientes.Cidade.UF,
                ContatoCompraVenda = clientes.ContatoCompraVenda,
                FoneContatoCompraVenda = clientes.FoneContatoCompraVenda,
                ContatoFinanceiro = clientes.ContatoFinanceiro,
                FoneContatoFinanceiro = clientes.FoneContatoFinanceiro,
                RepresentanteLegal = clientes.RepresentanteLegal,
                CPFRepresentanteLegal = clientes.CPFRepresentanteLegal,
                Enquadramento = clientes.Enquadramento
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //=====================================================================
        // EXEMPLOS
        //=====================================================================

        //public string DataHoraAtual()
        //{
        //    return DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        //}

        //[HttpPost]
        //public string SubmeterInscricao(string Nome, string Endereco)
        //{
        //    if (!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Endereco))
        //        //TODO: salvar dados no banco de dados
        //        return "Obrigado " + Nome + ". O dados foram Salvos.";
        //    else
        //        return "Complete a informação do formulário.";
        //}

        //public JsonResult GetDados()
        //{
        //    List<Object> resultado = new List<object>();
        //    resultado.Add(new
        //    {
        //        Nome = "Linha de Código",
        //        URL = "www.linhadecodigo.com.br"
        //    });
        //    resultado.Add(new
        //    {
        //        Nome = "DevMedia",
        //        URL = "www.devmedia.com.br"
        //    });
        //    resultado.Add(new
        //    {
        //        Nome = "Mr. Bool",
        //        URL = "www.mrbool.com.br"
        //    });
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}
    }
}