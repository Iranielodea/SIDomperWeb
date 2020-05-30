using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class OrcamentoOcorrencia
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }

        public virtual Orcamento Orcamento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
