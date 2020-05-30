using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class ProdutoServico
    {
        private readonly ProdutoEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public ProdutoServico()
        {
            _rep = new ProdutoEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Produto;
        }

        public Produto ObterPorId(int id)
        {
            var model = _rep.ObterPorId(id);
            if (model == null)
                throw new Exception("Produto não Encontrado!");

            return model;
        }

        public List<Produto> Listar(string nome)
        {
            return _rep.Listar(nome).ToList();
        }

        public Produto Novo(int idUsuario)
        {
            var model = new Produto();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Ativo = true;
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }

        public void Salvar(Produto model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            _rep.Salvar(model);
            _rep.Commit();
        }
        
        public Produto Editar(int idUsuario, int id, ref string permissaoMensagem)
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

        public IEnumerable<ProdutoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, ativo, contem);
        }

        public Produto ObterPorCodigo(int codigo)
        {
            var model = _rep.ObterPorCodigo(codigo);
            if (model == null)
                throw new Exception("Registro não Encontrado!");

            if (model.Ativo == false)
                throw new Exception("Registro Inativo!");
            return model;
        }

        public void Relatorio(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, EnProgramas.Produto, EnTipoManutencao.Imprimir);
        }
    }
}
