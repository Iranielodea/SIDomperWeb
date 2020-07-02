using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class RevendaServico
    {
        private readonly RevendaEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public RevendaServico()
        {
            _rep = new RevendaEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Revenda;
        }

        public Revenda Novo(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new Revenda();
            model.Codigo = _rep.ProximoCodigo();
            model.Ativo = true;

            return model;
        }

        public Revenda Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            return _rep.ObterPorId(id);
        }

        public IEnumerable<RevendaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, ativo, contem);
        }

        public Revenda ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Revenda ObterPorCodigo(int codigo, bool valida = true)
        {
            var model = _rep.ObterPorCodigo(codigo);

            if (model != null)
            {
                if (valida)
                {
                    if (model.Ativo == false)
                        throw new System.Exception("Registro Inativo!");
                }
            }
            return model;
        }

        public List<Revenda> Listar(string nome)
        {
            return _rep.ListarRevenda(nome).ToList();
        }

        public void Salvar(Revenda model)
        {
            try
            {
                if (model.Codigo <= 0)
                    throw new Exception("É obrigatório o código!");
                if (string.IsNullOrEmpty(model.Nome))
                    throw new Exception("É obrigatório o nome!");

                foreach (var item in model.RevendaEmails)
                {
                    if (string.IsNullOrEmpty(item.Email))
                        throw new Exception("É obrigatório o email!");
                }

                if (model.Id == 0)
                    _rep.Salvar(model);
                else
                {
                    var revenda = _rep.ObterPorId(model.Id);
                    if (revenda == null)
                        revenda = new Revenda();

                    AlterarEmail(revenda, model);
                    ExcluirEmail(revenda, model);

                    revenda.Codigo = model.Codigo;
                    revenda.Nome = model.Nome;
                    revenda.Ativo = model.Ativo;

                    _rep.Salvar(revenda);
                }
                _rep.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RetornarEmails(Revenda model)
        {
            string email = "";
            foreach (var item in model.RevendaEmails)
            {
                if (email == "")
                    email = item.Email;
                else
                    email = email + ";" + item.Email;
            }
            return email;
        }

        public void Excluir(int idUsuario, Revenda model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        private void AlterarEmail(Revenda revenda, Revenda model)
        {
            foreach (var item in model.RevendaEmails)
            {
                if (string.IsNullOrWhiteSpace(item.Email))
                    throw new Exception("Informe o email!");

                if (item.Id == 0)
                    revenda.RevendaEmails.Add(item);
                else
                {
                    var rev = revenda.RevendaEmails.FirstOrDefault(x => x.Id == item.Id);
                    if (rev != null)
                    {
                        rev.Email = item.Email;
                    }
                }
            }
        }

        private void ExcluirEmail(Revenda revenda, Revenda model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in revenda.RevendaEmails)
            {
                var dados = model.RevendaEmails.FirstOrDefault(x => x.Id == itemBanco.Id);
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

        public void Commit()
        {
            _rep.Commit();
        }

        public void Relatorio(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, EnProgramas.Revenda, EnTipoManutencao.Imprimir);
        }
    }
}
