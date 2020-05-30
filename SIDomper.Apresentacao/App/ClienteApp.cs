using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ClienteApp
    {
        public ClienteViewModelApi Novo(int idCliente)
        {
            string url = Constantes.URL + "cliente?novo={0}&idCliente={1}";
            return new Operacao<ClienteViewModelApi>().First(string.Format(url, "", idCliente));
        }

        public ClienteViewModelApi ObterPorId(int id, int idCliente)
        {
            string url = Constantes.URL + "cliente/{0}?idCliente={1}";
            return new Operacao<ClienteViewModelApi>().First(string.Format(url, id, idCliente));
        }

        public ClienteViewModelApi ObterPorId(int id)
        {
            string url = Constantes.URL + "cliente/{0}";
            return new Operacao<ClienteViewModelApi>().First(string.Format(url, id));
        }

        public ClienteViewModelApi Editar(int idUsuario, int idCliente)
        {
            string url = Constantes.URL + "cliente?idUsuario={0}&idCliente={1}";
            //Cliente?idUsuario={idUsuario}&idCliente={idCliente}
            return new Operacao<ClienteViewModelApi>().First(string.Format(url, idUsuario, idCliente));
        }

        public ClienteViewModelApi ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "cliente/?codigo={0}";
            return new Operacao<ClienteViewModelApi>().First(string.Format(url, codigo));
        }

        public ClienteViewModelApi Salvar(ClienteViewModelApi model)
        {
            string URI = Constantes.URL + "cliente";

            if (model.Id == 0)
                return new Operacao<ClienteViewModelApi>().Insert(URI, model);
            else
                return new Operacao<ClienteViewModelApi>().Update(URI, model);
        }

        public ClienteViewModelApi Excluir(int id, int idCliente)
        {
            string url = Constantes.URL + "cliente/{0}?idCliente={1}";
            return new Operacao<ClienteViewModelApi>().Delete(string.Format(url, id, idCliente));
        }

        public ClienteConsultaViewModelApi[] Filtrar(ClienteFiltroViewModelApi filtro, int idUsuario, bool contem = true)
        {
            string url = Constantes.URL + "cliente?idUsuario={0}&contem={1}";
            return new Operacao<ClienteConsultaViewModelApi>().ObjetoToJSon(string.Format(url, idUsuario, contem), filtro);
        }
    }
}
