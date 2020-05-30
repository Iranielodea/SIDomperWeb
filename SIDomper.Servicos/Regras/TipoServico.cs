using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System.Collections.Generic;
using System.Linq;
using SIDomper.Dominio.Enumeracao;
using System;

namespace SIDomper.Servicos.Regras
{
    public class TipoServico
    {
        TipoEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public TipoServico()
        {
            _rep = new TipoEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Tipo;
        }

        public Tipo ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Tipo Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            return _rep.ObterPorId(id);
        }

        public Tipo Novo(int idUsuario)
        {
            var model = new Tipo();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Ativo = true;
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }

        public Tipo ObterPorCodigo(int codigo)
        {
            var model = _rep.ObterPorCodigo(codigo);
            if (model == null)
                throw new Exception("Registro não Encontrado!");

            if (model.Ativo == false)
                throw new Exception("Registro Inativo!");
            return model;
        }

        public Tipo ObterPorCodigo(int codigo, EnTipos enTipos)
        {
            var model = _rep.ObterPorCodigo(codigo, enTipos);
            if (model == null)
                throw new Exception("Registro não Encontrado!");

            if (model.Ativo == false)
                throw new Exception("Registro Inativo!");
            return model;
        }

        public IEnumerable<TipoConsulta> Filtrar(string campo, string texto, EnTipos enTipos, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, enTipos, ativo, contem);
        }

        public void Excluir(int idUsuario, int id)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            var model = _rep.ObterPorId(id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public void Salvar(Tipo model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            _rep.Salvar(model);
            _rep.Commit();
        }

        public List<Tipo> ListarVisitas(string nome)
        {
            return _rep.ListarTipos(nome, EnTipos.Visita).ToList();
        }

        public List<Tipo> ListarOrcamentos(string nome)
        {
            return _rep.ListarTipos(nome, EnTipos.Orcamento).ToList();
        }

        public Tipo RetornarUmRegistro(EnumChamado enumChamado)
        {
            var model = new Tipo();
            if (enumChamado == EnumChamado.Chamado)
                model = _rep.RetornarUmRegistro(EnTipos.Chamado);
            else 
                model = _rep.RetornarUmRegistro(EnTipos.Atividade);

            return model;
        }

        public Tipo RetornarUmRegistroPrograma(EnTipos enTipos)
        {

            return _rep.RetornarUmRegistro(enTipos);
        }

        public List<Tipo> ListarTipos(string nome, EnTipos enTipos)
        {
            return _rep.ListarTipos(nome, enTipos).ToList();
        }
    }
}
