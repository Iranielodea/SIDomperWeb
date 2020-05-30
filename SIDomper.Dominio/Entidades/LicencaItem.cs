using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class LicencaItem
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string CnpjCpf { get; set; }
        public DateTime? DataLcto { get; set; }
        public string Licenca { get; set; }
        public DateTime? DataUtilizacao { get; set; }
        public string Situacao { get; set; }
        public string Utilizada { get; set; }
        public int? Cliente { get; set; }
    }
}
