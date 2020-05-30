using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;
using System.Linq;

namespace SIDomper.Apresentacao.App
{
    public class VisitaApp
    {
        public VisitaViewModelApi Novo(int idUsuario, int idClienteAgendamento, int idAgendamento)
        {
            string url = Constantes.URL + "visita?novo={0}&idUsuario={1}&idClienteAgendamento={2}&idAgendamento={3}";
            return new Operacao<VisitaViewModelApi>().First(string.Format(url, "", idUsuario, idClienteAgendamento, idAgendamento));
        }

        public VisitaViewModelApi ObterPorId(int id)
        {
            string url = Constantes.URL + "visita/{0}";
            return new Operacao<VisitaViewModelApi>().First(string.Format(url, id));
        }

        public VisitaViewModelApi Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "visita/{0}?idUsuario={1}";
            return new Operacao<VisitaViewModelApi>().First(string.Format(url, id, idUsuario));
        }

        public VisitaViewModelApi Salvar(VisitaViewModelApi model, int idUsuario)
        {
            string URI = Constantes.URL + "Visita?idUsuario={0}";

            if (model.Id == 0)
                return new Operacao<VisitaViewModelApi>().Insert(string.Format(URI,idUsuario), model);
            else
                return new Operacao<VisitaViewModelApi>().Update(string.Format(URI, idUsuario), model);
        }

        public VisitaViewModelApi Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "visita/{0}?idUsuario={1}";
            return new Operacao<VisitaViewModelApi>().Delete(string.Format(url, id, idUsuario));
        }

        public VisitaConsultaViewModelApi[] Filtrar(VisitaFiltroViewModelApi filtro, int idUsuario, string campo, string valor)
        {
            string url = Constantes.URL + "visita?idUsuario={0}&campo={1}&valor={2}";
            return new Operacao<VisitaConsultaViewModelApi>().ObjetoToJSon(string.Format(url, idUsuario, campo, valor), filtro);
        }

        public VisitaViewModelApi EnviarEmail(VisitaViewModelApi model, int idUsuario)
        {
            //api / Visita?idUsuario={idUsuario}&email={ email}
            string URI = Constantes.URL + "Visita?idUsuario={0}&email{1}";
            return new Operacao<VisitaViewModelApi>().ObjetoToJSon(string.Format(URI, idUsuario,""), model).First();
        }
    }
}
