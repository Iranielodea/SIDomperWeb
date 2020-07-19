using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoModulo
    {
        IEnumerable<ModuloConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0);
        Modulo Novo(int idUsuario);
        Modulo ObterPorId(int id);
        Modulo Editar(int id, int idUsuario, ref string mensagem);
        IQueryable<Modulo> ListarModulo(string nome);
        Modulo ObterPorCodigo(int codigo);
        void Excluir(Modulo model, int idUsuario);
        void Salvar(Modulo model);
        void Relatorio(int idUsuario);
    }
}
