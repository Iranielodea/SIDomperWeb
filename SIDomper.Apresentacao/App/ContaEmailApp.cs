using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ContaEmailApp
    {
        public ContaEmailViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "contaEmail/Novo?idUsuario={0}";
            return new Operacao<ContaEmailViewModel>().First(string.Format(url, idUsuario));
        }

        public ContaEmailViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "contaEmail/Editar?id={0}&idUsuario={1}";
            return new Operacao<ContaEmailViewModel>().First(string.Format(url, id, idUsuario));
        }

        public ContaEmailViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "contaEmail/ObterPorId?id={0}";
            return new Operacao<ContaEmailViewModel>().First(string.Format(url, id));
        }

        public ContaEmailViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "contaEmail/ObterPorCodigo?codigo={0}";
            return new Operacao<ContaEmailViewModel>().First(string.Format(url, codigo));
        }

        public ContaEmailConsultaViewModel[] Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sContem = "0";
            if (contem)
                sContem = "1";

            string url = Constantes.URL + "ContaEmail/Filtrar?campo={0}&texto={1}&ativo={2}";
            return new Operacao<ContaEmailConsultaViewModel>().GetAll(string.Format(url, campo, texto, ativo, sContem));
        }

        public ContaEmailViewModel Salvar(ContaEmailViewModel model)
        {
            string URI = Constantes.URL + "contaEmail";

            if (model.Id == 0)
                return new Operacao<ContaEmailViewModel>().Insert(URI, model);
            else
                return new Operacao<ContaEmailViewModel>().Update(URI, model);
        }

        public ContaEmailViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "contaEmail/{0}?idUsuario={1}";
            return new Operacao<ContaEmailViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
