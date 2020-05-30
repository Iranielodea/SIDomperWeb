using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class PlanoBackup
    {
        public PlanoBackup()
        {
            PlanoBackupItens = new List<PlanoBackupItem>();
        }
        public int Id { get; set; }
        public string Destino { get; set; }
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataUltimoBackup { get; set; }

        public virtual ICollection<PlanoBackupItem> PlanoBackupItens { get; set; }
    }
}
