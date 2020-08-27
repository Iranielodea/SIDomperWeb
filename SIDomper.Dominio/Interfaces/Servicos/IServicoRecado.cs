using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoRecado
    {
        IEnumerable<RecadoConsultaViewModel> Filtrar(RecadoFiltroViewModel filtro);
        Recado Novo(int idUsuario);
        Recado Editar(int id, int idUsuario, ref string mensagem);
        Recado ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(Recado model, int idUsuario);
        void Salvar(Recado model);
        IEnumerable<RecadoQuadroViewModel> RetornarQuadro(int idUsuario, int idRevenda);
    }
}
