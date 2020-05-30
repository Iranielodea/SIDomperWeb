using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ModeloRelatorioApp
    {
        public ModeloRelatorioViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "ModeloRelatorio?novo={0}&idUsuario={1}";
            return new Operacao<ModeloRelatorioViewModel>().First(string.Format(url, "", idUsuario));
        }

        public ModeloRelatorioViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "modeloRelatorio/{0}";
            return new Operacao<ModeloRelatorioViewModel>().First(string.Format(url, id));
        }

        public ModeloRelatorioViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "modeloRelatorio/{0}?idUsuario={1}";
            return new Operacao<ModeloRelatorioViewModel>().First(string.Format(url, id, idUsuario));
        }

        public ModeloRelatorioViewModel[] Filtrar(string campo, string texto)
        {
            string url = Constantes.URL + "ModeloRelatorio?campo={0}&texto={1}";
            return new Operacao<ModeloRelatorioViewModel>().GetAll(string.Format(url, campo, texto));
        }

        public ModeloRelatorioViewModel Salvar(ModeloRelatorioViewModel model)
        {
            string URI = Constantes.URL + "modeloRelatorio";

            if (model.Id == 0)
                return new Operacao<ModeloRelatorioViewModel>().Insert(URI, model);
            else
                return new Operacao<ModeloRelatorioViewModel>().Update(URI, model);
        }

        public ModeloRelatorioViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "modeloRelatorio/{0}?idUsuario={1}";
            return new Operacao<ModeloRelatorioViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
