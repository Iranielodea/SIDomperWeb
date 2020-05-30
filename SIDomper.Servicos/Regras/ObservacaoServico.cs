using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using SIDomper.Infra.EF.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class ObservacaoServico
    {
        private readonly ObservacaoEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public ObservacaoServico()
        {
            _rep = new ObservacaoEF();
            _tipoPrograma = EnProgramas.Observacao;
            _repUsuario = new UsuarioServico();
        }

        public Observacao ObterPorId(int id)
        {
            var model = _rep.ObterPorId(id);
            if (model == null)
                throw new Exception("Produto não Encontrado!");

            return model;
        }

        public Observacao ObterPadrao(int programa)
        {
            return _rep.ObterPadrao(programa);
        }

        public Observacao ObterEmailPadrao(int programa)
        {
            return _rep.ObterEmailPadrao(programa);
        }
        public Observacao Novo(int idUsuario)
        {
            var model = new Observacao();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Ativo = true;
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }
        public void Salvar(Observacao model)
        {
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");

            if (model.Codigo <= 0)
                throw new Exception("Informe o código!");

            if (model.Id == 0)
                model.Codigo = _rep.ProximoCodigo();

            _rep.Salvar(model);
            _rep.Commit();
        }

        public Observacao Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);
        }

        public void Excluir(int idUsuario, int id)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            var model = _rep.ObterPorId(id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public IEnumerable<ObservacaoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, ativo, contem);
        }

        public Observacao ObterPorCodigo(int codigo)
        {
            var model = _rep.ObterPorCodigo(codigo);
            if (model == null)
                throw new Exception("Registro não Encontrado!");

            if (model.Ativo == false)
                throw new Exception("Registro Inativo!");
            return model;
        }

        public Observacao ObterPadrao(int? programa)
        {
            var model = _rep.ObterObservacao();
            if (model.Ativo == false)
                throw new Exception("Registro inativo!");

            return model;
        }

        public Observacao ObterEmailPadrao(int? programa)
        {
            var model = _rep.ObterEmailPadrao(programa);
            if (model.Ativo == false)
                throw new Exception("Registro inativo!");

            return model;
        }
    }
}
