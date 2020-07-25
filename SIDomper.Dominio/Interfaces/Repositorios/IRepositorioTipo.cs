using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;

namespace SIDomper.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioTipo : IRepositorio<Tipo>
    {
        Tipo RetornarUmRegistro(EnumChamado enumChamado);
        Tipo RetornarUmRegistroPrograma(EnTipos enTipos);
        Tipo RetornarTipoAgendamento();
    }
}
