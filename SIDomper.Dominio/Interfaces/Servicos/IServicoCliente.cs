using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoCliente
    {
        IEnumerable<ClienteConsultaViewModelApi> Filtrar(int idUsuario, ClienteFiltroViewModelApi filtro, int modelo, string campo, string valor, bool contem = true);
        Cliente Novo(int idUsuario);
        Cliente Editar(int id, int idUsuario, ref string mensagem);
        Cliente ObterPorId(int id);
        Cliente ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        void Excluir(Cliente model, int idUsuario);
        void Salvar(Cliente model);
        ClienteLoginViewModel Login(string cnpj);        
        bool ImportarXml(string arquivo);
        string EmailsDoCliente(Cliente cliente);
    }
}
