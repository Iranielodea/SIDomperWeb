using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoRevenda
    {
        IEnumerable<RevendaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        Revenda Novo(int idUsuario);
        Revenda Editar(int id, int idUsuario, ref string mensagem);
        Revenda ObterPorId(int id);
        Revenda ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        void Excluir(Revenda model, int idUsuario);
        void Salvar(Revenda model);
        string RetornarEmails(Revenda model);
    }
}
