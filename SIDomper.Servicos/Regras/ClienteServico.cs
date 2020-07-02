using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.ADO;
using System.Collections.Generic;
using SIDomper.Infra.EF;
using SIDomper.Dominio.Enumeracao;
using System;
using System.Linq;
using SIDomper.Infra.RepositorioDapper;
using SIDomper.Dominio.ViewModel;
using System.IO;
using System.Xml;

namespace SIDomper.Servicos.Regras
{
    public class ClienteServico
    {
        private readonly UsuarioServico _usuario;
        private readonly ClienteADO _repADO;
        private readonly ClienteEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly ClienteRepositorioDapper _repositorioConsulta;
        private readonly RevendaServico _revendaServico;
        private readonly ClienteEmailEF _repClienteEmail;
        private readonly ClienteModuloEF _repClienteModulo;
        private readonly ContatoServico _contatoServico;

        public ClienteServico()
        {
            _usuario = new UsuarioServico();
            _repADO = new ClienteADO();
            _rep = new ClienteEF();
            _tipoPrograma = EnProgramas.Cliente;
            _repositorioConsulta = new ClienteRepositorioDapper();
            _revendaServico = new RevendaServico();
            _repClienteEmail = new ClienteEmailEF();
            _repClienteModulo = new ClienteModuloEF();
            _contatoServico = new ContatoServico();
        }

        public Cliente ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Cliente Novo(int idUsuario)
        {
            // Novo via API
            var model = new Cliente();
            _usuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Ativo = true;
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }

