using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.ViewModel
{
    public class ChamadoEditarViewModel
    {
        public DateTime DataAbertura { get; set; }
        public TimeSpan HoraAbertura { get; set; }
        public Chamado Chamado { get; set; }
    }
}
