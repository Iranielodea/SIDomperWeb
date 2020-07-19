using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class StatusApp
    {
        public StatusViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "status/Novo?idUsuario={0}";
            return new Operacao<StatusViewModel>().First(string.Format(url, idUsuario));
        }

        public StatusViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "status/ObterPorId?id={0}";
            return new Operacao<StatusViewModel>().First(string.Format(url, id));
        }

        public StatusViewModel Editar(int id, int idUsuario, EnStatus enStatus)
        {
            string url = Constantes.URL + "status/Editar?id={0}&idUsuario={1}";
            return new Operacao<StatusViewModel>().First(string.Format(url, id, idUsuario));
        }

        public StatusViewModel ObterPorCodigo(int codigo, EnStatus enStatus)
        {
            string url = Constantes.URL + "Status/ObterPorCodigoStatus?codigo={0}";
            //string url = Constantes.URL + "status/?codigo={0}";
            return new Operacao<StatusViewModel>().First(string.Format(url, codigo, (int)enStatus));
        }

        public StatusConsultaViewModel[] Filtrar(string campo, string texto, EnStatus tipo, string ativo = "A", bool contem = true)
        {
            string sContem = "0";
            if (contem)
                sContem = "1";

            //string url = "http://localhost:64735/api/status?campo=sta_nome&texto=A&enStatus=1&ativo=A&contem=1";
            string url = Constantes.URL + "status/Filtrar?campo={0}&texto={1}&enStatus={2}&ativo={3}&contem={4}";
            string resultado = string.Format(url, campo, texto, (int)tipo, ativo, sContem);
            return new Operacao<StatusConsultaViewModel>().GetAll(resultado);
        }

        public StatusViewModel Salvar(StatusViewModel model)
        {
            string URI = Constantes.URL + "status";

            if (model.Id == 0)
                return new Operacao<StatusViewModel>().Insert(URI, model);
            else
                return new Operacao<StatusViewModel>().Update(URI, model);
        }

        public StatusViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "status/{0}?idUsuario={1}";
            return new Operacao<StatusViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
