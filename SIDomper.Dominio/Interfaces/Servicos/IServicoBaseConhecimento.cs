using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoBaseConhecimento
    {
        IEnumerable<BaseConhConsultaViewModel> Filtrar(BaseConhecimentoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem = true);
        BaseConhecimento Novo(int idUsuario);
        BaseConhecimento Editar(int id, int idUsuario, ref string mensagem);
        BaseConhecimento ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(BaseConhecimento model, int idUsuario);
        void Salvar(BaseConhecimento model);
    }
}
