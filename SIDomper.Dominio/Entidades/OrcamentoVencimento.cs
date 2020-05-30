using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class OrcamentoVencimento
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public int Parcela { get; set; }
        public DateTime Data { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        public virtual Orcamento Orcamento { get; set; }
    }
}
