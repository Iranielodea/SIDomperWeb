using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class RecadoApp
    {
        public RecadoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "recado/novo?idUsuario={0}";
            return new Operacao<RecadoViewModel>().First(string.Format(url, idUsuario));
        }

        public RecadoViewModel Editar(int idUsuario, int id)
        {
            string url = Constantes.URL + "recado/editar?idUsuario={0}&id={1}";
            return new Operacao<RecadoViewModel>().First(string.Format(url, idUsuario, id));
        }

        public RecadoConsultaViewModel[] Filtrar(RecadoFiltroViewModel filtro)
        {
            string url = Constantes.URL + "recado/Filtrar";
            return new Operacao<RecadoConsultaViewModel>().ObjetoToJSon(url, filtro);
        }

        public RecadoViewModel Salvar(RecadoViewModel model)
        {
            string URI = Constantes.URL + "recado";

            if (model.Id == 0)
                return new Operacao<RecadoViewModel>().Insert(URI, model);
            else
                return new Operacao<RecadoViewModel>().Update(URI, model);
        }

        public RecadoViewModel Excluir(int idUsuario, int id)
        {
            string url = Constantes.URL + "recado/Excluir?idUsuario={0}&Id={1}";
            return new Operacao<RecadoViewModel>().Delete(string.Format(url, idUsuario, id));
        }
    }
}
