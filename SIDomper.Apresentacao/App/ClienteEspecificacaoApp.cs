using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ClienteEspecificacaoApp
    {
        public ClienteEspecificacaoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "clienteEspecificacao?novo={0}&idUsuario={1}";
            return new Operacao<ClienteEspecificacaoViewModel>().First(string.Format(url, "", idUsuario));
        }

        public ClienteEspecificacaoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "clienteEspecificacao/{0}";
            return new Operacao<ClienteEspecificacaoViewModel>().First(string.Format(url, id));
        }

        public ClienteEspecificacaoViewModel[] Filtrar(int idCliente)
        {
            string url = Constantes.URL + "ClienteEspecificacao?idCliente={0}";
            return new Operacao<ClienteEspecificacaoViewModel>().GetAll(string.Format(url, idCliente));
        }

        public ClienteEspecificacaoViewModel Salvar(ClienteEspecificacaoViewModel model)
        {
            string URI = Constantes.URL + "clienteEspecificacao";

            if (model.Id == 0)
                return new Operacao<ClienteEspecificacaoViewModel>().Insert(URI, model);
            else
                return new Operacao<ClienteEspecificacaoViewModel>().Update(URI, model);
        }

        public ClienteEspecificacaoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "clienteEspecificacao/{0}?idUsuario={1}";
            return new Operacao<ClienteEspecificacaoViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
