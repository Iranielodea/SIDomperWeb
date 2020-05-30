using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class DepartamentoApp
    {
        public DepartamentoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "departamento?novo={0}&idUsuario={1}";
            return new Operacao<DepartamentoViewModel>().First(string.Format(url, "", idUsuario));
        }

        public DepartamentoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "departamento/{0}";
            return new Operacao<DepartamentoViewModel>().First(string.Format(url, id));
        }

        public DepartamentoViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "departamento/{0}?idUsuario={1}";
            return new Operacao<DepartamentoViewModel>().First(string.Format(url, id, idUsuario));
        }

        public DepartamentoViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "departamento?codigo={0}";
            return new Operacao<DepartamentoViewModel>().First(string.Format(url, codigo));
        }

        public DepartamentoConsultaViewModel[] Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string url = Constantes.URL + "Departamento?campo={0}&texto={1}&ativo={2}&contem={3}";
            return new Operacao<DepartamentoConsultaViewModel>().GetAll(string.Format(url, campo, texto, ativo, contem));
        }

        public DepartamentoViewModel Salvar(DepartamentoViewModel model)
        {
            string URI = Constantes.URL + "departamento";

            if (model.Id == 0)
                return new Operacao<DepartamentoViewModel>().Insert(URI, model);
            else
                return new Operacao<DepartamentoViewModel>().Update(URI, model);
        }

        public DepartamentoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "departamento/{0}?idUsuario={1}";
            return new Operacao<DepartamentoViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
