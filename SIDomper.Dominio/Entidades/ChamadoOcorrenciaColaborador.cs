using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class ChamadoOcorrenciaColaborador
    {
        public int Id { get; set; }
        public int ChamadoOcorrenciaId { get; set; }
        public int UsuarioId { get; set; }
        public double TotalHoras { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }

        public virtual ChamadoOcorrencia ChamadoOcorrencia { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
