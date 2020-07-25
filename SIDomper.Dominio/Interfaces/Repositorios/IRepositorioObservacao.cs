using SIDomper.Dominio.Entidades;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioObservacao : IRepositorio<Observacao>
    {
        Observacao ObterPadrao(int? programa);
        Observacao ObterEmailPadrao(int? programa);
    }
}
