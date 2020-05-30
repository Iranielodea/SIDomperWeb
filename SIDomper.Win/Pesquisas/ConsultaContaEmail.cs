using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaContaEmail
    {
        private ContaEmailApp _contaEmailApp;
        public ConsultaContaEmail()
        {
            _contaEmailApp = new ContaEmailApp();
        }

        public ContaEmailViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmContaEmail formulario = new frmContaEmail("");
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _contaEmailApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _contaEmailApp.ObterPorCodigo(codigo);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var model = _contaEmailApp.Filtrar("CtaEm_Nome", descricao);
                if (model == null)
                {
                    frmContaEmail formulario = new frmContaEmail();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _contaEmailApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _contaEmailApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmContaEmail formulario = new frmContaEmail(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _contaEmailApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
