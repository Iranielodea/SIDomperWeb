using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class ClienteEmail
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Email { get; set; }
        public bool Notificar { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
