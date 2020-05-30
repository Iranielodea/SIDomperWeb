using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class RamalApp
    {
        public RamalViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "ramal?novo={0}&idUsuario={1}";
            return new Operacao<RamalViewModel>().First(string.Format(url, "", idUsuario));
        }

        public RamalViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "ramal/{0}";
            return new Operacao<RamalViewModel>().First(string.Format(url, id));
        }

        public RamalViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "ramal/{0}?idUsuario={1}";
            return new Operacao<RamalViewModel>().First(string.Format(url, id, idUsuario));
        }

        public RamalConsultaViewModel[] Filtrar(string campo, string texto, bool contem = true)
        {
            string url = Constantes.URL + "ramal?campo={0}&texto={1}&contem={2}";
            return new Operacao<RamalConsultaViewModel>().GetAll(string.Format(url, campo, texto, contem));
        }

        public RamalViewModel Salvar(RamalViewModel model)
        {
            string URI = Constantes.URL + "ramal";

            if (model.Id == 0)
                return new Operacao<RamalViewModel>().Insert(URI, model);
            else
                return new Operacao<RamalViewModel>().Update(URI, model);
        }

        public RamalViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "ramal/{0}?idUsuario={1}";
            return new Operacao<RamalViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
