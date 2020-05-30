using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using SIDomper.Win.View;
using System;
using System.Linq;

namespace SIDomper.Win.Pesquisas
{
    public class ConsultaCliente
    {
        private ClienteApp _clienteApp;
        public ConsultaCliente()
        {
            _clienteApp = new ClienteApp();
        }

        public ClienteViewModelApi Pesquisar(int codigo, string descricao, TipoPesquisa tipoPesquisa)
        {
            if (codigo == 0 && tipoPesquisa == TipoPesquisa.Id)
                return null;

            if (string.IsNullOrEmpty(descricao) && tipoPesquisa == TipoPesquisa.Descricao)
                return null;

            if (tipoPesquisa == TipoPesquisa.Tela)
            {
                frmCliente formulario = new frmCliente("000000");
                if (Tela.AbrirFormularioModal(formulario))
                {
                    if (Funcoes.IdSelecionado == 0)
                        return null;

                    return _clienteApp.ObterPorId(Funcoes.IdSelecionado);
                }
            }

            if (tipoPesquisa == TipoPesquisa.Id && codigo > 0)
            {
                var model = _clienteApp.ObterPorCodigo(codigo);
                if (model == null || model.Codigo == 0)
                    throw new Exception("Registro não encontrado!");
                return model;
            }

            if (tipoPesquisa == TipoPesquisa.Descricao && descricao.Length > 0)
            {
                var filtro = new ClienteFiltroViewModelApi();
                filtro.Campo = "Cli_Nome";
                filtro.Valor = descricao;
                filtro.Ativo = "A";
                filtro.Restricao = 2;

                var model = _clienteApp.Filtrar(filtro, Funcoes.IdUsuario);

                if (model == null)
                {
                    frmCliente formulario = new frmCliente();
                    if (Tela.AbrirFormularioModal(formulario))
                        return _clienteApp.ObterPorId(Funcoes.IdSelecionado);
                    return null;
                }
                else
                {
                    if (model.Count() == 1)
                        return _clienteApp.ObterPorId(model.First().Id);
                    else
                    {
                        frmCliente formulario = new frmCliente(descricao);
                        if (Tela.AbrirFormularioModal(formulario))
                            return _clienteApp.ObterPorId(Funcoes.IdSelecionado);
                    }
                    return null;
                }
            }
            else
                return null;
        }
    }
}