        public Cliente ObterPorCodigo(int codigo, bool valida = true)
        {
            try
            {
                var model = _rep.ObterPorCodigo(codigo);

                if (model != null)
                {
                    if (valida)
                    {
                        if (model.Ativo == false)
                            throw new Exception("Registro Inativo!");
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente Editar(int idUsuario, int id, ref bool permissao)
        {
            permissao = _usuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            return _rep.ObterPorId(id);
        }

        public Cliente Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            // Editar via API
            bool permissao = _usuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            return _rep.ObterPorId(id);
        }

        public void SalvarAPI(Cliente model)
        {
            //Salvar via API

            try
            {
                if (model.Codigo <= 0)
                    throw new Exception("Informe o Código!");

                if (string.IsNullOrWhiteSpace(model.Nome))
                    throw new Exception("Informe o Nome!");

                if (model.RevendaId <= 0)
                    throw new Exception("Informe a Revenda!");

                if (string.IsNullOrWhiteSpace(model.Dcto))
                    throw new Exception("Informe o CNPJ/CPF!");

                // validar cnpj ou cpf
                string sDocumento = Funcoes.FuncaoGeral.SomenteNumero(model.Dcto);

                if (sDocumento.Length == 14)
                {
                    if (!Funcoes.Validacao.IsCnpj(model.Dcto))
                        throw new Exception("CNPJ/CPF inválido!");
                }
                else
                {
                    if (sDocumento.Length > 0)
                    {
                        if (!Funcoes.Validacao.IsCpf(model.Dcto))
                            throw new Exception("CNPJ/CPF inválido!");
                    }
                }

                if (model.Id == 0)
                    _rep.SalvarAPI(model);
                else
                {
                    var cliente = _rep.ObterPorId(model.Id);
                    if (cliente == null)
                        cliente = new Cliente();

                    //int id = cliente.Id;
                    //cliente = model;
                    //cliente.Id = id;

                    cliente.IE = model.IE;
                    cliente.Latitude = model.Latitude;
                    cliente.Logradouro = model.Logradouro;
                    cliente.Longitude = model.Longitude;
                    cliente.Nome = model.Nome;
                    cliente.OutroFone = model.OutroFone;
                    cliente.Perfil = model.Perfil;
                    cliente.RepresentanteLegal = model.RepresentanteLegal;
                    cliente.Restricao = model.Restricao;
                    cliente.RevendaId = model.RevendaId;
                    cliente.Telefone = model.Telefone;
                    cliente.UsuarioId = model.UsuarioId;
                    cliente.Versao = model.Versao;
                    cliente.Ativo = model.Ativo;
                    cliente.Bairro = model.Bairro;
                    cliente.Celular = model.Celular;
                    cliente.CEP = model.CEP;
                    cliente.CidadeId = model.CidadeId;
                    cliente.Codigo = model.Codigo;
                    cliente.Contato = model.Contato;
                    cliente.ContatoCompraVenda = model.ContatoCompraVenda;
                    cliente.ContatoFinanceiro = model.ContatoFinanceiro;
                    cliente.CPFRepresentanteLegal = model.CPFRepresentanteLegal;
                    cliente.Dcto = model.Dcto;
                    cliente.EmpresaVinculada = model.EmpresaVinculada;
                    cliente.Endereco = model.Endereco;
                    cliente.Enquadramento = model.Enquadramento;
                    cliente.Fantasia = model.Fantasia;
                    cliente.Fone1 = model.Fone1;
                    cliente.Fone2 = model.Fone2;
                    cliente.FoneContatoCompraVenda = model.FoneContatoCompraVenda;
                    cliente.FoneContatoFinanceiro = model.FoneContatoFinanceiro;

                    SalvarContato(cliente, model);
                    ExcluirContato(cliente, model);

                    SalvarEmail(cliente, model);
                    ExcluirEmail(cliente, model);

                    SalvarModulos(cliente, model);
                    ExcluirModulos(cliente, model);

                    _rep.SalvarAPI(cliente);
                }
                _rep.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SalvarContato(Cliente cliente, Cliente model)
        {
            foreach (var item in model.Contatos)
            {
                if (string.IsNullOrWhiteSpace(item.Nome))
                    throw new Exception("Informe o nome!");

                if (item.Id == 0)
                    cliente.Contatos.Add(item);
                else
                {
                    var temp = cliente.Contatos.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Email = item.Email;
                        temp.Fone1 = item.Fone1;
                        temp.Fone2 = item.Fone2;
                        temp.Nome = item.Nome;
                        temp.Departamento = item.Departamento;
                    }
                }
            }
        }

        private void SalvarEmail(Cliente cliente, Cliente model)
        {
            foreach (var item in model.Emails)
            {
                if (string.IsNullOrWhiteSpace(item.Email))
                    throw new Exception("Informe o email!");

                if (item.Id == 0)
                    cliente.Emails.Add(item);
                else
                {
                    var temp = cliente.Emails.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Email = item.Email;
                        temp.Notificar = item.Notificar;
                        temp.ClienteId = cliente.Id;
                    }
                }
            }
        }

        private void SalvarModulos(Cliente cliente, Cliente model)
        {
            foreach (var item in model.ClienteModulos)
            {
                if (item.ModuloId == 0)
                    throw new Exception("Informe o Módulo!");

                if (item.Id <= 0)

                    cliente.ClienteModulos.Add(item);
                else
                {
                    var temp = cliente.ClienteModulos.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.ModuloId = item.ModuloId;
                        temp.ProdutoId = item.ProdutoId;
                        temp.ClienteId = cliente.Id;
                    }
                }
            }
        }

        private void ExcluirContato(Cliente cliente, Cliente model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in cliente.Contatos)
            {
                var dados = model.Contatos.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _rep.ExcluirItem(idDelecao);
        }

        private void ExcluirEmail(Cliente cliente, Cliente model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in cliente.Emails)
            {
                var dados = model.Emails.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _rep.ExcluirEmail(idDelecao);
        }

        private void ExcluirModulos(Cliente cliente, Cliente model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in cliente.ClienteModulos)
            {
                var dados = model.ClienteModulos.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _rep.ExcluirModulos(idDelecao);
        }

        public void Excluir(int idUsuario, int id)
        {
            // Excluir via API
            try
            {
                _usuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
                var model = _rep.ObterPorId(id);
                _rep.Excluir(model);
                _rep.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int idUsuario, Cliente model)
        {
            _usuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        public bool PermissaoAcesso(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Cliente, EnTipoManutencao.Acessar);
        }

        public bool PermissaoIncluir(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Cliente, EnTipoManutencao.Incluir);
        }

        public bool PermissaoEditar(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Cliente, EnTipoManutencao.Editar);
        }

        public bool PermissaoExcluir(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Cliente, EnTipoManutencao.Excluir);
        }

        public bool PermissaoRelatorio(int idUsuario)
        {
            return _usuario.PermissaoUsuario(idUsuario, EnProgramas.Cliente, EnTipoManutencao.Imprimir);
        }

        public IEnumerable<ClienteConsultaViewModelApi> Filtrar(int idUsuario, ClienteFiltroViewModelApi filtro, int modelo, string campo, string valor, bool contem = true)
        {
            return _repositorioConsulta.Filtrar(idUsuario, filtro, modelo, campo, valor, contem);
        }

