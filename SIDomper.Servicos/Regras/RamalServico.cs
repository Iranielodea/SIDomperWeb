using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class RamalServico
    {
        private readonly RamalEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public RamalServico()
        {
            _rep = new RamalEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Ramal;
        }

        public Ramal Novo(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            var model = new Ramal();
            return model;
        }

        public Ramal ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Ramal Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            return _rep.ObterPorId(id);
        }

        public IEnumerable<RamalConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            return _rep.Filtrar(campo, texto, contem);
        }

        public void Salvar(Ramal model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Departamento))
                    throw new Exception("É obrigatório a descrição!");

                if (model.Id == 0)
                    _rep.Salvar(model);
                else
                {
                    var ramal = _rep.ObterPorId(model.Id);
                    if (ramal == null)
                        ramal = new Ramal();

                    AlterarItem(ramal, model);
                    ExcluirItem(ramal, model);

                    ramal.Departamento = model.Departamento;
                    _rep.Salvar(ramal);
                }
                _rep.Commit();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AlterarItem(Ramal ramal, Ramal model)
        {
            foreach (var item in model.RamalItens)
            {
                if (item.Numero <= 0 || string.IsNullOrWhiteSpace(item.Nome))
                    throw new Exception("Informe o ramal e o nome!");

                if (item.Id == 0)
                    ramal.RamalItens.Add(item);
                else
                {
                    var temp = ramal.RamalItens.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Nome = item.Nome;
                        temp.Numero = item.Numero;
                    }
                }
            }
        }

        private void ExcluirItem(Ramal ramal, Ramal model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in ramal.RamalItens)
            {
                var dados = model.RamalItens.FirstOrDefault(x => x.Id == itemBanco.Id);
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

        public void Excluir(int idUsuario, Ramal model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }
    }
}
