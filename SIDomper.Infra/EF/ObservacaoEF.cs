using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ObservacaoEF
    {
        private readonly Repositorio<Observacao> _rep;

        public ObservacaoEF()
        {
            _rep = new Repositorio<Observacao>();
        }

        public IEnumerable<ObservacaoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Obs_Id as Id,");
            sb.AppendLine(" Obs_Codigo as Codigo,");
            sb.AppendLine(" Obs_Nome as Nome");
            sb.AppendLine(" FROM Observacao");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Obs_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Obs_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Obs_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<ObservacaoConsulta>(sb.ToString());

            return lista;
        }

        public Observacao ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public Observacao ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public Observacao ObterPadrao(int? programa)
        {
            return _rep.First(x => x.Padrao == true && x.Programa == programa);
        }

        public Observacao ObterEmailPadrao(int? programa)
        {
            return _rep.First(x => x.EmailPadrao == true && x.Programa == programa);
        }

        public void Excluir(Observacao model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Observacao model)
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
                return _rep.context.Observacoes.Max<Observacao>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public Observacao ObterObservacao()
        {
            return null;
        }
    }
}