        public IEnumerable<ClienteConsulta> FiltrarWeb(int idUsuario, ClienteFiltro filtro, int modelo, string campo, string valor, bool contem = true)
        {
            return _rep.Filtrar(idUsuario, filtro, modelo, campo, valor, contem);
        }

        public List<Cliente> Listar(int idUsuario, string nome)
        {
            return _repADO.Listar(idUsuario, nome);
        }

        public void Salvar(Cliente model)
        {
            _rep.Salvar(model);
        }

        public void AtualizarVersao(int idCliente, string versao)
        {
            _rep.AtualizarVersao(idCliente, versao);
        }

        public string EmailsDoCliente(Cliente cliente)
        {
            if (cliente.Emails == null)
                return "";

            string email = "";
            foreach (var item in cliente.Emails)
            {
                if (item.Notificar)
                {
                    if (email == "")
                        email = email + item.Email;
                    else
                        email = email + ";" + item.Email;
                }
            }
            return email;
        }

        public void AdicionarEmail(ClienteEmail model)
        {
            _rep.AdicionarEmail(model);
        }

        public void AlterarEmail(Cliente model, ClienteEmail email)
        {
            if (string.IsNullOrWhiteSpace(email.Email))
                throw new Exception("Informe o email!");

            _rep.AlterarEmail(model, email);
        }

        public void ExcluirEmail(int id)
        {
            if (id > 0)
                _rep.ExcluirEmail(id);
        }

        public void AdicionarModulo(ClienteModulo model)
        {
            _rep.AdicionarModulo(model);
        }

        public void AlterarModulo(Cliente model, ClienteModulo modulo)
        {
            _rep.AlterarModulo(model, modulo);
        }

        public void ExcluirModulo(int id)
        {
            _rep.ExcluirModulo(id);
        }

        public List<string> ImportarXml(string arquivo)
        {
            var listaErros = new List<string>();

            try
            {
                if (!File.Exists(arquivo))
                    return listaErros;

                FileInfo fileInfo = new FileInfo(arquivo);
                string arquivoXml = fileInfo.Name;
                string diretorio = fileInfo.DirectoryName;

                int posicao = arquivoXml.IndexOf(".");
                string arquivoLog = arquivoXml + ".log";

                if (File.Exists(diretorio + arquivoLog))
                    return listaErros;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(arquivo);

                var cliente = new Cliente();

                XmlNodeList xmlNodePrincipalList = xmlDoc.SelectNodes("Cliente/Principal");
                foreach (XmlNode xNode in xmlNodePrincipalList)
                {
                    string documento = RetornarXMLStr(xNode, "CNPJ");
                    if (string.IsNullOrEmpty(documento))
                        documento = RetornarXMLStr(xNode, "CPF");

                    string enquadramento = RetornarXMLStr(xNode,"Enquadramento");

                    if (enquadramento != "01" && enquadramento != "02" && enquadramento != "03")
                        enquadramento = "00";

                    int.TryParse(RetornarXMLStr(xNode, "Empresa_Vinculada"), out int codigoEmpresaVinculada);

                    if (cliente.Cidade == null)
                        cliente.Cidade = new Cidade();

                    if (cliente.Revenda == null)
                        cliente.Revenda = new Revenda();

                    if (cliente.Usuario == null)
                        cliente.Usuario = new Usuario();

                    cliente.Codigo = RetornarXMLInt(xNode, "Codigo");
                    cliente.Nome = RetornarXMLStr(xNode, "Razao");
                    cliente.Fantasia = RetornarXMLStr(xNode, "Fantasia");
                    cliente.Dcto = documento;
                    cliente.Enquadramento = enquadramento;
                    cliente.Endereco = RetornarXMLStr(xNode, "Rua");
                    cliente.Bairro = RetornarXMLStr(xNode, "Bairro");
                    cliente.CEP = RetornarXMLStr(xNode, "CEP");
                    cliente.Revenda.Codigo = RetornarXMLInt(xNode, "Revenda");
                    //cliente.Telefone = xNode["Fone1"].InnerText;
                    cliente.ContatoFinanceiro = RetornarXMLStr(xNode, "Contato_Financeiro");

                    cliente.ContatoCompraVenda = RetornarXMLStr(xNode, "Contato_Compra_Venda");
                    cliente.Usuario.Codigo = RetornarXMLInt(xNode, "Consultor");
                    cliente.Restricao = RetornarXMLStr(xNode, "Pendencia_Fin") == "S";
                    cliente.Ativo = RetornarXMLStr(xNode, "Situacao") == "A";
                    cliente.Logradouro = cliente.Endereco;
                    cliente.Fone1 = RetornarXMLStr(xNode, "Fone1");
                    cliente.Fone2 = RetornarXMLStr(xNode, "Fone2");
                    cliente.Celular = RetornarXMLStr(xNode, "Celular");
                    cliente.OutroFone = RetornarXMLStr(xNode, "OutroFone");
                    cliente.FoneContatoFinanceiro = RetornarXMLStr(xNode, "Contato_Financeiro_Fone");
                    cliente.FoneContatoCompraVenda = RetornarXMLStr(xNode, "Contato_Compra_Venda_Fone");
                    cliente.IE = RetornarXMLStr(xNode, "IE");
                    cliente.RepresentanteLegal = RetornarXMLStr(xNode, "Representante_Legal");
                    cliente.CPFRepresentanteLegal = RetornarXMLStr(xNode, "Representante_Legal_CPF");
                    cliente.EmpresaVinculada = RetornarXMLInt(xNode, "Empresa_Vinculada");
                    cliente.Perfil = RetornarXMLStr(xNode, "Perfil");

                    // CIDADE
                    cliente.Cidade.Codigo = RetornarXMLInt(xNode, "Codigo_IBGE");
                    cliente.Cidade.Nome = RetornarXMLStr(xNode, "Nome_Cidade");
                    cliente.Cidade.UF = RetornarXMLStr(xNode, "UF");
                    cliente.Ativo = true;
                }

                // EMAIL
                ImportarXMLEmail(cliente, xmlDoc);

                // MODULOS E PRODUTOS
                ImportarXMLModulo(cliente, xmlDoc);

                // CONTATOS
                ImportarXMLContato(cliente, xmlDoc);

                listaErros = ValidarCliente(cliente);
                if (listaErros.Count == 0)
                {
                    GravarDadosXML(cliente);
                }
                else
                {
                    // gera arquivos logs (nome do arquivo com o codigo.log)
                }

                return listaErros;
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                return listaErros;
            }
        }

