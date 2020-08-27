using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoParametro
    {
        IEnumerable<ParametroConsulta> Filtrar(string campo, string texto, bool contem = true);
        Parametro Novo(int idUsuario);
        Parametro Editar(int id, int idUsuario, ref string mensagem);
        Parametro ObterPorId(int id);
        Parametro ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        void Excluir(Parametro model, int idUsuario);
        void Salvar(Parametro model);
        IEnumerable<Parametro> ListarTodos();
        Parametro ObterPorParametro(int codigo, int programa);
        IEnumerable<ParametroTitulosQuadroViewModel> BuscarTitulosQuadro();
    }
}
