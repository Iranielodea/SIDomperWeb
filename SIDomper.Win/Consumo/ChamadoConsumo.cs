using Refit;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using System.Threading.Tasks;

namespace SIDomper.Win.Consumo
{
    public class ChamadoConsumo
    {
        public async Task<ChamadoQuadroViewModel> GetQuadroAsync(int IdUsuario, int idRevenda, EnumChamado tipoChamadoAtividade)
        {
            var resultado = RestService.For<IApiChamadoService>(Apresentacao.Comum.Constantes.URLRefit);
            return await resultado.GetQuadroAsync(IdUsuario, idRevenda, tipoChamadoAtividade);
        }
    }

    public interface IApiChamadoService
    {
        [Get("/api/chamado/AbrirQuadro?idUsuario={idUsuario}&idRevenda={idRevenda}&enumChamado={enumChamado}")]
        Task<ChamadoQuadroViewModel> GetQuadroAsync(int idUsuario, int idRevenda, EnumChamado enumChamado);
    }
}
