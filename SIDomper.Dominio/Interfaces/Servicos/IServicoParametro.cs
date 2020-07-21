using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Parametro ObterPorParametro(int codigo, int programa);
        IEnumerable<Parametro> BuscarTitulosChamados();
        IEnumerable<Parametro> ListarTodos();
    }
}
