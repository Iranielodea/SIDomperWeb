using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoRamal
    {
        IEnumerable<RamalConsulta> Filtrar(string campo, string texto, bool contem = true);
        Ramal Novo(int idUsuario);
        Ramal Editar(int id, int idUsuario, ref string mensagem);
        Ramal ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(Ramal model, int idUsuario);
        void Salvar(Ramal model);
    }
}
