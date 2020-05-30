using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class ContaEmailEF
    {
        private readonly Repositorio<ContaEmail> _rep;

        public ContaEmailEF()
        {
            _rep = new Repositorio<ContaEmail>();
        }

        public ContaEmail ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IEnumerable<ContaEmailConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" CtaEm_Id as Id,");
            sb.AppendLine(" CtaEm_Codigo as Codigo,");
            sb.AppendLine(" CtaEm_Nome as Nome,");
            sb.AppendLine(" CtaEm_Email as Email");
            sb.AppendLine(" FROM Conta_Email");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE CtaEm_Id > 0");
            }

            if (ativo == "A")
                sb.AppendLine(" AND CtaEm_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND CtaEm_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<ContaEmailConsulta>(sb.ToString());

            return lista;

        }

        public ContaEmail ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public void Excluir(ContaEmail model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(ContaEmail model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
            {
                _rep.Add(model);
            }
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.ContasEmails.Max<ContaEmail>(x => x.Id) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
