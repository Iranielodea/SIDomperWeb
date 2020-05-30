using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ParametroApp
    {
        public ParametroViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "parametro?novo={0}&idUsuario={1}";
            return new Operacao<ParametroViewModel>().First(string.Format(url, "A", idUsuario));
        }

        public ParametroViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "parametro/{0}";
            return new Operacao<ParametroViewModel>().First(string.Format(url, id));
        }

        public ParametroViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "parametro/{0}?idUsuario={1}";
            return new Operacao<ParametroViewModel>().First(string.Format(url, id, idUsuario));
        }

        public ParametroViewModel ObterPorParametro(int codigo, int programa)
        {
            string url = Constantes.URL + "parametro/?codigo{0}&programa={1}";
            return new Operacao<ParametroViewModel>().First(string.Format(url, codigo, programa));
        }

        public ParametroConsultaViewModel[] Filtrar(string campo, string texto, bool contem = true)
        {
            string url = Constantes.URL + "Parametro?campo={0}&texto={1}&contem={2}";
            return new Operacao<ParametroConsultaViewModel>().GetAll(string.Format(url, campo, texto, contem));
        }

        public ParametroViewModel Salvar(ParametroViewModel model)
        {
            string URI = Constantes.URL + "parametro";

            if (model.Id == 0)
                return new Operacao<ParametroViewModel>().Insert(URI, model);
            else
                return new Operacao<ParametroViewModel>().Update(URI, model);
        }

        public ParametroViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "parametro/{0}?idUsuario={1}";
            return new Operacao<ParametroViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
