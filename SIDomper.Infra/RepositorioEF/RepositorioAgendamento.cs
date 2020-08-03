using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioAgendamento : RepositorioBaseEF<Agendamento>, IRepositorioAgendamento
    {
        private readonly Contexto _contexto;

        public RepositorioAgendamento(Contexto contexto            
            ) : base(contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<ClienteEmail> RetornarEmailClientes(int agendamentoId)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" CliEm_Id as Id,");
            sb.AppendLine(" CliEm_Cliente as ClienteId,");
            sb.AppendLine(" CliEm_Notificar as Notificar,");
            sb.AppendLine(" CliEm_Email as Email");
            sb.AppendLine(" FROM Agendamento");
            sb.AppendLine(" INNER JOIN Cliente_Email ON Age_Cliente = CliEm_Cliente");
            sb.AppendLine(" INNER JOIN Status On Age_Status = Sta_Id");
            sb.AppendLine(" WHERE Age_Id = " + agendamentoId);
            sb.AppendLine(" AND Sta_NotificarCliente = 1 AND CliEm_Notificar = 1");
            return _contexto.Database.SqlQuery<ClienteEmail>(sb.ToString());
        }

        public bool VerificarAgendamentoAberto(int idUsuario, int idStatusEncerrado, int idStausCancelado)
        {
            return _contexto.Agendamentos.Where(x => x.UsuarioId == idUsuario && x.StatusId != idStatusEncerrado && x.StatusId != idStausCancelado).Any();
        }
    }
}
