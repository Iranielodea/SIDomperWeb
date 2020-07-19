using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class CidadeApp
    {
        public CidadeViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "cidade/Novo?idUsuario={0}";
            return new Operacao<CidadeViewModel>().First(string.Format(url, idUsuario));
        }

        public CidadeViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "cidade/ObterPorId?id={0}";
            return new Operacao<CidadeViewModel>().First(string.Format(url, id));
        }

        public CidadeViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "cidade/Editar?id={0}&idUsuario={1}";
            return new Operacao<CidadeViewModel>().First(string.Format(url, id, idUsuario));
        }

        public CidadeViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "cidade/ObterPorCodigo?codigo={0}";
            return new Operacao<CidadeViewModel>().First(string.Format(url, codigo));
        }

        public CidadeViewModel[] Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string url = Constantes.URL + "Cidade/Filtrar?campo={0}&texto={1}&ativo={2}";
            return new Operacao<CidadeViewModel>().GetAll(string.Format(url, campo, texto, ativo, contem));
        }

        public CidadeViewModel Salvar(CidadeViewModel model)
        {
            string URI = Constantes.URL + "cidade";

            if (model.Id == 0)
                return new Operacao<CidadeViewModel>().Insert(URI, model);
            else
                return new Operacao<CidadeViewModel>().Update(URI, model);
        }

        public CidadeViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "cidade/{0}?idUsuario={1}";
            return new Operacao<CidadeViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
