using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoObservacao
    {
        IEnumerable<ObservacaoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        Observacao Novo(int idUsuario);
        Observacao Editar(int id, int idUsuario, ref string mensagem);
        Observacao ObterPorId(int id);
        Observacao ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);        
        void Excluir(Observacao model, int idUsuario);
        void Salvar(Observacao model);
        Observacao ObterPadrao(int? programa);
        Observacao ObterEmailPadrao(int? programa);
    }
}