        private void GravarDadosXML(Cliente cliente)
        {
            GravarModulo(cliente);
            GravarProduto(cliente);
            GravarCidade(cliente.Cidade);
            GravarClienteII(cliente);
        }

        private void GravarClienteII(Cliente cliente)
        {
            var revendaServico = new RevendaServico();
            var revenda = revendaServico.ObterPorCodigo(cliente.Revenda.Codigo, false);

            var usuarioServico = new UsuarioServico();
            var usuario = usuarioServico.ObterPorCodigo(cliente.Usuario.Codigo, false);

            var clienteServico = new ClienteServico();
            var model = clienteServico.ObterPorCodigo(cliente.Codigo, false);

            if (model != null)
            {
                int id = model.Id;
                model = cliente;
                model.Id = id;
            }
            else
            {
                model = new Cliente();
                model = cliente;
            }

            if (revenda != null)
                model.RevendaId = revenda.Id;
            if (usuario != null)
                model.UsuarioId = usuario.Id;

            int cidadeId = 0;

            if (cliente.Cidade.Codigo > 0)
            {
                var cidadeServico = new CidadeServico();
                var cidade = cidadeServico.ObterPorCodigo(cliente.Cidade.Codigo, false);
                if (cidade != null)
                {
                    cidadeServico.Salvar(cidade);
                    cidadeId = cidade.Id;
                }
            }

            if (cidadeId > 0)
                model.CidadeId = cidadeId;

            if (model != null)
            {
                _repClienteEmail.ExcluirPorCliente(model.Id);
                _repClienteModulo.ExcluirPorCliente(model.Id);
                _contatoServico.ExcluirPorCliente(model.Id);
            }
            //EMAILS
            SalvarEmailCliente(cliente, model);

            //MODULOS
            SalvarClienteModuloDoCliente(cliente, model);

            // CONTATOS
            SalvarContatosCliente(cliente, model);

            SalvarAPI(model);
        }

