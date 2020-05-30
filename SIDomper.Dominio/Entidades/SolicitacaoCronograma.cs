using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class SolicitacaoCronograma
    {
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? Data { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }

        public virtual Solicitacao Solicitacao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
