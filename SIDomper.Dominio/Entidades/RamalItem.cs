using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class RamalItem
    {
        public int Id { get; set; }
        public int RamalId { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }

        public virtual Ramal Ramal { get; set; }
    }
}
