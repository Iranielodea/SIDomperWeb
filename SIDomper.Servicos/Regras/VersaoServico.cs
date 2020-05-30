using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.EF;
using SIDomper.Infra.RepositorioDapper;
using System;
using System.Collections.Generic;

namespace SIDomper.Servicos.Regras
{
    public class VersaoServico
    {
        private readonly VersaoEF _rep;
        private readonly TipoServico _tipoServico;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;
        private readonly ObservacaoServico _observacaoServico;
        private readonly ParametroServico _parametroServico;
        private readonly VersaoRepositorioDapper _versaoRepositorioDapper;

        public VersaoServico()
        {
            _rep = new VersaoEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Versao;
            _tipoServico = new TipoServico();
            _observacaoServico = new ObservacaoServico();
            _parametroServico = new ParametroServico();
            _versaoRepositorioDapper = new VersaoRepositorioDapper();
        }

        public Versao ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Versao Novo(int idUsuario)
        {
            var model = new Versao();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            // buscar usuario padrao
            model.Usuario = _repUsuario.ObterPorId(idUsuario);

            // observacao padrao
            var observacao = _observacaoServico.ObterPadrao((int)EnProgramas.Versao);
            if (observacao != null)
                model.Descricao = observacao.Descricao;

            // buscar tipo
            model.Tipo = _tipoServico.RetornarUmRegistroPrograma(EnTipos.Versao);

            return model;
        }

        public Parametro ObterStatusDesenvolvedor()
        {
            return  _parametroServico.ObterPorParametro(48, 0);
        }

        public Versao Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao;
            var model = new Versao();
            model = _rep.ObterPorId(id);

            var Usuario = _repUsuario.ObterPorId(idUsuario);
            if (Usuario.Adm)
            {
                permissao = true;
                permissaoMensagem = "OK";
            }
            else
            {
                permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
                if (permissao)
                    permissao = (model.UsuarioId == idUsuario);

                permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            }
            return model;

            //bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            //permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            //return _rep.ObterPorId(id);
        }

        public IEnumerable<VersaoConsultaViewModel> Filtrar(VersaoFiltroViewModel filtro, string campo, string texto, bool contem)
        {
            return _versaoRepositorioDapper.Filtrar(filtro, campo, texto, contem);
        }

        public void Salvar(Versao model)
        {
            try
            {
                if (Funcoes.FuncaoGeral.DataEmBranco(model.DataInicio.ToString()))
                    throw new Exception("Informe a Data Início");
                if (Funcoes.FuncaoGeral.DataEmBranco(model.DataLiberacao.ToString()))
                    throw new Exception("Informe a Data Liberação");

                if (model.TipoId == 0)
                    throw new Exception("Informe o Tipo!");
                if (model.StatusId == 0)
                    throw new Exception("Informe o Status!");
                if (string.IsNullOrWhiteSpace(model.Descricao))
                    throw new Exception("Informe a Descrição!");

                if (model.DataInicio > model.DataLiberacao)
                    throw new Exception("Data de Início maior que Data de Liberação!");

                _rep.Salvar(model);
                _rep.Commit();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int idUsuario, int id)
        {
            try
            {
                _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
                var model = _rep.ObterPorId(id);
                _rep.Excluir(model);
                _rep.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
