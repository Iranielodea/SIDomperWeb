using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class BaseConhApp
    {
        public BaseConhViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "BaseConh?novo={0}&idUsuario={1}";
            return new Operacao<BaseConhViewModel>().First(string.Format(url, "", idUsuario));
        }

        public BaseConhViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "BaseConh/{0}";
            return new Operacao<BaseConhViewModel>().First(string.Format(url, id));
        }

        public BaseConhViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "BaseConh/{0}?idUsuario={1}";
            return new Operacao<BaseConhViewModel>().First(string.Format(url, id, idUsuario));
        }

        public BaseConhConsultaViewModel[] Filtrar(BaseConhecimentoFiltroViewModel filtro, int idUsuario, bool contem = true)
        {
            string url = Constantes.URL + "BaseConh?usuarioId={0}&contem={1}";
            return new Operacao<BaseConhConsultaViewModel>().ObjetoToJSon(string.Format(url, idUsuario, contem), filtro);
        }

        public BaseConhViewModel Salvar(BaseConhViewModel model)
        {
            string URI = Constantes.URL + "BaseConh";

            if (model.Id == 0)
                return new Operacao<BaseConhViewModel>().Insert(URI, model);
            else
                return new Operacao<BaseConhViewModel>().Update(URI, model);
        }

        public BaseConhViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "BaseConh/{0}?idUsuario={1}";
            return new Operacao<BaseConhViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
