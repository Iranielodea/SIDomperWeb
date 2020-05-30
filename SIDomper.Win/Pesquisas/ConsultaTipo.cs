using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaTipo
    {
        private TipoApp _tipoApp;
        public ConsultaTipo()
        {
            _tipoApp = new TipoApp();
        }

        public TipoViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa, EnTipos enTipos)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmTipo formulario = new frmTipo("", enTipos);
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _tipoApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _tipoApp.ObterPorCodigo(codigo, enTipos);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var model = _tipoApp.Filtrar("Tip_Nome", descricao, enTipos);
                if (model == null)
                {
                    frmTipo formulario = new frmTipo(enTipos);
                    if (Tela.AbrirFormularioModal(formulario))
                        return _tipoApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _tipoApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmTipo formulario = new frmTipo(descricao, enTipos);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _tipoApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
