using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ObservacaoApp
    {
        public ObservacaoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "observacao/Novo?idUsuario={0}";
            return new Operacao<ObservacaoViewModel>().First(string.Format(url, idUsuario));
        }

        public ObservacaoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "observacao/ObterPorId?id={0}";
            return new Operacao<ObservacaoViewModel>().First(string.Format(url, id));
        }

        public ObservacaoViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "observacao/Editar?id={0}&idUsuario={1}";
            return new Operacao<ObservacaoViewModel>().First(string.Format(url, id, idUsuario));
        }


        public ObservacaoViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "observacao/ObterPorCodigo?codigo={0}";
            return new Operacao<ObservacaoViewModel>().First(string.Format(url, codigo));
        }

        public ObservacaoConsultaViewModel[] Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sContem = "0";
            if (contem)
                sContem = "1";

            string url = Constantes.URL + "Observacao/Filtrar?campo={0}&texto={1}&ativo={2}";
            return new Operacao<ObservacaoConsultaViewModel>().GetAll(string.Format(url, campo, texto, ativo, sContem));
        }

        public ObservacaoViewModel Salvar(ObservacaoViewModel model)
        {
            string URI = Constantes.URL + "observacao";

            if (model.Id == 0)
                return new Operacao<ObservacaoViewModel>().Insert(URI, model);
            else
                return new Operacao<ObservacaoViewModel>().Update(URI, model);
        }

        public ObservacaoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "observacao/{0}?idUsuario={1}";
            return new Operacao<ObservacaoViewModel>().Delete(string.Format(url, id, idUsuario));
        }

        public ObservacaoViewModel ObservacaoEmailPadrao(int idPrograma)
        {
            string url = Constantes.URL + "Observacao/ObservacaoEmailPadrao?idPrograma={0}";
            return new Operacao<ObservacaoViewModel>().First(string.Format(url, idPrograma));
        }

        public ObservacaoViewModel ObservacaoPadrao(int idPrograma)
        {
            string url = Constantes.URL + "Observacao/ObservacaoPadrao?idPrograma={0}";
            return new Operacao<ObservacaoViewModel>().First(string.Format(url, idPrograma));
        }
    }
}
