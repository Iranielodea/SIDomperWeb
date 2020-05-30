using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Contato
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? OrcamentoId { get; set; }
        public string Nome { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Departamento { get; set; }
        public string Email { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Orcamento Orcamento { get; set; }
    }
}
