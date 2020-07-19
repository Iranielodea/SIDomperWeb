using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class CategoriaApp
    {
        public CategoriaViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "categoria/Novo?idUsuario={0}";
            return new Operacao<CategoriaViewModel>().First(string.Format(url, idUsuario));
        }

        public CategoriaViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "categoria/ObterPorId?id={0}";
            return new Operacao<CategoriaViewModel>().First(string.Format(url, id));
        }

        public CategoriaViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "categoria/Editar?id={0}&idUsuario={1}";
            return new Operacao<CategoriaViewModel>().First(string.Format(url, id, idUsuario));
        }

        public CategoriaViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "categoria/ObterPorCodigo?codigo={0}";
            return new Operacao<CategoriaViewModel>().First(string.Format(url, codigo));
        }

        public CategoriaViewModel[] Filtrar(string campo, string texto, string ativo = "A", int idCliente = 0, bool contem = true)
        {
            string url = Constantes.URL + "categoria/Filtrar?campo={0}&texto={1}&ativo={2}&contem={3}&idCliente={4}";
            return new Operacao<CategoriaViewModel>().GetAll(string.Format(url, campo, texto, ativo, contem, idCliente));
        }

        public CategoriaViewModel Salvar(CategoriaViewModel model)
        {
            string URI = Constantes.URL + "categoria";

            if (model.Id == 0)
                return new Operacao<CategoriaViewModel>().Insert(URI, model);
            else
                return new Operacao<CategoriaViewModel>().Update(URI, model);
        }

        public CategoriaViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "categoria/{0}?idUsuario={1}";
            return new Operacao<CategoriaViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
