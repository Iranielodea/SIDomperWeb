using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class StatusEF
    {
        private readonly Repositorio<Status> _rep;

        public StatusEF()
        {
            _rep = new Repositorio<Status>();
        }

        public Status ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<Status> ListarVisitas(string nome)
        {
            return _rep.Get(x => x.Programa == 2 && x.Nome.Contains(nome) && x.Ativo == true).OrderBy(o => o.Nome);
        }

        public Status ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo && x.Ativo == true);
        }

        public Status ObterPorCodigo(int codigo, EnStatus enStatus)
        {
            if (enStatus == EnStatus.Todos)
                return _rep.First(x => x.Codigo == codigo && x.Ativo == true);
            else
                return _rep.First(x => x.Codigo == codigo && x.Programa == (int)enStatus &&  x.Ativo == true);
        }

        public IQueryable<Status> ListarTodos()
        {
            return _rep.Get(x => x.Ativo == true);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Status model)
        {
            if (model.Id == 0)
            {
                _rep.Add(model);
            }
            else
                _rep.Update(model);
        }

        public void Excluir(Status model)
        {
            _rep.Deletar(model);
        }
        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Status.Max<Status>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }


        public IEnumerable<StatusConsulta> Filtrar(string campo, string texto, EnStatus enStatus, string ativo = "A", bool contem = true)
        {
            int tipo = (int)enStatus;

            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Sta_Id as Id,");
            sb.AppendLine(" Sta_Codigo as Codigo,");
            sb.AppendLine(" Sta_Nome as Nome,");
            sb.AppendLine(" Sta_Programa as Programa");
            sb.AppendLine(" FROM Status");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Sta_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Sta_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Sta_Ativo = 0");

            if (enStatus != EnStatus.Todos)
                sb.AppendLine(" AND Sta_Programa = " + tipo);

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<StatusConsulta>(sb.ToString());

            return lista;
        }
    }
}
