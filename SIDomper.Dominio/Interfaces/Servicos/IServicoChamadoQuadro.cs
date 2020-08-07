using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoChamadoQuadro
    {
        ChamadoQuadroViewModel AbrirQuadro(int idUsuario, int idRevenda, EnProgramas enProgramas);
    }
}
