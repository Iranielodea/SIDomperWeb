using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class SolicitacaoApp
    {
        public SolicitacaoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "Solicitacao/Novo?idUsuario={0}";
            return new Operacao<SolicitacaoViewModel>().First(string.Format(url, idUsuario));
        }

        public SolicitacaoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "solicitacao/ObterPorId?id={0}";
            return new Operacao<SolicitacaoViewModel>().First(string.Format(url, id));
        }

        public SolicitacaoViewModel Editar(int idUsuario, int id)
        {
            string url = Constantes.URL + "Solicitacao/Editar?idUsuario={0}&id={1}";
            return new Operacao<SolicitacaoViewModel>().First(string.Format(url, idUsuario, id));
        }

        public SolicitacaoConsultaViewModel[] Filtrar(SolicitacaoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem)
        {
            string url = Constantes.URL + "solicitacao/Filtrar?campo={0}&texto={1}&usuarioId={2}&contem={3}";
            return new Operacao<SolicitacaoConsultaViewModel>().ObjetoToJSon(string.Format(url, campo, texto, usuarioId, contem), filtro);
        }

        public SolicitacaoViewModel Salvar(SolicitacaoViewModel model, int idUsuario, bool ocorrencia)
        {
            string URI = Constantes.URL + "Solicitacao?idUsuario={0}&ocorrencia={1}";

            if (model.Id == 0)
                return new Operacao<SolicitacaoViewModel>().Insert(string.Format(URI, idUsuario, ocorrencia), model);
            else
                return new Operacao<SolicitacaoViewModel>().Update(string.Format(URI, idUsuario, ocorrencia), model);
        }

        public SolicitacaoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "solicitacao/{0}?idUsuario={1}";
            return new Operacao<SolicitacaoViewModel>().Delete(string.Format(url, id, idUsuario));
        }

        public SolicitacaoViewModel BuscarModuloProduto(int idCliente, int idModulo)
        {
            string url = Constantes.URL + "Solicitacao/BuscarModuloProduto?idCliente={0}&idModulo={1}";
            return new Operacao<SolicitacaoViewModel>().First(string.Format(url, idCliente, idModulo));
        }

        //public SolicitacaoAnexoViewModel[] BuscarAnexos(int idSolicitacao, EnumSolicitacao enumSolicitacao)
        //{
        //    string url = Constantes.URL + "solicitacao/RetornarAnexos?idSolicitacao={0}&enSolicitacao={1}";
        //    return new Operacao<SolicitacaoAnexoViewModel>().GetAll(string.Format(url, idSolicitacao, enumSolicitacao));
        //}
    }
}
