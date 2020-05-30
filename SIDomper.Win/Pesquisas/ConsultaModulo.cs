using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaModulo
    {
        private ModuloApp _moduloApp;
        public ConsultaModulo()
        {
            _moduloApp = new ModuloApp();
        }

        public ModuloViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmModulo formulario = new frmModulo("");
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _moduloApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _moduloApp.ObterPorCodigo(codigo);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var model = _moduloApp.Filtrar("Mod_Nome", descricao);
                if (model == null)
                {
                    frmModulo formulario = new frmModulo();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _moduloApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _moduloApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmModulo formulario = new frmModulo(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _moduloApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
