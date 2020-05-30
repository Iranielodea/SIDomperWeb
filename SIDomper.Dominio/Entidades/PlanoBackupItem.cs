using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class PlanoBackupItem
    {
        public int Id { get; set; }
        public int PlanoBackupId { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Status { get; set; }

        public virtual PlanoBackup PlanoBackup { get; set; }
    }
}
