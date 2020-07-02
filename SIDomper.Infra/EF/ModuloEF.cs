using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ModuloEF
    {
        private readonly Repositorio<Modulo> _rep;

        public ModuloEF()
        {
            _rep = new Repositorio<Modulo>();
        }

        public IEnumerable<ModuloConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Mod_Id as Id,");
            sb.AppendLine(" Mod_Codigo as Codigo,");
            sb.AppendLine(" Mod_Nome as Nome");
            sb.AppendLine(" FROM Modulo");

            if (idCliente > 0)
                sb.AppendLine("INNER JOIN Cliente_Modulo ON CliMod_Modulo = Mod_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Mod_Id > 0");

            if (idCliente > 0)
                sb.AppendLine(" AND CliMod_Cliente = " + idCliente);

            if (ativo == "A")
                sb.AppendLine(" AND Mod_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Mod_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<ModuloConsulta>(sb.ToString());

            return lista;

        }

        public Modulo ObterPorId(int id)
        {
            return _rep.find(id);

            //using (var rep = new Repositorio<Modulo>())
            //{
            //    return rep.find(id);
            //}
        }

        public IQueryable<Modulo> ListarModulo(string nome)
        {
            return _rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
            //using (var rep = new Repositorio<Modulo>())
            //{
            //    return rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome).ToList();
            //}
        }

        public Modulo ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public void Excluir(Modulo model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Modulo model)
        {
            _rep.AddUpdate(model);
            //if (model.Id > 0)
            //    _rep.Update(model);
            //else
            //    _rep.Add(model);
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Modulos.Max<Modulo>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
