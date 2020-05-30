using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ModeloRelatorioEF
    {
        private readonly Repositorio<ModeloRelatorio> _rep;

        public ModeloRelatorioEF()
        {
            _rep = new Repositorio<ModeloRelatorio>();
        }

        public IEnumerable<ModeloRelatorioConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" ModR_Id as Id,");
            sb.AppendLine(" ModR_Codigo as Codigo,");
            sb.AppendLine(" ModR_Descricao as Descricao,");
            sb.AppendLine(" ModR_Revenda as IdRevenda");
            sb.AppendLine(" FROM Modelo_Relatorio");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE ModR_Id > 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<ModeloRelatorioConsulta>(sb.ToString());

            return lista;
        }

        public ModeloRelatorio ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public ModeloRelatorio ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public void Excluir(ModeloRelatorio model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(ModeloRelatorio model)
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
                return _rep.context.ModelosRelatorios.Max<ModeloRelatorio>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public ModeloRelatorio ObterModeloRelatorio()
        {
            return null;
        }
    }
}
