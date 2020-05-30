using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SIDomper.Dominio.ViewModel
{
    public class OrcamentoViewModel
    {
        public OrcamentoViewModel()
        {
            Filtro = new OrcamentoFiltro();
            OrcamentoConsulta = new OrcamentoConsulta();
            Orcamento = new Orcamento();
            Campos = new List<OrcamentoCamposPesquisaViewModel>();
            ListaConsulta = new List<OrcamentoConsulta>();
        }
        public OrcamentoConsulta OrcamentoConsulta { get; set; }
        public OrcamentoFiltro Filtro { get; set; }
        public string Texto { get; set; }
        public string Campo { get; set; }
        public Orcamento Orcamento { get; set; }
        public List<OrcamentoCamposPesquisaViewModel> Campos { get; set; }
        public ICollection<OrcamentoConsulta> ListaConsulta { get; set; }
    }

    public class OrcamentoCamposPesquisaViewModel
    {
        public string Campo { get; set; }
        public string Descricao { get; set; }
    }

    public class OrcamentoEditarViewModel
    {
        public OrcamentoEditarViewModel()
        {
            clienteEmails = new List<ClienteEmail>();
            contatos = new List<Contato>();
            orcamentoItens = new List<OrcamentoItem>();
            orcamentoVencimentos = new List<OrcamentoVencimento>();
            orcamentoOcorrencias = new List<OrcamentoOcorrencia>();
            Orcamento = new Orcamento();
        }
        
        private string _situacao;
        public string Situacao {
            get {
                string retorno = "";
                int sit = Convert.ToInt32(_situacao);
                switch (sit)
                {
                    case 1:
                        retorno = "Em Análise";
                        break;
                    case 2:
                        retorno = "Aprovado";
                        break;
                    case 3:
                        retorno = "Não Aprovado";
                        break;
                    default:
                        retorno = "Faturado";
                        break;
                }
                return retorno;
            }
            set
            {
                _situacao = value;
            }
        }

        public DateTime DataEmissao { get; set; }
        public DateTime? DataSituacao { get; set; }
        public string NomeUsuario { get; set; }
        public string UF { get; set; }
        public string NomeCidade { get; set; }
        public string NomeCliente { get; set; }

        public Orcamento Orcamento { get; set; }
        public ICollection<ClienteEmail>  clienteEmails { get; set; }
        public ICollection<Contato> contatos { get; set; }
        public ICollection<OrcamentoItem> orcamentoItens { get; set; }
        public ICollection<OrcamentoVencimento> orcamentoVencimentos { get; set; }
        public ICollection<OrcamentoOcorrencia> orcamentoOcorrencias { get; set; }
        public List<Tipo> ListaTipos { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
    }
}
