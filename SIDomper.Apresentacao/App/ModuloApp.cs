using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ModuloApp
    {
        public ModuloViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "modulo/Novo?idUsuario={0}";
            return new Operacao<ModuloViewModel>().First(string.Format(url, idUsuario));
        }

        public ModuloViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "modulo/ObterPorId?Id={0}";
            return new Operacao<ModuloViewModel>().First(string.Format(url, id));
        }

        public ModuloViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "modulo/Editar?id={0}&idUsuario={1}";
            return new Operacao<ModuloViewModel>().First(string.Format(url, id, idUsuario));
        }

        public ModuloViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "modulo/ObterPorCodigo?codigo={0}";
            return new Operacao<ModuloViewModel>().First(string.Format(url, codigo));
        }

        public ModuloViewModel[] Filtrar(string campo, string texto, string ativo = "A", int idCliente = 0, bool contem = true)
        {
            string url = Constantes.URL + "modulo/Filtrar?campo={0}&texto={1}&ativo={2}&contem={3}&idCliente={4}";
            return new Operacao<ModuloViewModel>().GetAll(string.Format(url, campo, texto, ativo, contem, idCliente));
        }

        public ModuloViewModel Salvar(ModuloViewModel model)
        {
            string URI = Constantes.URL + "modulo";

            if (model.Id == 0)
                return new Operacao<ModuloViewModel>().Insert(URI, model);
            else
                return new Operacao<ModuloViewModel>().Update(URI, model);
        }

        public ModuloViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "Modulo/{0}?idUsuario={1}";
            return new Operacao<ModuloViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
