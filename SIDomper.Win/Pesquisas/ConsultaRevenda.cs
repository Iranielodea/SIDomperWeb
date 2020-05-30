using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaRevenda
    {
        private RevendaApp _revendaApp;
        public ConsultaRevenda()
        {
            _revendaApp = new RevendaApp();
        }

        public RevendaViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmRevenda formulario = new frmRevenda("");
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _revendaApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _revendaApp.ObterPorCodigo(codigo);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var model = _revendaApp.Filtrar("Rev_Nome", descricao);
                if (model == null)
                {
                    frmRevenda formulario = new frmRevenda();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _revendaApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _revendaApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmRevenda formulario = new frmRevenda(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _revendaApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
