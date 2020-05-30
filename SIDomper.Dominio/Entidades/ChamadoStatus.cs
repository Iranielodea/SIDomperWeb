using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class ChamadoStatus
    {
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public DateTime Data { get; set; }
        public int StatusId { get; set; }
        public int UsuarioId { get; set; }
        public TimeSpan? Hora { get; set; }

        public virtual Chamado Chamado { get; set; }
        public virtual Status Status { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
