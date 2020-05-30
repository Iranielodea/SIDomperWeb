using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class CategoriaServico
    {
        private readonly CategoriaEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public CategoriaServico()
        {
            _rep = new CategoriaEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Categoria;
        }

        public Categoria ObterPorId(int id)
        {
            var model = _rep.ObterPorId(id);
            if (model == null)
                throw new Exception("Não há Registro!");

            return model;
        }

        public List<Categoria> Listar(string nome)
        {
            return _rep.ListarCategoria(nome).ToList();
        }

        public Categoria Novo(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new Categoria();
            model.Ativo = true;
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }

        public Categoria Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);
        }

        public void Excluir(int idUsuario, Categoria model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        public IEnumerable<CategoriaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            return _rep.Filtrar(campo, texto, ativo, contem, idCliente);
        }

        public Categoria ObterPorCodigo(int codigo)
        {
            var model = _rep.ObterPorCodigo(codigo);

            if (model == null)
                throw new Exception("Registro Não Encontrado!");

            if (model != null)
            {
                if (model.Ativo == false)
                    throw new Exception("Registro Inativo!");
            }
            return model;
        }

        public void Salvar(Categoria model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Relatorio(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, EnProgramas.Categoria, EnTipoManutencao.Imprimir);
        }
    }
}
