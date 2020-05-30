using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class StatusServico
    {
        StatusEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public StatusServico()
        {
            _rep = new StatusEF();
            _tipoPrograma = EnProgramas.Status;
            _repUsuario = new UsuarioServico();
        }

        public Status ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<Status> ListarVisitas(string nome)
        {
            return _rep.ListarVisitas(nome).ToList();
        }

        public bool NotificarSupervisor(int statusId)
        {
            var model = _rep.ObterPorId(statusId);
            return (model.NotificarSupervisor == true);
        }

        public bool NotificarConsultor(int statusId)
        {
            var model = _rep.ObterPorId(statusId);
            return (model.NotificarConsultor == true);
        }

        public bool NotificarRevenda(int statusId)
        {
            var model = _rep.ObterPorId(statusId);
            return (model.NotificarRevenda == true);
        }

        public bool NotificarCliente(int statusId)
        {
            var model = _rep.ObterPorId(statusId);
            return (model.NotificarCliente == true);
        }

        public Status ObterPorCodigo(int codigo)
        {
            return _rep.ObterPorCodigo(codigo);
        }

        public Status ObterPorCodigo(int codigo, EnStatus enStatus)
        {
            return _rep.ObterPorCodigo(codigo, enStatus);
        }

        public IEnumerable<Status> ObterPorPrograma(EnStatus enStatus)
        {
            return _rep.ListarTodos().Where(x => x.Programa == (int)enStatus);
        }

        public IEnumerable<Status> ListarTodos()
        {
            return _rep.ListarTodos().ToList();
        }

        public Status Novo(int idUsuario)
        {
            var model = new Status();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Ativo = true;
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }

        public Status Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            return _rep.ObterPorId(id);
        }

        public void Excluir(Status model, int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public void Salvar(Status model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new System.Exception("Nome é Obrigatório!");

            if (model.Codigo == 0)
                model.Codigo = _rep.ProximoCodigo();

            _rep.Salvar(model);
            _rep.Commit();
        }

        public IEnumerable<StatusConsulta> Filtrar(string campo, string texto, EnStatus enStatus, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, enStatus, ativo, contem);
        }
    }
}
