using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class FormaPagtoItens
    {
        public int Id { get; set; }
        public int FormaPagtoId { get; set; }
        public int Dias { get; set; }
        public string Observacao { get; set; }

        public virtual FormaPagto FormaPagto { get; set; }
    }
}
