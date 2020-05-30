using System.Collections.Generic;
using System.ComponentModel;

namespace SIDomper.Dominio.Entidades
{
    public class Status
    {
        public Status()
        {
            Visitas = new List<Visita>();
            OrcamentoItens = new List<OrcamentoItem>();
            Chamados = new List<Chamado>();
            ChamadosStatus = new List<ChamadoStatus>();
            Solicitacoes = new List<Solicitacao>();
            Versoes = new List<Versao>();
            SolicitacaoStatus = new List<SolicitacaoStatus>();
            Agendamentos = new List<Agendamento>();
            BaseConhecimentos = new List<BaseConhecimento>();
            Recados = new List<Recado>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        [DisplayName("Status")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int Programa { get; set; }
        public bool NotificarCliente { get; set; }
        public bool NotificarSupervisor { get; set; }
        public bool NotificarConsultor { get; set; }
        public bool NotificarRevenda { get; set; }
        public string Conceito { get; set; }

        public virtual ICollection<Visita> Visitas { get; set; }
        public virtual ICollection<OrcamentoItem> OrcamentoItens { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }
        public virtual ICollection<ChamadoStatus> ChamadosStatus { get; set; }
        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
        public virtual ICollection<Versao> Versoes{ get; set; }
        public virtual ICollection<SolicitacaoStatus> SolicitacaoStatus { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<BaseConhecimento> BaseConhecimentos { get; set; }
        public virtual ICollection<Recado> Recados { get; set; }
    }

    public class StatusConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Programa { get; set; }
    }
}
