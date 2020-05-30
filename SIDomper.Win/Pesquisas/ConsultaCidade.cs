﻿using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaCidade
    {
        private CidadeApp _cidadeApp;
        public ConsultaCidade()
        {
            _cidadeApp = new CidadeApp();
        }

        public CidadeViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmCidade formulario = new frmCidade("");
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _cidadeApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _cidadeApp.ObterPorCodigo(codigo);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var model = _cidadeApp.Filtrar("Cid_Nome", descricao);
                if (model == null)
                {
                    frmCidade formulario = new frmCidade();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _cidadeApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _cidadeApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmCidade formulario = new frmCidade(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _cidadeApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
