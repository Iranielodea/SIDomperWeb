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
    public class FeriadoServico
    {
        private readonly FeriadoEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public FeriadoServico()
        {
            _rep = new FeriadoEF();
            _tipoPrograma = EnProgramas.Feriado;
            _repUsuario = new UsuarioServico();
        }

        public Produto Novo(int idUsuario)
        {
            var model = new Produto();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Ativo = true;

            return model;
        }

        public Feriado ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Feriado Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);
        }

        public IEnumerable<Feriado> Filtrar(string campo, string texto)
        {
            return _rep.Filtrar(campo, texto);
        }

        public void Salvar(Feriado model)
        {
            if (string.IsNullOrEmpty(model.Descricao))
                throw new Exception("É obrigatório a descrição!");

            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Excluir(Feriado model, int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            var feridado = _rep.ObterPorId(model.Id);
            _rep.Excluir(feridado);
            _rep.Commit();
        }

        public IEnumerable<Feriado> Listar()
        {
            return _rep.Listar();
        }
    }
}
