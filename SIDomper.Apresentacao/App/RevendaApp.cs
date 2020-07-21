using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class RevendaApp
    {
        public RevendaViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "revenda/Novo?idUsuario={0}";
            return new Operacao<RevendaViewModel>().First(string.Format(url, idUsuario));
        }

        public RevendaViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "revenda/ObterPorId?id={0}";
            return new Operacao<RevendaViewModel>().First(string.Format(url, id));
        }

        public RevendaViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "revenda/Editar?id={0}&idUsuario={1}";
            return new Operacao<RevendaViewModel>().First(string.Format(url, id, idUsuario));
        }

        public RevendaViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "revenda/ObterPorCodigo?codigo={0}";
            return new Operacao<RevendaViewModel>().First(string.Format(url, codigo));
        }

        public RevendaConsultaViewModel[] Filtrar(string campo, string texto, string ativo = "A")
        {
            string url = Constantes.URL + "Revenda/Filtrar?campo={0}&texto={1}&ativo={2}";
            return new Operacao<RevendaConsultaViewModel>().GetAll(string.Format(url, campo, texto, ativo));
        }

        public RevendaViewModel Salvar(RevendaViewModel model)
        {
            string URI = Constantes.URL + "revenda";

            if (model.Id == 0)
                return new Operacao<RevendaViewModel>().Insert(URI, model);
            else
                return new Operacao<RevendaViewModel>().Update(URI, model);
        }

        public RevendaViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "revenda/{0}?idUsuario={1}";
            return new Operacao<RevendaViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
