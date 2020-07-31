using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class AgendamentoApp
    {
        public AgendamentoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "agendamento/Novo?idUsuario={0}";
            return new Operacao<AgendamentoViewModel>().First(string.Format(url, idUsuario));
        }

        public AgendamentoViewModel Editar(int idUsuario, int id)
        {
            string url = Constantes.URL + "agendamento/Editar?idUsuario={0}&id={1}";
            return new Operacao<AgendamentoViewModel>().First(string.Format(url, idUsuario, id));
        }

        public AgendamentoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "agendamento/ObterPorId?id={0}";
            return new Operacao<AgendamentoViewModel>().First(string.Format(url, id));
        }

        public AgendamentoConsultaViewModel[] Filtrar(AgendamentoFiltroViewModel filtro, string campo, string texto, int idUsuario, bool contem = true)
        {
            string url = Constantes.URL + "Agendamento/Filtrar?campo={0}&texto={1}&idUsuario={2}&contem={3}";
            return new Operacao<AgendamentoConsultaViewModel>().ObjetoToJSon(string.Format(url, campo, texto, idUsuario, contem), filtro);
        }

        public AgendamentoViewModel Salvar(AgendamentoViewModel model, int usuarioId)
        {
            if (model.Id == 0)
            {
                string URI = Constantes.URL + "agendamento/Incluir?usuarioId={0}";
                return new Operacao<AgendamentoViewModel>().Insert(string.Format(URI, usuarioId), model);
            }
            else
            {
                string URI = Constantes.URL + "agendamento/Alterar?usuarioId={0}";
                return new Operacao<AgendamentoViewModel>().Update(string.Format(URI, usuarioId), model);
            }

        }

        public AgendamentoViewModel Excluir(int idUsuario, int id)
        {
            string url = Constantes.URL + "agendamento/{0}?idUsuario={1}";
            return new Operacao<AgendamentoViewModel>().Delete(string.Format(url, idUsuario, id));
        }

        public AgendamentoViewModel Reagendamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            string url = Constantes.URL + "agendamento/Reagendamento?idUsuario={0}&idAgendamento={1}&data={2}&hora={3}&texto={4}";
            return new Operacao<AgendamentoViewModel>().First(string.Format(url, idUsuario, idAgendamento, data, hora, texto));
        }

        public AgendamentoViewModel Cancelamento(int idUsuario, int idAgendamento, string data, string hora, string texto)
        {
            string url = Constantes.URL + "agendamento/Cancelamento?idUsuario={0}&idAgendamento={1}&data={2}&hora={3}&texto={4}";
            return new Operacao<AgendamentoViewModel>().First(string.Format(url, idUsuario, idAgendamento, data, hora, texto));
        }

        public AgendamentoViewModel Encerramento(int idUsuario, int idAgenda, int idPrograma)
        {
            string url = Constantes.URL + "agendamento/Encerramento?idUsuario={0}&idAgenda={1}&idPrograma={2}";
            return new Operacao<AgendamentoViewModel>().First(string.Format(url, idUsuario, idAgenda, idPrograma));
        }

        public AgendamentoViewModel EncerramentoWeb(int idUsuario, int idAgenda)
        {
            string url = Constantes.URL + "agendamento/Encerramentoweb?idUsuario={0}&idAgenda={1}";
            return new Operacao<AgendamentoViewModel>().First(string.Format(url, idUsuario, idAgenda));
        }

        public AgendamentoQuadroViewModel[] Quadro(string dataInicial, string dataFinal, int idUsuario, int idRevenda)
        {
            string url = Constantes.URL + "agendamento/Quadro?dataInicial={0}&dataFinal={1}&idUsuario={2}&idRevenda={3}";
            return new Operacao<AgendamentoQuadroViewModel>().GetAll(string.Format(url, dataInicial, dataFinal, idUsuario, idRevenda));
        }
    }
}
