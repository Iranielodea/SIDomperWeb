using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoProduto
    {
        IEnumerable<ProdutoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        Produto ObterPorId(int id);
        Produto ObterPorCodigo(int codigo);
        IQueryable<Produto> Listar(string nome);
        void Excluir(Produto model);
        void Salvar(Produto model);
        int ProximoCodigo();
    }
}
