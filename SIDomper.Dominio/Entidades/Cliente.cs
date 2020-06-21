using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDomper.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente()
        {
            Emails = new List<ClienteEmail>();
            ClienteModulos = new List<ClienteModulo>();
            Visitas = new List<Visita>();
            Orcamentos = new List<Orcamento>();
            Contatos = new List<Contato>();
            Chamados = new List<Chamado>();
            ClienteEspecifiacoes = new List<ClienteEspecifiacao>();
            Solicitacoes = new List<Solicitacao>();
            Agendamentos = new List<Agendamento>();
            Recados = new List<Recado>();
            Enquadramento = "00";
        }
        public int Id { get; set; }
        [DisplayName("Código")]
        public int Codigo { get; set; }
        [DisplayName("Nome Cliente")]
        public string Nome { get; set; }
        [DisplayName("Nome Fantasia")]
        public string Fantasia { get; set; }
        [DisplayName("Documento")]
        public string Dcto { get; set; }
        public string Enquadramento { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public int RevendaId { get; set; }
        public bool Ativo { get; set; }
        public bool Restricao { get; set; }
        public int? UsuarioId { get; set; }
        [DisplayName("Versão")]
        public string Versao { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int? CidadeId { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular { get; set; }
        public string OutroFone { get; set; }
        public string ContatoFinanceiro { get; set; }
        public string FoneContatoFinanceiro { get; set; }
        public string ContatoCompraVenda { get; set; }
        public string FoneContatoCompraVenda { get; set; }
        [DisplayName("Insc.Estadual")]
        public string IE { get; set; }
        public string RepresentanteLegal { get; set; }
        public string CPFRepresentanteLegal { get; set; }
        public int? EmpresaVinculada { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Perfil { get; set; }

        public virtual Revenda Revenda { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<ClienteEmail> Emails { get; set; }
        public virtual ICollection<ClienteModulo> ClienteModulos { get; set; }
        public virtual ICollection<Visita> Visitas { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }
        public virtual ICollection<ClienteEspecifiacao> ClienteEspecifiacoes { get; set; }
        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Recado> Recados { get; set; }
    }

    public class ClienteConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Perfil { get; set; }
        [DisplayName("Razão")]
        public string Razao { get; set; }
        public string Fantasia { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        [DisplayName("Consultor")]
        public string NomeConsultor { get; set; }
        public string NomeRevenda { get; set; }
        public string Enquadramento { get; set; }
        public string Versao { get; set; }
    }

    public class ClienteFiltro
    {
        public int Id { get; set; }
        public string Ativo { get; set; }
        public int Restricao { get; set; }
        public string Versao { get; set; }
        public string EmpresaVinculada { get; set; }
        public int UsuarioId { get; set; }
        public int RevendaId { get; set; }
        public int CidadeId { get; set; }
        public int ModuloId { get; set; }
        public int ProdutoId { get; set; }
        public string Enquadramento { get; set; }
        public string NomeCliente { get; set; }
        public string Perfil { get; set; }
        public string Campo { get; set; }
        public string Valor { get; set; }
        public int Modelo { get; set; }
        public string FiltroIdUsuario { get; set; }
        public string FiltroIdRevenda { get; set; }
        public string FiltroIdCidade { get; set; }
        public string FiltroIdModulo { get; set; }
        public string FiltroIdProduto { get; set; }
    }
}
