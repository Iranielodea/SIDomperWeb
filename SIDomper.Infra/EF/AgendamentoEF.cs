using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.Comun;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class AgendamentoEF
    {
        private readonly Repositorio<Agendamento> _rep;
        private Contexto ctx;

        public AgendamentoEF()
        {
            _rep = new Repositorio<Agendamento>();
            ctx = new Contexto();
        }

        public Agendamento ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Excluir(Agendamento model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Agendamento model)
        {
            _rep.AddUpdate(model);
        }

        public bool VerificarAgendamentoAberto(int idUsuario, int idStatusEncerrado, int idStausCancelado)
        {
            return _rep.context.Agendamentos.Where(x => x.UsuarioId == idUsuario && x.StatusId != idStatusEncerrado && x.StatusId != idStausCancelado).Any();
        }

        public List<ClienteEmail> RetornarEmailClientes(int agendamentoId)
        {
            var query = from cli in _rep.context.ClientesEmail
                        join age in _rep.context.Agendamentos on cli.ClienteId equals age.ClienteId
                        join sta in _rep.context.Status on age.StatusId equals sta.Id
                        where age.Id == agendamentoId && sta.NotificarCliente == true && cli.Notificar == true
                        select new
                        {
                            cli.Email

                        };

            var lista = new List<ClienteEmail>();
            foreach (var item in query)
            {
                var model = new ClienteEmail();
                model.Email = item.Email;

                lista.Add(model);
            }
            return lista;
        }

        public IEnumerable<AgendamentoConsultaViewModel> Filtrar(AgendamentoFiltroViewModel filtro, string campo, string texto, int idUsuario, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            var usuarioCliente = new UsuarioEF();

            sb.AppendLine(" SELECT");
            sb.AppendLine(" Age_Id as Id,");
            sb.AppendLine("	Age_Data as Data,");
            sb.AppendLine("	Age_Hora as Hora,");
            sb.AppendLine(" Age_Cliente as ClienteId,");
            sb.AppendLine(" Age_NomeCliente as NomeCliente,");
            sb.AppendLine(" Tip_Nome as TipoNome,");
            sb.AppendLine(" Usu_Nome as UsuarioNome,");
            sb.AppendLine(" Sta_Nome as StatusNome");
            sb.AppendLine(" FROM Agendamento");
            sb.AppendLine("     INNER JOIN Cliente ON Age_Cliente = Cli_Id");
            sb.AppendLine(" 	INNER JOIN Tipo ON Age_Tipo = Tip_Id");
            sb.AppendLine(" 	INNER JOIN Usuario ON Age_Usuario = Usu_Id");
            sb.AppendLine(" 	INNER JOIN Status ON Age_Status = Status.Sta_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Age_Id > 0");
            }

            sb.AppendLine(usuarioCliente.PermissaoUsuario(idUsuario));

            if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (filtro.DataInicial.Trim() != "/  /"))
                sb.AppendLine(" AND Age_Data >=" + Funcoes.DataIngles(filtro.DataInicial));

            if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (filtro.DataFinal.Trim() != "/  /"))
                sb.AppendLine(" AND Age_Data <=" + Funcoes.DataIngles(filtro.DataFinal));

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Age_Cliente IN (" + filtro.IdCliente + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdTipo))
                sb.AppendLine(" AND Age_Tipo IN (" + filtro.IdTipo + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
                sb.AppendLine(" AND Age_Status IN (" + filtro.IdStatus + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdUsuario))
                sb.AppendLine(" AND Age_Usuario IN (" + filtro.IdUsuario + ")");

            var lista =  ctx.Database.SqlQuery<AgendamentoConsultaViewModel>(sb.ToString());
            return lista;
        }
    }
}
