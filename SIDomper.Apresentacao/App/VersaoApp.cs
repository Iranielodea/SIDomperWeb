using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class VersaoApp
    {
        public VersaoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "versao/Novo?idUsuario={0}";
            return new Operacao<VersaoViewModel>().First(string.Format(url, idUsuario));
        }

        public VersaoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "versao/ObterPorId?id={0}";
            return new Operacao<VersaoViewModel>().First(string.Format(url, id));
        }

        public VersaoViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "versao/Editar?id={0}&idUsuario={1}";
            return new Operacao<VersaoViewModel>().First(string.Format(url, id, idUsuario));
        }

        public VersaoViewModel Salvar(VersaoViewModel model)
        {
            string URI = Constantes.URL + "versao";

            if (model.Id == 0)
                return new Operacao<VersaoViewModel>().Insert(URI, model);
            else
                return new Operacao<VersaoViewModel>().Update(URI, model);
        }

        public VersaoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "versao/{0}?idUsuario={1}";
            return new Operacao<VersaoViewModel>().Delete(string.Format(url, id, idUsuario));
        }

        public VersaoConsultaViewModel[] Filtrar(VersaoFiltroViewModel filtro, bool contem)
        {
            string url = Constantes.URL + "versao/Filtrar?contem={0}";
            return new Operacao<VersaoConsultaViewModel>().ObjetoToJSon(string.Format(url, contem), filtro);
        }
    }
}
