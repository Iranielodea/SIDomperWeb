using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.ViewModel
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            FiltroCliente = new ClienteFiltro();
            Clientes = new List<ClienteConsulta>();
            EmailsClientes = new List<ClienteEmail>();
            ClienteModulos = new List<ClienteModulo>();
            Campos = new List<ClienteCamposPesquisaViewModel>();
        }
        public int Id { get; set; }
        [DisplayName("Razão Social")]
        public string Razao { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        [DisplayName("Consultor")]
        public string NomeConsultor { get; set; }
        public string Texto { get; set; }
        public string Campo { get; set; }        
        public ICollection<ClienteConsulta> Clientes { get; set; }
        public ClienteFiltro FiltroCliente { get; set; }
        public ICollection<ClienteEmail> EmailsClientes { get; set; }
        public ICollection<ClienteModulo> ClienteModulos { get; set; }
        public List<ClienteCamposPesquisaViewModel> Campos { get; set; }
    }

    public class ClienteCamposPesquisaViewModel
    {
        public string Campo { get; set; }
        public string Descricao { get; set; }
    }

    public class ClienteLoginViewModel
    {
        public string CNPJ { get; set; }
        public string Resultado { get; set; }
    }
}
