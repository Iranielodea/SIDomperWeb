using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class SolicitacaoOcorrencia
    {
        public SolicitacaoOcorrencia()
        {
            Data = DateTime.Now;
            Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            Classificacao = 2;
        }
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descricao{ get; set; }
        public int? TipoId { get; set; }
        public int Classificacao { get; set; }
        public string Anexo { get; set; }

        public virtual Solicitacao Solicitacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}
