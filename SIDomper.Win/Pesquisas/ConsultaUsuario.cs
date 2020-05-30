using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaUsuario
    {
        private UsuarioApp _usuarioApp;
        public ConsultaUsuario()
        {
            _usuarioApp = new UsuarioApp();
        }

        public UsuarioViewModel Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmUsuario formulario = new frmUsuario("");
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _usuarioApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _usuarioApp.ObterPorCodigo(codigo);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var filtro = new UsuarioFiltroViewModel();
                filtro.Campo = "Usu_Nome";
                filtro.Texto = descricao;
                filtro.Ativo = "A";

                var model = _usuarioApp.Filtrar(filtro);
                if (model == null)
                {
                    frmUsuario formulario = new frmUsuario();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _usuarioApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _usuarioApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmUsuario formulario = new frmUsuario(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _usuarioApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
