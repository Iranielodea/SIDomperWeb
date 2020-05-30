using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Licenca
    {
        public int Id { get; set; }
        public int? Codigo { get; set; }
        public string CnpjCpf { get; set; }
        public string Empresa { get; set; }
        public int? QtdeEstacao { get; set; }
        public int? QtdeUsuario { get; set; }
        public string IPExterno { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Build { get; set; }
        public string IPLocal { get; set; }
        public int? Cliente { get; set; }
    }
}
