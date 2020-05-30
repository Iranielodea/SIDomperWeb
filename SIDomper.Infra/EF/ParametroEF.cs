using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ParametroEF
    {
        private readonly Repositorio<Parametro> _rep;

        public ParametroEF()
        {
            _rep = new Repositorio<Parametro>();
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public Parametro ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Salvar(Parametro model)
        {
            if (model.Id == 0)
            {
                _rep.Add(model);
            }
            else
                _rep.Update(model);
        }

        public Parametro ObterPorParametro(int codigo, int programa)
        {
            if (programa == 0)
                return _rep.First(x => x.Codigo == codigo);
            else
                return _rep.First(x => x.Codigo == codigo && x.Programa == programa);
        }

        public IQueryable<Parametro> ListarTodos()
        {
            return _rep.Get(x => x.Id > 0);
        }

        public IQueryable<Parametro> BuscarTitulosChamados()
        {
            return _rep.Get(x => x.Codigo == 3 || x.Codigo == 4 || x.Codigo == 5 || x.Codigo == 6 || x.Codigo == 7 || x.Codigo == 8);
        }

        public IEnumerable<ParametroConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Par_Id as Id,");
            sb.AppendLine(" Par_Codigo as Codigo,");
            sb.AppendLine(" Par_Nome as Nome,");
            sb.AppendLine(" Par_Programa as Programa,");
            sb.AppendLine(" Par_Valor as Valor");
            sb.AppendLine(" FROM Parametros");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Par_Id > 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<ParametroConsulta>(sb.ToString());

            return lista;
        }

        public void Excluir(Parametro model)
        {
            _rep.Deletar(model);
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Parametros.Max<Parametro>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
