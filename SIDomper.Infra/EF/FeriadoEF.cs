using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class FeriadoEF
    {
        private readonly Repositorio<Feriado> _rep;

        public FeriadoEF()
        {
            _rep = new Repositorio<Feriado>();
        }

        public Feriado ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Salvar(Feriado model)
        {
            if (model.Id == 0)
                _rep.Add(model);
            else
                _rep.Update(model);
        }

        public void Excluir(Feriado model)
        {
            _rep.Deletar(model);
        }

        public IEnumerable<Feriado> Listar()
        {
           return _rep.Get(x => x.Id > 0);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public IEnumerable<Feriado> Filtrar(string campo, string texto)
        {
            string sTexto = "";
            sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Fer_Id as Id,");
            sb.AppendLine(" Fer_Descricao as Descricao,");
            sb.AppendLine(" Fer_Data as Data");
            sb.AppendLine(" FROM Feriado");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Fer_Id > 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<Feriado>(sb.ToString());

            return lista;
        }
    }
}
