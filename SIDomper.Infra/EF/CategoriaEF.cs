using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class CategoriaEF
    {
        private readonly Repositorio<Categoria> _rep;

        public CategoriaEF()
        {
            _rep = new Repositorio<Categoria>();
        }

        public IEnumerable<CategoriaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Cat_Id as Id,");
            sb.AppendLine(" Cat_Codigo as Codigo,");
            sb.AppendLine(" Cat_Nome as Nome");
            sb.AppendLine(" FROM Categoria");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Cat_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Cat_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Cat_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<CategoriaConsulta>(sb.ToString());

            return lista;

        }

        public Categoria ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<Categoria> ListarCategoria(string nome)
        {
            return _rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public Categoria ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public void Excluir(Categoria model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Categoria model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Categorias.Max<Categoria>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
