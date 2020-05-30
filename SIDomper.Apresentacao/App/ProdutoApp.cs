using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ProdutoApp
    {
        public ProdutoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "produto?novo={0}&idUsuario={1}";
            return new Operacao<ProdutoViewModel>().First(string.Format(url, "", idUsuario));
        }

        public ProdutoViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "produto/{0}?idUsuario={1}";
            return new Operacao<ProdutoViewModel>().First(string.Format(url, id, idUsuario));
        }

        public ProdutoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "produto/{0}";
            return new Operacao<ProdutoViewModel>().First(string.Format(url, id));
        }

        public ProdutoViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "produto/?codigo={0}";
            return new Operacao<ProdutoViewModel>().First(string.Format(url, codigo));
        }

        public ProdutoViewModel[] Filtrar(string campo, string texto, string ativo = "A")
        {
            string url = Constantes.URL + "Produto?campo={0}&texto={1}&ativo={2}";
            return new Operacao<ProdutoViewModel>().GetAll(string.Format(url, campo, texto, ativo));
        }

        public ProdutoViewModel Salvar(ProdutoViewModel model)
        {
            string URI = Constantes.URL + "produto";

            if (model.Id == 0)
                return new Operacao<ProdutoViewModel>().Insert(URI, model);
            else
                return new Operacao<ProdutoViewModel>().Update(URI, model);
        }

        public ProdutoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "produto/{0}?idUsuario={1}";
            return new Operacao<ProdutoViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
