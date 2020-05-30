using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using System;

namespace SIDomper.Apresentacao.App
{

    public class ChamadoOcorrenciaApp
    {
        public ChamadoOcorrenciaViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "ChamadoOcorrencia?novo={0}&idUsuario={1}";
            return new Operacao<ChamadoOcorrenciaViewModel>().First(string.Format(url, "", idUsuario));
        }

        public ChamadoOcorrenciaViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "ChamadoOcorrencia/{0}";
            return new Operacao<ChamadoOcorrenciaViewModel>().First(string.Format(url, id));
        }

        public ChamadoOcorrenciaViewModel PermissaoAlterarDataHora(int idUsuarioLogado, int idUsuarioGravado, EnumChamado enChamado)
        {
            try
            {
                //string url = Constantes.URL + "ChamadoOcorrencia?idUsuarioLogado={0}&idUsuarioGravado={1}&enChamado={2}";
                string url = Constantes.URL + "ChamadoOcorrencia?idUsuarioLogado={0}&idUsuarioGravado={1}&enChamado={2}";
                return new Operacao<ChamadoOcorrenciaViewModel>().First(string.Format(url, idUsuarioLogado, idUsuarioGravado, enChamado));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ProblemaSolucaoViewModel[] RetornarProblemasSolucoes(string texto, int idUsuario, int idCliente, EnumChamado enumChamado)
        {
            string url = Constantes.URL + "ChamadoOcorrencia/RetornarProblemasSolucoes?texto={0}&idUsuario={1}&idCliente={2}&enumChamado={3}";
            return new Operacao<ProblemaSolucaoViewModel>().GetAll(string.Format(url, texto, idUsuario, idCliente, enumChamado));
        }
    }
}
