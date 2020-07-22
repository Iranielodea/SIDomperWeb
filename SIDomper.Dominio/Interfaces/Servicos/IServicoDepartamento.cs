using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoDepartamento
    {
        IEnumerable<DepartamentoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        Departamento Novo(int idUsuario);
        Departamento Editar(int id, int idUsuario, ref string mensagem);
        Departamento ObterPorId(int id);
        Departamento ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        void Excluir(Departamento model, int idUsuario);
        void Salvar(Departamento model);
        Departamento Duplicar(Departamento model);
    }
}
