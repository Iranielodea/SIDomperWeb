using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.RepositorioDapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ProdutoEF
    {
        private readonly Repositorio<Produto> _rep;
        private readonly RepositorioDapper<ProdutoConsulta> _repositorioDapper;

        public ProdutoEF()
        {
            _rep = new Repositorio<Produto>();
            _repositorioDapper = new RepositorioDapper<ProdutoConsulta>();
        }

        public IEnumerable<ProdutoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Prod_Id as Id,");
            sb.AppendLine(" Prod_Codigo as Codigo,");
            sb.AppendLine(" Prod_Nome as Nome,");
            sb.AppendLine(" Prod_Ativo as Ativo");
            sb.AppendLine(" FROM Produto");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine(" WHERE Prod_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Prod_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Prod_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _repositorioDapper.GetAll(sb.ToString()); // _rep.context.Database.SqlQuery<ProdutoConsulta>(sb.ToString());

            return lista;
        }

        public Produto ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public Produto ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public IQueryable<Produto> Listar(string nome)
        {
            return _rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public void Excluir(Produto model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Produto model)
        {
            if (model.Id == 0)
            {
                _rep.Add(model);
            }
            else
                _rep.Update(model);
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Produtos.Max<Produto>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public Produto ObterProduto()
        {
            return null;
        }
    }
}
