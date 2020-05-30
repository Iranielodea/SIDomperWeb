using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class CidadeEF
    {
        private readonly Repositorio<Cidade> _rep;
        public Repositorio<Cidade> CidadeRepositorio;

        public CidadeEF()
        {
            _rep = new Repositorio<Cidade>();
            CidadeRepositorio = new Repositorio<Cidade>();
        }
        public Cidade ObterPorId(int id)
        {
            return _rep.find(id);
            //using (var rep = new Repositorio<Cidade>())
            //{
            //    return rep.find(id);
            //}
        }

        public Cidade ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public IQueryable<Cidade> Listar(string nome)
        {
            return _rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true);
            //using (var rep = new Repositorio<Cidade>())
            //{
            //    return rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).ToList();
            //}
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Excluir(Cidade model)
        {
            _rep.Deletar(model);
        }

        public void Salvar(Cidade model)
        {
            if (model.Id == 0)
            {
                _rep.Add(model);
            }
            else
                _rep.Update(model);
        }

        public IEnumerable<CidadeConsulta> Filtrar(string campo, string texto, bool? ativo, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine("SELECT Cid_Id as Id, Cid_Codigo as Codigo, Cid_Nome as Nome, Cid_UF as UF FROM Cidade");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Cid_Id > 0");
            }

            if (ativo == true)
                sb.AppendLine(" AND Cid_Ativo = 1");
            if (ativo == false)
                sb.AppendLine(" AND Cid_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);

            var lista = _rep.context.Database.SqlQuery<CidadeConsulta>(sb.ToString());
            return lista;
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Cidades.Max<Cidade>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
