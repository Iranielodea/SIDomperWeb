using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class UsuarioPermissao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Sigla { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
