using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Orcamento
    {
        public Orcamento()
        {
            OrcamentoEmails = new List<OrcamentoEmail>();
            OrcamentoItens = new List<OrcamentoItem>();
            OrcamentoNaoAprovados = new List<OrcamentoNaoAprovado>();
            OrcamentoOcorrencias = new List<OrcamentoOcorrencia>();
            OrcamentoVencimentos = new List<OrcamentoVencimento>();
            Contatos = new List<Contato>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Data")]
        [DisplayName("Número")]
        public int Numero { get; set; }

        //[Required(ErrorMessage ="Informe a Data")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        public int UsuarioId { get; set; }
        public int? ProspectId { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }
        [DisplayName("Observação Email")]
        public string ObservacaoEmail { get; set; }
        public int? ClienteId { get; set; }

        [DisplayName("Situação")]
        public int Situacao { get; set; }
        [DisplayName("Forma Pagto")]
        public int? FormaPagtoId { get; set; }

        [Required(ErrorMessage = "Informe a Razão Social")]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }
        [DisplayName("Fantasia")]
        public string Fantasia { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
        [DisplayName("Contato")]
        public string Contato { get; set; }
        [DisplayName("Documento")]
        public string Dcto { get; set; }
        public int TipoId { get; set; }
        public int? SubTipo { get; set; }
        public bool EmailEnviado { get; set; }

        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        [DisplayName("Data Situação")]
        public DateTime? DataSituacao { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int? CidadeId { get; set; }
        public string Enquadramento { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular { get; set; }
        [DisplayName("Outro Fone")]
        public string OutroFone { get; set; }
        [DisplayName("Contato Financeiro")]
        public string ContatoFinanceiro { get; set; }
        [DisplayName("Fone Contato Financeiro")]
        public string FoneContatoFinanceiro { get; set; }
        [DisplayName("Contato Compra/Venda")]
        public string ContatoCompraVenda { get; set; }
        [DisplayName("Fone Contato Compra/Venda")]
        public string FoneContatoCompraVenda { get; set; }
        [DisplayName("Insc. Estadual")]
        public string IE { get; set; }
        [DisplayName("Representante Legal")]
        public string RepresentanteLegal { get; set; }
        [DisplayName("CPF Representante Legal")]
        public string CPFRespresentanteLegal { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Prospect Prospect { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual FormaPagto FormaPagto { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Cidade Cidade { get; set; }

        public virtual ICollection<OrcamentoEmail> OrcamentoEmails { get; set; }
        public virtual ICollection<OrcamentoItem> OrcamentoItens { get; set; }
        public virtual ICollection<OrcamentoNaoAprovado> OrcamentoNaoAprovados { get; set; }
        public virtual ICollection<OrcamentoOcorrencia> OrcamentoOcorrencias { get; set; }
        public virtual ICollection<OrcamentoVencimento> OrcamentoVencimentos { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }

        [NotMapped]
        public decimal TotalParcelas { get; set; }
        [NotMapped]
        public decimal TotalOrcamento { get; set; }
    }

    public class OrcamentoConsulta
    {
        public int Id { get; set; }
        [DisplayName("Número")]
        public int Numero { get; set; }

        [DisplayName("Data")]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        public string Data { get; set; }

        [DisplayName("Nome Cliente")]
        public string NomeCliente { get; set; }
        [DisplayName("Nome Usuário")]
        public string NomeUsuario { get; set; }
        [DisplayName("Situação")]
        public string Situacao { get; set; }
        [DisplayName("Email enviado")]
        public string EmailEnviado { get; set; }

        public DateTime DataD { get; set; }
        public int SituacaoI { get; set; }
        public bool EmailEnviadoB { get; set; }
    }

    public class OrcamentoFiltro
    {
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        public string DataInicial { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        public string DataFinal { get; set; }

        public int SubTipo { get; set; }
        public string EmailEnviado { get; set; }
        public int Situacao { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int CidadeId { get; set; }
        public int TipoId { get; set; }
        public int Numero { get; set; }
        public string DataSituacaoInicial { get; set; }
        public string DataSituacaoFinal { get; set; }
    }
}
