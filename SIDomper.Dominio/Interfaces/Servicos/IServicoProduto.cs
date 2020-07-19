using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoProduto
    {
        IEnumerable<ProdutoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        Produto Novo(int idUsuario);
        Produto Editar(int id, int idUsuario, ref string mensagem);
        Produto ObterPorId(int id);
        Produto ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        IQueryable<Produto> Listar(string nome);
        void Excluir(Produto model, int idUsuario);
        void Salvar(Produto model);
    }
}
