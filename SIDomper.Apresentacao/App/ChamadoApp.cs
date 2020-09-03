using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class ChamadoApp
    {
        public ChamadoViewModel Novo(int idUsuario, EnumChamado enChamado, int idEncerramento, bool quadro, int idClienteAgendamento, int idAgendamento)
        {
            string url = Constantes.URL + "Chamado/Novo?idUsuario={0}&enChamadoAtividade={1}&idEncerramento={2}&quadro={3}&idClienteAgenciamento={4}&idAgendamento={5}";
            return new Operacao<ChamadoViewModel>().First(string.Format(url, idUsuario,  enChamado, idEncerramento, quadro, idClienteAgendamento, idAgendamento));
        }

        public ChamadoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "chamado/ObterPorId?id={0}";
            return new Operacao<ChamadoViewModel>().First(string.Format(url, id));
        }

        public ChamadoViewModel Editar(int idUsuario, int id, EnProgramas enProgramas)
        {
            string url = Constantes.URL + "Chamado/Editar?idUsuario={0}&id={1}&enProgramas={2}";
            return new Operacao<ChamadoViewModel>().First(string.Format(url, idUsuario, id, enProgramas));
        }

        public ChamadoConsultaViewModel[] Filtrar(ChamadoFiltroViewModel filtro, int idUsuario, string campo, string valor, bool contem, EnumChamado enChamado)
        {
            string url = Constantes.URL + "Chamado/Filtrar?idUsuario={0}&campo={1}&valor={2}&contem={3}&enChamado={4}";
            return new Operacao<ChamadoConsultaViewModel>().ObjetoToJSon(string.Format(url, idUsuario, campo, valor, contem, enChamado), filtro);
        }

        public ChamadoViewModel Salvar(ChamadoViewModel model, int idUsuario, bool ocorrencia)
        {
            string URI = Constantes.URL + "Chamado?idUsuario={0}&ocorrencia={1}";

            if (model.Id == 0)
                return new Operacao<ChamadoViewModel>().Insert(string.Format(URI, idUsuario, ocorrencia), model);
            else
                return new Operacao<ChamadoViewModel>().Update(string.Format(URI, idUsuario, ocorrencia), model);
        }

        public ChamadoViewModel Excluir(int id, int idUsuario, EnProgramas enProgramas)
        {
            string url = Constantes.URL + "chamado/{0}?idUsuario={1}&enProgramas={2}";
            return new Operacao<ChamadoViewModel>().Delete(string.Format(url, id, idUsuario, enProgramas));
        }

        public ChamadoViewModel BuscarModuloProduto(int idCliente, int idModulo)
        {
            string url = Constantes.URL + "Chamado/BuscarModuloProduto?idCliente={0}&idModulo={1}";
            return new Operacao<ChamadoViewModel>().First(string.Format(url, idCliente, idModulo));
        }

        public ChamadoAnexoViewModel[] BuscarAnexos(int idChamado, EnumChamado enumChamado)
        {
            string url = Constantes.URL + "chamado/RetornarAnexos?idChamado={0}&enChamado={1}";
            return new Operacao<ChamadoAnexoViewModel>().GetAll(string.Format(url, idChamado, enumChamado));
        }

        public SMSOutPutViewModel[] EnviarSMS(SMSOutPutViewModel[] model)
        {
            string url = "https://api.smsdev.com.br/v1/send";
            return new Operacao<SMSOutPutViewModel>().ObjetoToJSon(string.Format(url), model);
        }

        public ChamadoQuadroViewModel[] AbrirQuadro(int idUsuario, int idRevenda, EnumChamado enumChamado)
        {
            string url = Constantes.URL + "chamado/AbrirQuadro?idUsuario={0}&idRevenda={1}&enumChamado={2}";
            return new Operacao<ChamadoQuadroViewModel>().GetAll(string.Format(url, idUsuario, idRevenda, enumChamado));
        }

        public void GravarHoraAtual(ChamadoGravaHoraAtualViewModel model)
        {
            string url = Constantes.URL + "chamado/GravarHoraAtual";
            new Operacao<ChamadoViewModel>().Update(string.Format(url), model);
        }
    }
}
