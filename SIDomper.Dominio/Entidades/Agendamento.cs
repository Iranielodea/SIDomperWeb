using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public string Contato { get; set; }
        public int Programa { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public string Motivo { get; set; }
        public int? VisitaId { get; set; }
        public int? AtividadeId { get; set; }
        public string NomeCliente { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Status Status { get; set; }
        public virtual Visita Visita { get; set; }
        public virtual Chamado Chamado { get; set; }
    }

    public class AgendamentoConsulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string TipoNome { get; set; }
        public string UsuarioNome { get; set; }
        public string StatusNome { get; set; }
    }

    public class AgendamentoQuadro
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string UsuarioNome { get; set; }
        public string StatusNome { get; set; }
    }
}
