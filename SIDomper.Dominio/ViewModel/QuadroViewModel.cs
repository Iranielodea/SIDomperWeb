using System.Collections.Generic;

namespace SIDomper.Dominio.ViewModel
{
    public class QuadroViewModel : BaseViewModel
    {
        public QuadroViewModel()
        {
            TitulosQuadroViewModel = new HashSet<ParametroTitulosQuadroViewModel>();
        }
        public string CodigoStatusAberturaChamado { get; set; }
        public string CodigoStatusAberturaAtividade { get; set; }
        public string CodigoStatusAtendimentoChamado { get; set; }
        public string CodigoStatusAtendimentoAtividade { get; set; }
        public SolicitacaoPermissaoViewModel SolicitacaoPermissaoViewModel { get; set; }
        public ChamadoPermissaoViewModel ChamadoPermissaoViewModel { get; set; }
        public AgendamentoPermissaoViewModel AgendamentoPermissaoViewModel { get; set; }
        public RecadoPermissaoViewModel RecadoPermissaoViewModel { get; set; }

        public ICollection<ParametroTitulosQuadroViewModel> TitulosQuadroViewModel { get; set; }
    }
}
