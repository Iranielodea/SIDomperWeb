using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class RamalEF
    {
        private readonly Repositorio<Ramal> _rep;

        public RamalEF()
        {
            _rep = new Repositorio<Ramal>();
        }

        public IEnumerable<RamalConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Ram_Id as Id,");
            sb.AppendLine(" Ram_Departamento as Departamento");
            sb.AppendLine(" FROM Ramal");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Ram_Id > 0");
            }

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<RamalConsulta>(sb.ToString());

            return lista;
        }

        public Ramal ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Salvar(Ramal model)
        {
            if (model.Id == 0)
                _rep.Add(model);
            else
                _rep.Update(model);
        }

        public void Excluir(Ramal model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void ExcluirItem(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Ramal_Itens WHERE RamIt_Id in (" + ids + ")");
        }
    }
}
