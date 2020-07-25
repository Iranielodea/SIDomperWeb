using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoStatus
    {
        IEnumerable<StatusConsulta> Filtrar(string campo, string texto, EnStatus enStatus, string ativo = "A", bool contem = true);
        Status Novo(int idUsuario);
        Status Editar(int id, int idUsuario, ref string mensagem);
        Status ObterPorId(int id);
        Status ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        List<Status> ListarVisitas(string nome);
        void Excluir(Status model, int idUsuario);
        void Salvar(Status model);
        IEnumerable<Status> ListarTodos();
        Status ObterPorCodigo(int codigo, EnStatus enStatus);
        IEnumerable<Status> ObterPorPrograma(EnStatus enStatus);
    }
}
