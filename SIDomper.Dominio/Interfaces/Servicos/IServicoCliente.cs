using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoCliente
    {
        //IEnumerable<ClienteConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        //Cliente Novo(int idUsuario);
        //Cliente Editar(int id, int idUsuario, ref string mensagem);
        Cliente ObterPorId(int id);
        //Cliente ObterPorCodigo(int codigo);
        //void Relatorio(int idUsuario);
        //IQueryable<Cliente> Listar(string nome);
        //void Excluir(Cliente model, int idUsuario);
        //void Salvar(Cliente model);
    }
}