        private void SalvarContatosCliente(Cliente cliente, Cliente model)
        {
            var listaContatos = new List<Contato>();
            foreach (var item in cliente.Contatos)
            {
                listaContatos.Add(item);
            }

            model.Contatos.Clear();
            foreach (var item in listaContatos)
            {
                item.Id = 0;
                item.ClienteId = model.Id;
                model.Contatos.Add(item);
            }
        }

        private void SalvarClienteModuloDoCliente(Cliente cliente, Cliente model)
        {
            var listaModulos = new List<ClienteModulo>();
            foreach (var item in cliente.ClienteModulos)
            {
                listaModulos.Add(item);
            }

            model.ClienteModulos.Clear();
            foreach (var item in listaModulos)
            {
                var temp = new ClienteModulo();
                temp.ClienteId = model.Id;
                temp.ModuloId = item.ModuloId;
                temp.ProdutoId = item.ProdutoId;
                model.ClienteModulos.Add(temp);
            }
        }

        private void SalvarEmailCliente(Cliente cliente, Cliente model)
        {
            var listaEmail = new List<ClienteEmail>();
            foreach (var email in cliente.Emails)
            {
                listaEmail.Add(email);
            }

            model.Emails.Clear();
            foreach (var item in listaEmail)
            {
                item.Id = 0;
                item.ClienteId = model.Id;
                model.Emails.Add(item);
            }
        }

        private void GravarModulo(Cliente cliente)
        {
            if (cliente.ClienteModulos == null)
                return;

            var moduloServico = new ModuloServico();
            var model = new Modulo();
            foreach (var item in cliente.ClienteModulos)
            {
                model = moduloServico.ObterPorCodigo(item.Modulo.Codigo, false);
                if (model == null)
                {
                    model = new Modulo();
                    model.Id = item.Id;
                    model.Ativo = true;
                    model.Nome = item.Modulo.Nome;
                    model.Codigo = item.Modulo.Codigo;
                    
                };
                if (model.Codigo > 0)
                {
                    moduloServico.Salvar(model);
                    item.ModuloId = model.Id;
                    item.Modulo.Id = model.Id;
                }
            }
        }

        private void GravarProduto(Cliente cliente)
        {
            if (cliente.ClienteModulos == null)
                return;

            var produtoServico = new ProdutoServico();
            var model = new Produto();
            foreach (var item in cliente.ClienteModulos)
            {
                model = produtoServico.ObterPorCodigo(item.Produto.Codigo, false);
                if (model == null)
                {
                    model = new Produto();
                    model.Id = item.Id;
                    model.Ativo = true;
                    model.Nome = item.Produto.Nome;
                    model.Codigo = item.Produto.Codigo;
                };
                if (model.Codigo > 0)
                {
                    produtoServico.Salvar(model);
                    item.ProdutoId = model.Id;
                    item.Produto.Id = model.Id;
                }
            }
        }

        private void GravarCidade(Cidade cidade)
        {
            var cidadeServico = new CidadeServico();
            var model = cidadeServico.ObterPorCodigo(cidade.Codigo, false);

            if (model == null)
            {
                model = new Cidade();
                model = cidade;
            }
            else
            {
                model.Codigo = cidade.Codigo;
                model.Ativo = cidade.Ativo;
                model.Nome = cidade.Nome;
                model.UF = cidade.UF;
            }

            if (model.Codigo > 0)
                cidadeServico.Salvar(model);
        }

        private string RetornarXMLStr(XmlNode xNode, string nomeTag)
        {
            try
            {
                return xNode[nomeTag].InnerText;
            }
            catch
            {
                return "";
            }
        }

        private int RetornarXMLInt(XmlNode xNode, string nomeTag)
        {
            try
            {
                int.TryParse(RetornarXMLStr(xNode, nomeTag), out int codigo);
                return codigo;
            }
            catch
            {
                return 0;
            }
        }

