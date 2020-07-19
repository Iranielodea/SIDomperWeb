using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoCategoria
    {
        IEnumerable<CategoriaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0);
        Categoria Novo(int idUsuario);
        Categoria Editar(int id, int idUsuario, ref string mensagem);
        Categoria ObterPorId(int id);
        Categoria ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        IQueryable<Categoria> Listar(string nome);
        void Excluir(Categoria model, int idUsuario);
        void Salvar(Categoria model);
    }
}
