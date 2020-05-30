using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class OrcamentoNaoAprovado
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int OrcamentoId { get; set; }
        public string Descricao { get; set; }

        public virtual Tipo Tipo { get; set; }
        public virtual Orcamento Orcamento { get; set; }
    }
}
