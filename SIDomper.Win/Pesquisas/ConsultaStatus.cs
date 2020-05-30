using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaStatus
    {
        private StatusApp _statusApp;
        public ConsultaStatus()
        {
            _statusApp = new StatusApp();
        }

        public StatusViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa, EnStatus enStatus)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmStatus formulario = new frmStatus("", enStatus);
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _statusApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _statusApp.ObterPorCodigo(codigo, enStatus);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var model = _statusApp.Filtrar("Sta_Nome", descricao, enStatus);
                if (model == null)
                {
                    frmStatus formulario = new frmStatus(enStatus);
                    if (Tela.AbrirFormularioModal(formulario))
                        return _statusApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _statusApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmStatus formulario = new frmStatus(descricao, enStatus);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _statusApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
