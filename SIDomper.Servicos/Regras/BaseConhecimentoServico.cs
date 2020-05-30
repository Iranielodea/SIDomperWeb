using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.EF;
using SIDomper.Infra.RepositorioDapper;
using System;
using System.Collections.Generic;

namespace SIDomper.Servicos.Regras
{
    public class BaseConhecimentoServico
    {
        private readonly BaseConhecimentoEF _rep;
        private readonly UsuarioServico _usuarioServico;
        private readonly EnProgramas _tipoPrograma;
        private readonly BaseConhecimentoRepositorioDapper _baseConhecimentoRepositorioDapper;

        public BaseConhecimentoServico()
        {
            _rep = new BaseConhecimentoEF();
            _usuarioServico = new UsuarioServico();
            _tipoPrograma = EnProgramas.BaseConh;
            _baseConhecimentoRepositorioDapper = new BaseConhecimentoRepositorioDapper();
        }

        public BaseConhecimento Novo(int idUsuario)
        {
            _usuarioServico.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new BaseConhecimento();
            var obsServico = new ObservacaoServico();
            var tipoServico = new TipoServico();

            model.Usuario = _usuarioServico.ObterPorId(idUsuario);
            model.UsuarioId = model.Usuario.Id;
            model.Data = DateTime.Now.Date;

            var obs = obsServico.ObterPadrao((int)EnTipos.BaseConhecimento);
            if (obs != null)
                model.Descricao = obs.Descricao;

            var modelTipo = tipoServico.RetornarUmRegistroPrograma(EnTipos.BaseConhecimento);
            if (modelTipo != null)
                model.Tipo = modelTipo;

            return model;
        }

        public IEnumerable<BaseConhConsultaViewModel> Filtrar(BaseConhecimentoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem = true)
        {
            return _baseConhecimentoRepositorioDapper.Filtrar(filtro, campo, texto, usuarioId, contem);
        }

        public BaseConhecimento ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public BaseConhecimento Editar(int id, int idUsuario, ref string permissaoMensagem)
        {
            ValidarId(id);

            bool permissao;
            var model = new BaseConhecimento();
            model = _rep.ObterPorId(id);

            var Usuario = _usuarioServico.ObterPorId(idUsuario);
            if (Usuario.Adm)
            {
                permissao = true;
                permissaoMensagem = "OK";
            }
            else
            {
                permissao = _usuarioServico.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
                if (permissao)
                    permissao = (model.UsuarioId == idUsuario);

                permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            }
            return model;


            //bool permissao = _usuarioServico.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            //permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            //ValidarId(id);
            //return ObterPorId(id);
        }

        private void ValidarId(int id)
        {
            if (id == 0)
                throw new Exception("Não há Registros!");
        }

        public void Excluir(BaseConhecimento model)
        {
            ValidarId(model.Id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public void Excluir(int idUsuario, int id)
        {
            _usuarioServico.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            var model = _rep.ObterPorId(id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public void Salvar(BaseConhecimento model)
        {
            if (Funcoes.FuncaoGeral.DataEmBranco(model.Data.ToShortDateString()))
                throw new Exception("Informe a Data!");

            if (model.UsuarioId == 0)
                throw new Exception("Informe o Consultor!");

            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");

            if (model.StatusId == 0)
                throw new Exception("Informe o Status!");

            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo!");

            _rep.Salvar(model);
            _rep.Commit();
        }
    }
}
