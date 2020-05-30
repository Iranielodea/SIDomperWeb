using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;

namespace SIDomper.Servicos.Regras
{
    public class ModeloRelatorioServico
    {
        private readonly ModeloRelatorioEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public ModeloRelatorioServico()
        {
            _rep = new ModeloRelatorioEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.ModeloRelatorio;
        }

        public ModeloRelatorio ObterPorId(int id)
        {
            var model = _rep.ObterPorId(id);
            if (model == null)
                throw new Exception("Modelo de relatório não encontrado!");

            return model;
        }

        public ModeloRelatorio Novo(int idUsuario)
        {
            var model = new ModeloRelatorio();
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
            model.Codigo = _rep.ProximoCodigo();

            return model;
        }

        public void Salvar(ModeloRelatorio model)
        {
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe o Nome!");

            if (string.IsNullOrWhiteSpace(model.Arquivo))
                throw new Exception("Informe o arquivo!");

            if (model.Id == 0)
                model.Codigo = _rep.ProximoCodigo();

            _rep.Salvar(model);
            _rep.Commit();
        }

        public ModeloRelatorio Editar(int idUsuario, int id)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            if (!permissao)
                throw new Exception("Usuário sem Permissão!");

            return _rep.ObterPorId(id);
        }

        public void Excluir(int idUsuario, int id)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);
            var model = _rep.ObterPorId(id);
            _rep.Excluir(model);
            _rep.Commit();
        }

        public IEnumerable<ModeloRelatorioConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            return _rep.Filtrar(campo, texto, contem);
        }

        public ModeloRelatorio ObterPorCodigo(int codigo)
        {
            var model = _rep.ObterPorCodigo(codigo);
            if (model == null)
                throw new Exception("Registro não Encontrado!");

            return model;
        }
       
        public void Relatorio(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, EnProgramas.ModeloRelatorio, EnTipoManutencao.Imprimir);
        }
    }
}
