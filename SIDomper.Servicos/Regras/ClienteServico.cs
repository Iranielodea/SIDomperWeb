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

namespace SIDomper.Servicos.Regras
{
    public class ClienteServico
    {
        private readonly UsuarioServico _usuario;
        private readonly ClienteADO _repADO;
        private readonly ClienteEF  _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly ClienteRepositorioDapper _repositorioConsulta;

        public ClienteServico()
        {
            _usuario = new UsuarioServico();
            _repADO = new ClienteADO();
            _rep = new ClienteEF();
            _tipoPrograma = EnProgramas.Cliente;
            _repositorioConsulta = new ClienteRepositorioDapper();
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

        public Cliente ObterPorCodigo(int codigo)
        {
            try
            {
                var model = _rep.ObterPorCodigo(codigo);

                if (model != null)
                {
                    if (model.Ativo == false)
                        throw new Exception("Registro Inativo!");
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

                if (item.Id == 0)

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
    }
}
