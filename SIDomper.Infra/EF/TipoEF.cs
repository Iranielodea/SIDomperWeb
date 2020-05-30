using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDomper.Dominio;
using SIDomper.Dominio.Enumeracao;

namespace SIDomper.Infra.EF
{
    public class TipoEF
    {
        private readonly Repositorio<Tipo> _rep;

        public TipoEF()
        {
            _rep = new Repositorio<Tipo>();
        }

        public Tipo ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IEnumerable<TipoConsulta> Filtrar(string campo, string texto, EnTipos enTipos, string ativo = "A", bool contem = true)
        {
            int tipo = (int)enTipos;

            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Tip_Id as Id,");
            sb.AppendLine(" Tip_Codigo as Codigo,");
            sb.AppendLine(" Tip_Nome as Nome,");
            sb.AppendLine(" Tip_Programa as Programa");
            sb.AppendLine(" FROM Tipo");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Tip_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Tip_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Tip_Ativo = 0");

            if (enTipos != EnTipos.Todos)
                sb.AppendLine(" AND Tip_Programa = " + tipo);

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<TipoConsulta>(sb.ToString());

            return lista;
        }

        public IQueryable<Tipo> ListarTipos(string nome, EnTipos enTipos)
        {
            int tipo = (int)enTipos;
            return _rep.Get(x => x.Programa == tipo && x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public Tipo RetornarUmRegistro(EnTipos enTipos)
        {
            int tipo = (int)enTipos;
            return _rep.First(x => x.Programa == tipo && x.Ativo == true);
        }

        public void Salvar(Tipo model)
        {
            if (model.Id == 0)
            {
                _rep.Add(model);
            }
            else
                _rep.Update(model);
        }

        public void Excluir(Tipo model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public Tipo ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public Tipo ObterPorCodigo(int codigo, EnTipos enTipos)
        {
            return _rep.First(x => x.Codigo == codigo && x.Programa == (int) enTipos);
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Tipos.Max<Tipo>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
