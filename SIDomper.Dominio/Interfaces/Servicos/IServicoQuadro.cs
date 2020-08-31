using SIDomper.Dominio.ViewModel;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoQuadro
    {
        QuadroViewModel DadosQuadro(int usuarioId);
    }
}
