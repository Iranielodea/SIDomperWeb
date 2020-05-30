using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class ParametroServico
    {
        ParametroEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public ParametroServico()
        {
            _rep = new ParametroEF();
            _tipoPrograma = EnProgramas.Parametro;
            _repUsuario = new UsuarioServico();
        }

        public Parametro Novo(int idUsuario)
        {
            var model = new Parametro();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }

        public Parametro Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);
        }

        public Parametro ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Parametro ObterPorParametro(int codigo, int programa)
        {
            return _rep.ObterPorParametro(codigo, programa);
        }

        public void Salvar(Parametro model)
        {
            if (model.Codigo <= 0)
                throw new Exception("É obrigatório o código!");
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("É obrigatório o nome!");
            if (string.IsNullOrWhiteSpace(model.Valor))
                throw new Exception("É obrigatório o valor!");

            _rep.Salvar(model);
            _rep.Commit();
        }

        public IEnumerable<ParametroConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            return _rep.Filtrar(campo, texto, contem);
        }

        public void Excluir(int id, int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            var model = ObterPorId(id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public IEnumerable<Parametro> BuscarTitulosChamados()
        {
            return _rep.BuscarTitulosChamados().ToList();
        }

        public IEnumerable<Parametro> ListarTodos()
        {
            return _rep.ListarTodos();
        }
    }
}
