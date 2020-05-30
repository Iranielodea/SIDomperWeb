using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDomper.Dominio.Entidades
{
    public class Modulo
    {
        public Modulo()
        {
            ClienteModulos = new List<ClienteModulo>();
            OrcamentoItemModulos = new List<OrcamentoItemModulo>();
            Chamados = new List<Chamado>();
            Solicitacoes = new List<Solicitacao>();
            BaseConhecimentos = new List<BaseConhecimento>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        
        public virtual ICollection<ClienteModulo> ClienteModulos { get; set; }
        public virtual ICollection<OrcamentoItemModulo> OrcamentoItemModulos { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }
        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
        public virtual ICollection<BaseConhecimento> BaseConhecimentos { get; set; }
    }

    public class ModuloConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
