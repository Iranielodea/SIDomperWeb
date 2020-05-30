using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Produto
    {
        public Produto()
        {
            ClienteModulos = new List<ClienteModulo>();
            OrcamentoItens = new List<OrcamentoItem>();
            Chamados = new List<Chamado>();
            Solicitacoes = new List<Solicitacao>();
            BaseConhecimentos = new List<BaseConhecimento>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<ClienteModulo> ClienteModulos { get; set; }
        public virtual ICollection<OrcamentoItem> OrcamentoItens { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }
        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
        public virtual ICollection<BaseConhecimento> BaseConhecimentos { get; set; }
    }

    public class ProdutoConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
