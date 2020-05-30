using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class FeriadoApp
    {
        public FeriadoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "feriado?novo={0}&idUsuario={1}";
            return new Operacao<FeriadoViewModel>().First(string.Format(url, "", idUsuario));
        }

        public FeriadoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "feriado/{0}";
            return new Operacao<FeriadoViewModel>().First(string.Format(url, id));
        }

        public FeriadoViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "feriado/{0}?idUsuario={1}";
            return new Operacao<FeriadoViewModel>().First(string.Format(url, id, idUsuario));
        }

        public FeriadoViewModel[] Filtrar(string campo, string texto)
        {
            string url = Constantes.URL + "Feriado?campo={0}&texto={1}";
            return new Operacao<FeriadoViewModel>().GetAll(string.Format(url, campo, texto));
        }

        public FeriadoViewModel Salvar(FeriadoViewModel model)
        {
            string URI = Constantes.URL + "feriado";

            if (model.Id == 0)
                return new Operacao<FeriadoViewModel>().Insert(URI, model);
            else
                return new Operacao<FeriadoViewModel>().Update(URI, model);
        }

        public FeriadoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "feriado/{0}?idUsuario={1}";
            return new Operacao<FeriadoViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
