using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Funcoes;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ClienteConsultaViewModelApi> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoCliente(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ClienteConsultaViewModelApi> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Cliente;
        }

        public Cliente Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Cliente model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioCliente.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ClienteConsultaViewModelApi> Filtrar(int idUsuario, ClienteFiltroViewModelApi filtro, int modelo, string campo, string valor, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + valor + "%'";
            if (contem)
                sTexto = "'%" + valor + "%'";

            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Cli_Codigo as Codigo");
            sb.AppendLine(",Cli_Perfil as Perfil");
            sb.AppendLine(",Cli_Versao as Versao");
            sb.AppendLine(",Cli_Id as Id");
            sb.AppendLine(",cli_Fantasia as Fantasia");
            sb.AppendLine(",cli_Nome as Razao");
            sb.AppendLine(",cli_Dcto as Documento");
            sb.AppendLine(",Cli_Fone1 as Telefone");
            sb.AppendLine(",Cli_Enquadramento as Enquadramento");
            sb.AppendLine(",Usu_Nome as NomeConsultor, Rev_Nome");
            sb.AppendLine(",Rev_Nome as NomeRevenda");
            sb.AppendLine(" FROM Cliente");
            sb.AppendLine(" INNER JOIN Revenda ON Cli_Revenda = Rev_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Cli_Usuario = Usu_Id");
            sb.AppendLine(" WHERE Cli_Id IS NOT NULL");
            sb.AppendLine(" AND " + campo + " LIKE " + sTexto);

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            if (filtro.Ativo != "T")
            {
                if (filtro.Ativo == "A")
                    sb.AppendLine(" AND Cli_Ativo = 1");
                else
                    sb.AppendLine(" AND Cli_Ativo = 0");
            }

            if (filtro.UsuarioId > 0)
                sb.AppendLine("  AND Cli_Usuario =" + filtro.UsuarioId);

            if (filtro.RevendaId > 0)
                sb.AppendLine("  AND Cli_Revenda =" + filtro.RevendaId);

            if (!string.IsNullOrEmpty(filtro.FiltroIdUsuario))
                sb.AppendLine("  AND Cli_Usuario in (" + filtro.FiltroIdUsuario + ")");

            if (filtro.Restricao < 2)
            {
                if (filtro.Restricao == 0)
                    sb.AppendLine("  AND Cli_Restricao = 1");

                if (filtro.Restricao == 1)
                    sb.AppendLine("  AND Cli_Restricao = 0");
            }

            if (filtro.Id > 0)
                sb.AppendLine("  AND Cli_Id =" + filtro.Id);

            if (!string.IsNullOrWhiteSpace(filtro.Enquadramento))
                sb.AppendLine("  AND Cli_Enquadramento = '" + filtro.Enquadramento + "'");

            if (filtro.CidadeId > 0)
                sb.AppendLine("  AND Cli_Cidade =" + filtro.CidadeId);

            if (!string.IsNullOrEmpty(filtro.FiltroIdCidade))
                sb.AppendLine("  AND Cli_Cidade in (" + filtro.FiltroIdCidade + ")");

            if (!string.IsNullOrWhiteSpace(filtro.Versao))
                sb.AppendLine("  AND Cli_Versao = '" + filtro.Versao + "'");

            if (filtro.EmpresaVinculada == "S")
                sb.AppendLine("  AND Cli_EmpresaVinculada > 0");

            if (filtro.EmpresaVinculada == "N")
                sb.AppendLine(" AND ((Cli_EmpresaVinculada = 0) OR (Cli_EmpresaVinculada IS NULL))");

            if (!string.IsNullOrWhiteSpace(filtro.Perfil))
                sb.AppendLine(" AND Cli_Perfil = '" + filtro.Perfil + "'");

            if (modelo == 2)
            {
                if (filtro.ModuloId > 0)
                    sb.AppendLine(" AND CliMod_Modulo = " + filtro.ModuloId);

                if (!string.IsNullOrEmpty(filtro.filtroIdModulo))
                    sb.AppendLine("  AND CliMod_Modulo in (" + filtro.filtroIdModulo + ")");

                if (filtro.ProdutoId > 0)
                    sb.AppendLine(" AND CliMod_Produto = " + filtro.ProdutoId);

                if (!string.IsNullOrEmpty(filtro.FiltroIdProduto))
                    sb.AppendLine("  AND CliMod_Produto in (" + filtro.FiltroIdProduto + ")");
            }
            else
            {
                if (filtro.ModuloId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Modulo = " + filtro.ModuloId + ")");
                }

                if (!string.IsNullOrEmpty(filtro.filtroIdModulo))
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Modulo IN (" + filtro.filtroIdModulo + "))");
                }

                if (filtro.ProdutoId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Produto = " + filtro.ProdutoId + ")");
                }

                if (!string.IsNullOrEmpty(filtro.FiltroIdProduto))
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Produto in (" + filtro.FiltroIdProduto + "))");
                }
            }
            sb.AppendLine(" ORDER BY " + campo);
            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public bool ImportarXml(string arquivo)
        {
            var listaErros = new List<string>();

            try
            {
                if (!File.Exists(arquivo))
                    throw new Exception(arquivo + " não encontrado!");

                FileInfo fileInfo = new FileInfo(arquivo);
                string arquivoXml = fileInfo.Name;
                string diretorio = fileInfo.DirectoryName;

                int posicao = arquivoXml.IndexOf(".");
                string arquivoLog = arquivoXml + ".log";

                if (File.Exists(diretorio + arquivoLog))
                    throw new Exception(diretorio + arquivo + " não encontrado!");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(arquivo);

                var cliente = new Cliente();

                XmlNodeList xmlNodePrincipalList = xmlDoc.SelectNodes("Cliente/Principal");
                foreach (XmlNode xNode in xmlNodePrincipalList)
                {
                    string documento = RetornarXMLStr(xNode, "CNPJ");
                    if (string.IsNullOrEmpty(documento))
                        documento = RetornarXMLStr(xNode, "CPF");

                    string enquadramento = RetornarXMLStr(xNode, "Enquadramento");

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
                    _uow.SaveChanges();
                    return true;
                }
                else
                {
                    GravarErrosLog(listaErros, cliente.Codigo);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GravarErrosLog(List<string> listaErros, int codigoCliente)
        {
            string nomeArquivo = codigoCliente.ToString() + ".log";
            StreamWriter gravar = new StreamWriter(nomeArquivo);
            try
            {
                foreach (var item in listaErros)
                {
                    gravar.WriteLine(item);
                }
            }
            finally
            {
                gravar.Close();
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
            var revenda = _uow.RepositorioRevenda.First(x => x.Codigo == cliente.Revenda.Codigo);
            var usuario = _uow.RepositorioUsuario.First(x => x.Codigo == cliente.Usuario.Codigo);
            var model = _uow.RepositorioCliente.First(x => x.Codigo == cliente.Codigo);

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
                var cidade = _uow.RepositorioCidade.First(x => x.Codigo == cliente.Cidade.Codigo);
                if (cidade != null)
                {
                    _uow.RepositorioCidade.Salvar(cidade);
                    cidadeId = cidade.Id;
                }
            }

            if (cidadeId > 0)
                model.CidadeId = cidadeId;

            if (model != null)
            {
                _uow.Executar($"DELETE FROM Cliente_Email WHERE CliEm_Cliente = {model.Id}");
                _uow.Executar($"DELETE FROM Cliente_Modulo WHERE CliMod_Cliente = {model.Id}");
                _uow.Executar($"DELETE FROM Contato WHERE Cont_Cliente = {model.Id}");
            }
            //EMAILS
            SalvarEmailCliente(cliente, model);

            //MODULOS
            SalvarClienteModuloDoCliente(cliente, model);

            // CONTATOS
            SalvarContatosCliente(cliente, model);

            Salvar(model);
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

        private void GravarCidade(Cidade cidade)
        {
            var model = _uow.RepositorioCidade.First(x => x.Codigo ==  cidade.Codigo);

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
                _uow.RepositorioCidade.Salvar(model);
        }

        private void GravarProduto(Cliente cliente)
        {
            if (cliente.ClienteModulos == null)
                return;

            foreach (var item in cliente.ClienteModulos)
            {
                var model = _uow.RepositorioProduto.First(x => x.Codigo == item.Produto.Codigo);
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
                    _uow.RepositorioProduto.Salvar(model);
                    item.ProdutoId = model.Id;
                    item.Produto.Id = model.Id;
                }
            }
        }

        private void GravarModulo(Cliente cliente)
        {
            if (cliente.ClienteModulos == null)
                return;

            foreach (var item in cliente.ClienteModulos)
            {
                var model = _uow.RepositorioModulo.First(x => x.Codigo == item.Modulo.Codigo);
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
                    _uow.RepositorioModulo.Salvar(model);
                    item.ModuloId = model.Id;
                    item.Modulo.Id = model.Id;
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
                var usuario = _uow.RepositorioUsuario.First(x => x.Codigo == cliente.Usuario.Codigo);
                if (usuario == null)
                    listaErros.Add("Usuário não cadastrado.");
            }

            if (cliente.Revenda.Codigo == 0)
                listaErros.Add("Revenda não informada");
            else
            {
                var revenda = _uow.RepositorioRevenda.First(x => x.Codigo == cliente.Revenda.Codigo);
                if (revenda == null)
                    listaErros.Add("Revenda não cadastrada.");
            }

            string docto = Utils.SomenteNumero(cliente.Dcto);
            bool docValido;

            if (docto.Length == 11)
                docValido = Validacoes.IsCpf(docto);
            else
                docValido = Validacoes.IsCnpj(docto);

            if (!docValido)
                listaErros.Add("CNPJ/CPF inválido.");

            return listaErros;
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

        public ClienteLoginViewModel Login(string cnpj)
        {
            string documento = Utils.SomenteNumero(cnpj);

            string novoCnpj;
            if (documento.Length == 11)
                novoCnpj = Utils.FormatarCPF(cnpj);
            else
                novoCnpj = Utils.FormatarCNPJ(cnpj);

            var clienteLogin = new ClienteLoginViewModel();

            clienteLogin.CNPJ = cnpj;
            clienteLogin.Resultado = "OK";

            var model = _uow.RepositorioCliente.First(x => x.Dcto == novoCnpj);
            if (model == null)
            {
                clienteLogin.Resultado = "Cliente não Cadastrado!";
                return clienteLogin;
            }
            if (model.Ativo == false)
                clienteLogin.Resultado = "Cliente não está Ativo!";

            return clienteLogin;
        }

        public Cliente Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var cliente = new Cliente();
            cliente.Codigo = ProximoCodigo();
            cliente.Ativo = true;
            return cliente;
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioCliente.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public Cliente ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioCliente.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Cliente não Cadastrado!");
            return model;
        }

        public Cliente ObterPorId(int id)
        {
            return _uow.RepositorioCliente.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Cliente model)
        {
            try
            {
                if (model.Codigo <= 0)
                    _uow.Notificacao.Add("Informe o Código!");

                if (string.IsNullOrWhiteSpace(model.Nome))
                    _uow.Notificacao.Add("Informe o Nome!");

                if (model.RevendaId <= 0)
                    _uow.Notificacao.Add("Informe a Revenda!");

                if (string.IsNullOrWhiteSpace(model.Dcto))
                    _uow.Notificacao.Add("Informe o CNPJ/CPF!");

                // validar cnpj ou cpf
                string sDocumento = Utils.SomenteNumero(model.Dcto);

                if (sDocumento.Length == 14)
                {
                    if (!Validacoes.IsCnpj(model.Dcto))
                        _uow.Notificacao.Add("CNPJ/CPF inválido!");
                }
                else
                {
                    if (sDocumento.Length > 0)
                    {
                        if (!Validacoes.IsCpf(model.Dcto))
                            _uow.Notificacao.Add("CNPJ/CPF inválido!");
                    }
                }

                if (!_uow.IsValid())
                    throw new Exception(_uow.RetornoNotificacao());

                if (model.Id == 0)
                    _uow.RepositorioCliente.Salvar(model);
                else
                {
                    var cliente = _uow.RepositorioCliente.find(model.Id);
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

                    _uow.RepositorioCliente.Salvar(cliente);
                }
                _uow.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                _uow.Executar("DELETE FROM Cliente_Modulo WHERE CliMod_Id in (" + idDelecao + ")");
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
                _uow.Executar("DELETE FROM Cliente_Email WHERE CliEm_Id in (" + idDelecao + ")");
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
                _uow.Executar("DELETE FROM Contato WHERE Cont_Id in (" + idDelecao + ")");
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
    }
}
