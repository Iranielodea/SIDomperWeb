using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoFeriado
    {
        Feriado Novo(int idUsuario);
        Feriado Editar(int id, int idUsuario, ref string mensagem);
        void Excluir(Feriado model, int idUsuario);
        void Salvar(Feriado model);
        void Relatorio(int idUsuario);
        Feriado ObterPorId(int id);
        IEnumerable<Feriado> Filtrar(string campo, string texto);
    }
}
