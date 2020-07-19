using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoCidade
    {
        Cidade Novo(int idUsuario);
        Cidade Editar(int id, int idUsuario, ref string mensagem);
        void Excluir(Cidade model, int idUsuario);
        Cidade ObterPorId(int id);
        Cidade ObterPorCodigo(int codigo);
        IQueryable<Cidade> Listar(string nome);
        void Salvar(Cidade model);
        IEnumerable<CidadeConsulta> Filtrar(string campo, string texto, bool? ativo, bool contem = true);
    }
}