        private void ImportarXMLEmail(Cliente cliente, XmlDocument xmlDoc)
        {
            string email = "";
            int contador = 0;
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("Cliente/Registro_EMail");
            string nomeTag;
            foreach (XmlNode xNode in xmlNodeList)
            {
                while (1 == 1)
                {
                    try
                    {
                        if (contador == 0)
                            email = RetornarXMLStr(xNode, "Email");
                        else
                        {
                            nomeTag = "Email" + contador;
                            email = RetornarXMLStr(xNode, nomeTag);
                        }

                        if (contador > 0 && string.IsNullOrEmpty(email))
                            break;

                        if (contador > 150)
                            break;

                        contador++;
                        if (!string.IsNullOrEmpty(email))
                        {
                            var emailCliente = new ClienteEmail
                            {
                                Id = 0,
                                ClienteId = cliente.Id,
                                Email = email,
                                Notificar = true
                            };
                            cliente.Emails.Add(emailCliente);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private void ImportarXMLModulo(Cliente cliente, XmlDocument xmlDoc)
        {
            int contador = 1;
            int codModulo;
            int codProduto;
            XmlNodeList xmlNodeModuloList = xmlDoc.SelectNodes("Cliente/Registro_Modulo");
            foreach (XmlNode xNode in xmlNodeModuloList)
            {
                while (1 == 1)
                {
                    try
                    {
                        codModulo = RetornarXMLInt(xNode, "Cod_Grupo" + contador);
                        codProduto = RetornarXMLInt(xNode, "Cod_Produto" + contador);

                        if (contador > 0 && codModulo == 0)
                            break;

                        if (contador > 150)
                            break;

                        if (codModulo > 0)
                        {
                            var clienteModulo = new ClienteModulo();
                            if (clienteModulo.Modulo == null)
                                clienteModulo.Modulo = new Modulo();
                            if (clienteModulo.Produto == null)
                                clienteModulo.Produto = new Produto();

                            clienteModulo.Modulo.Codigo = codModulo;
                            clienteModulo.Produto.Codigo = codProduto;
                            clienteModulo.Modulo.Nome = RetornarXMLStr(xNode, "Nome_Grupo" + contador);
                            clienteModulo.Produto.Nome = RetornarXMLStr(xNode, "Nome_Produto" + contador);
                            cliente.ClienteModulos.Add(clienteModulo);
                        }
                        contador++;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private void ImportarXMLContato(Cliente cliente, XmlDocument xmlDoc)
        {
            int contador = 1;
            string nome;
            XmlNodeList xmlNodeModuloList = xmlDoc.SelectNodes("Cliente/Registro_Contato");
            foreach (XmlNode xNode in xmlNodeModuloList)
            {
                while (1 == 1)
                {
                    try
                    {
                        nome = RetornarXMLStr(xNode, "Contato_Nome" + contador);

                        if (string.IsNullOrWhiteSpace(nome))
                            break;

                        if (contador > 150)
                            break;

                        if (!string.IsNullOrWhiteSpace(nome))
                        {
                            var contato = new Contato
                            {
                                ClienteId = cliente.Id,
                                Nome = RetornarXMLStr(xNode, "Contato_Nome" + contador),
                                Fone1 = RetornarXMLStr(xNode, "Contato_Fone1" + contador),
                                Fone2 = RetornarXMLStr(xNode, "Contato_Fone2" + contador),
                                Departamento = RetornarXMLStr(xNode, "Contato_Depto" + contador),
                                Email = RetornarXMLStr(xNode, "Contato_Email" + contador)
                            };

                            cliente.Contatos.Add(contato);
                        }
                        contador++;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private List<string> ValidarCliente(Cliente cliente)
        {
            var listaErros = new List<string>();
            if (cliente.Codigo == 0)
                listaErros.Add("Código Cliente não Informado.");
            if (string.IsNullOrEmpty(cliente.Nome))
                listaErros.Add("Razão Social não informado.");
            if (string.IsNullOrEmpty(cliente.Dcto))
                listaErros.Add("CNPJ/CPF não informado.");

            if (cliente.Usuario.Codigo > 0)
            {
                var usuario = _usuario.ObterPorCodigo(cliente.Usuario.Codigo);
                if (usuario == null)
                    listaErros.Add("Usuário não cadastrado.");
            }

            if (cliente.Revenda.Codigo == 0)
                listaErros.Add("Revenda não informada");
            else
            {
                var revenda = _revendaServico.ObterPorCodigo(cliente.Revenda.Codigo);
                if (revenda == null)
                    listaErros.Add("Revenda não cadastrada.");
            }

            string docto = Funcoes.FuncaoGeral.SomenteNumero(cliente.Dcto);
            bool docValido;
            if (docto.Length == 11)
                docValido = Funcoes.Validacao.IsCpf(docto);
            else
                docValido = Funcoes.Validacao.IsCnpj(docto);
            if (!docValido)
                listaErros.Add("CNPJ/CPF inválido.");

            return listaErros;
        }
    }
}
