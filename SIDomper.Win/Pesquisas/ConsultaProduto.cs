using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaProduto
    {
        private ProdutoApp _produtoApp;
        public ConsultaProduto()
        {
            _produtoApp = new ProdutoApp();
        }

        public ProdutoViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmProduto formulario = new frmProduto("");
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _produtoApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _produtoApp.ObterPorCodigo(codigo);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var model = _produtoApp.Filtrar("Prod_Nome", descricao);
                if (model == null)
                {
                    frmProduto formulario = new frmProduto();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _produtoApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _produtoApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmProduto formulario = new frmProduto(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _produtoApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
