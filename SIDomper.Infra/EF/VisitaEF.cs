using SIDomper.Dominio.Entidades;
using SIDomper.Infra.Comun;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.RepositorioDapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class VisitaEF
    {
        private readonly Repositorio<Visita> _rep;
        private readonly RepositorioDapper<VisitaConsulta> _repositorioDapper;

        public VisitaEF()
        {
            _rep = new Repositorio<Visita>();
            _repositorioDapper = new RepositorioDapper<VisitaConsulta>();
        }

        public Visita ObterPorId(int id)
        {
            return _rep.First(x => x.Id == id);
            
            //using (var rep = new Repositorio<Visita>())
            //{
            //    return rep.context.Visitas
            //        .Include("Usuario")
            //        .Include("Cliente")
            //        .Include("Tipo")
            //        .Include("Status")
            //        .FirstOrDefault(x => x.Id == id);
            //}
        }

        public void Excluir(Visita model)
        {
            _rep.Deletar(model);
            _rep.Commit();
        }

        public void Salvar(Visita model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);
            _rep.Commit();
        }

        public List<ClienteEmail> RetornarEmailClientes(int visitaId)
        {
            var query = from cli in _rep.context.ClientesEmail
                        join vis in _rep.context.Visitas on cli.ClienteId equals vis.ClienteId
                        join sta in _rep.context.Status on vis.StatusId equals sta.Id
                        where vis.Id == visitaId && sta.NotificarCliente == true && cli.Notificar == true
                        select new 
                        {
                            cli.Email
                            
                        };

            var lista = new List<ClienteEmail>();
            foreach(var item in query)
            {
                var model = new ClienteEmail();
                model.Email = item.Email;

                lista.Add(model);
            }

            return lista;
        }

        private string MontarSql(int idUsuario, string campo, string valor)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Vis_Id as Id");
            //sb.AppendLine(",'' as Data");
            //sb.AppendLine(",Vis_Data as DataD");
            sb.AppendLine(",Vis_Data as Data");
            sb.AppendLine(",Vis_Dcto as Documento");
            sb.AppendLine(",Cli_Nome as NomeCliente");
            sb.AppendLine(",Cli_Fantasia as NomeFantasia");
            sb.AppendLine(",Usu_Nome as NomeConsultor");
            sb.AppendLine(",Vis_Dcto as Documento");

            sb.AppendLine(" FROM Visita");
            sb.AppendLine(" INNER JOIN Cliente ON Vis_Cliente = Cli_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Vis_Usuario = Usu_Id");
            sb.AppendLine(" WHERE " + campo + " LIKE'%" + valor + "%'");

            return sb.ToString();
        }

        public List<VisitaConsulta> Filtrar(int idUsuario, VisitaFiltro filtro, string campo, string valor)
        {
            var sb = new StringBuilder();
            //sb.AppendLine(" SELECT");
            //sb.AppendLine(" Vis_Id as Id");
            ////sb.AppendLine(",'' as Data");
            ////sb.AppendLine(",Vis_Data as DataD");
            //sb.AppendLine(",Vis_Data as Data");
            //sb.AppendLine(",Vis_Dcto as Documento");
            //sb.AppendLine(",Cli_Nome as NomeCliente");
            //sb.AppendLine(",Cli_Fantasia as NomeFantasia");
            //sb.AppendLine(",Usu_Nome as NomeConsultor");
            //sb.AppendLine(",Vis_Dcto as Documento");

            //sb.AppendLine(" FROM Visita");
            //sb.AppendLine(" INNER JOIN Cliente ON Vis_Cliente = Cli_Id");
            //sb.AppendLine(" LEFT JOIN Usuario ON Vis_Usuario = Usu_Id");
            //sb.AppendLine(" WHERE " + campo + " LIKE'%" + valor + "%'");

            //sb.AppendLine(" AND EXISTS(");
            //sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            //sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            //sb.AppendLine(" AND EXISTS(");
            //sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            //sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(MontarSql(idUsuario, campo, valor));

            if (!string.IsNullOrEmpty(filtro.RazaoSocial))
                sb.AppendLine(" AND Cli_Nome like '%" + filtro.RazaoSocial + "%'");

            if (filtro.ClienteId > 0)
                sb.AppendLine(" AND Vis_Cliente = " + filtro.ClienteId);

            if (filtro.DataInicial != null)
                sb.AppendLine(" AND Vis_Data >= '" + filtro.DataInicial + "'");

            if (filtro.DataFinal != null)
                sb.AppendLine(" AND Vis_Data <= '" + filtro.DataFinal + "'");

            if (filtro.RevendaId > 0)
                sb.AppendLine(" AND Cli_Revenda = " + filtro.RevendaId);

            if (filtro.StatusId > 0)
                sb.AppendLine(" AND Vis_Status = " + filtro.StatusId);

            if (filtro.TipoId > 0)
                sb.AppendLine(" AND Vis_Tipo = " + filtro.TipoId);

            if (filtro.UsuarioId > 0)
                sb.AppendLine(" AND Vis_Usuario = " + filtro.UsuarioId);
            sb.AppendLine(" ORDER BY Vis_Data DESC");

            var lista = _repositorioDapper.GetAll(sb.ToString()); // _rep.context.Database.SqlQuery<VisitaConsulta>(sb.ToString()).ToList();

            return lista.ToList();
        }

        public List<VisitaConsulta> FiltrarAPI(int idUsuario, VisitaFiltroAPI filtro, string campo, string valor)
        {
            var sb = new StringBuilder();

            sb.AppendLine(MontarSql(idUsuario, campo, valor));

            if (filtro.Id > 0)
                sb.AppendLine(" AND Vis_Id = " + filtro.Id);

            if (!string.IsNullOrWhiteSpace(filtro.Perfil))
                sb.AppendLine(" AND Cli_Perfil = '" + filtro.Perfil + "'");

            if (!Funcoes.DataEmBranco(filtro.DataInicial))
                sb.AppendLine(" AND Vis_Data >= '" + filtro.DataInicial + "'");

            if (!Funcoes.DataEmBranco(filtro.DataFinal))
                sb.AppendLine(" AND Vis_Data <= '" + filtro.DataFinal + "'");

            if (!string.IsNullOrWhiteSpace(filtro.ClienteId))
                sb.AppendLine(" AND Vis_Cliente IN (" + filtro.ClienteId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.RevendaId))
                sb.AppendLine(" AND Cli_Revenda IN (" + filtro.RevendaId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.StatusId))
                sb.AppendLine(" AND Vis_Status IN (" + filtro.StatusId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.TipoId))
                sb.AppendLine(" AND Vis_Tipo IN (" + filtro.TipoId + ")");

            if (!string.IsNullOrWhiteSpace(filtro.UsuarioId))
                sb.AppendLine(" AND Vis_Usuario IN (" + filtro.UsuarioId + ")");

            sb.AppendLine(" ORDER BY " + campo);

            var lista = _repositorioDapper.GetAll(sb.ToString()); // _rep.context.Database.SqlQuery<VisitaConsulta>(sb.ToString()).ToList();

            return lista.ToList();
        }

        public List<VisitaConsulta> Filtrar(int idUsuario, VisitaFiltro filtro)
        {
            return Filtrar(idUsuario, filtro, "Cli_Nome", "");
        }
    }
}
