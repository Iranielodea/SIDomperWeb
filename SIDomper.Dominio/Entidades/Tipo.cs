using System.Collections.Generic;
using System.ComponentModel;

namespace SIDomper.Dominio.Entidades
{
    public class Tipo
    {
        public Tipo()
        {
            Visitas = new List<Visita>();
            Orcamentos = new List<Orcamento>();
            OrcamentoItens = new List<OrcamentoItem>();
            OrcamentoNaoAprovados = new List<OrcamentoNaoAprovado>();
            Chamados = new List<Chamado>();
            Solicitacoes = new List<Solicitacao>();
            Versoes = new List<Versao>();
            SolicitacaoOcorrencias = new List<SolicitacaoOcorrencia>();
            Agendamentos = new List<Agendamento>();
            BaseConhecimentos = new List<BaseConhecimento>();
            Recados = new List<Recado>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }

        [DisplayName("Tipo")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int Programa { get; set; }
        public string Conceito { get; set; }

        public virtual ICollection<Visita> Visitas { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        public virtual ICollection<OrcamentoItem> OrcamentoItens { get; set; }
        public virtual ICollection<OrcamentoNaoAprovado> OrcamentoNaoAprovados { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }
        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
        public virtual ICollection<Versao> Versoes { get; set; }
        public virtual ICollection<SolicitacaoOcorrencia> SolicitacaoOcorrencias { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<BaseConhecimento> BaseConhecimentos { get; set; }
        public virtual ICollection<Recado> Recados { get; set; }
    }

    public class TipoConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Programa { get; set; }
    }
}
