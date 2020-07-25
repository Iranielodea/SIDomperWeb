using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoTipo
    {
        IEnumerable<TipoConsulta> Filtrar(string campo, string texto, EnTipos enTipos, string ativo = "A", bool contem = true);
        Tipo Novo(int idUsuario);
        Tipo Editar(int id, int idUsuario, ref string mensagem);
        Tipo ObterPorId(int id);
        Tipo ObterPorCodigo(int codigo, EnTipos enTipos);
        void Relatorio(int idUsuario);
        IQueryable<Tipo> Listar(string nome);
        void Excluir(Tipo model, int idUsuario);
        void Salvar(Tipo model);
        List<Tipo> ListarTipos(string nome, EnTipos enTipos);
    }
}
