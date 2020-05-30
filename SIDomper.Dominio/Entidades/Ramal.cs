using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Ramal
    {
        public Ramal()
        {
            RamalItens = new List<RamalItem>();
        }
        public int Id { get; set; }
        public string Departamento { get; set; }

        public virtual ICollection<RamalItem> RamalItens { get; set; }
    }

    public class RamalConsulta
    {
        public int Id { get; set; }
        public string Departamento { get; set; }
    }
}
