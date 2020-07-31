using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoChamado
    {
        IEnumerable<ChamadoConsultaViewModel> Filtrar(ChamadoFiltroViewModel filtro, string campo, string texto, int usuarioId, bool contem, EnumChamado tipo);
        Chamado Novo(int idUsuario, bool quadro, int idClienteAgendamento, int idAgendamento);
        Chamado Editar(int id, int idUsuario, ref string mensagem);
        Chamado ObterPorId(int id);
        void Relatorio(int idUsuario);
        void Excluir(Chamado model, int idUsuario);
        void Salvar(Chamado model, int idUsuario, bool ocorrencia);
        void SalvarAplicativo(ChamadoAplicativoInputViewModel chamadoInputModel);
        IEnumerable<ChamadoAplicativoViewModel> RetornarDadosAplicativo(string cnpj);
        ChamadoQuadroViewModel AbrirQuadro(int idUsuario, int idRevenda);
        IEnumerable<ChamadoAnexo> RetornarAnexos(int chamadoId);
        ClienteModulo ObterPorModulo(int idCliente, int idModulo);
    }
}
