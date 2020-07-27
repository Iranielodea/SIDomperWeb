using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoVersao
    {
        IEnumerable<VersaoConsultaViewModel> Filtrar(VersaoFiltroViewModel filtro, string campo, string texto, bool contem);
        Versao Novo(int idUsuario);
        Versao Editar(int id, int idUsuario, ref string mensagem);
        Versao ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(Versao model, int idUsuario);
        void Salvar(Versao model);
        Status ObterStatusDesenvolvedor();
    }
}
