using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaVersao
    {
        private VersaoApp _versaoApp;
        public ConsultaVersao()
        {
            _versaoApp = new VersaoApp();
        }

        public VersaoViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmVersao formulario = new frmVersao(descricao);
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _versaoApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _versaoApp.ObterPorId(codigo);
                if (model == null || model.Id == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                VersaoFiltroViewModel filtro = new VersaoFiltroViewModel();
                filtro.Campo = "Ver_Versao";
                filtro.Texto = descricao;
                var model = _versaoApp.Filtrar(filtro, true);
                if (model == null)
                {
                    frmVersao formulario = new frmVersao();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _versaoApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _versaoApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmVersao formulario = new frmVersao(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _versaoApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
