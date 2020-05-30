using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class DepartamentoEF
    {
        private readonly Repositorio<Departamento> _rep;

        public DepartamentoEF()
        {
            _rep = new Repositorio<Departamento>();
        }

        public Departamento ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public Departamento ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public void Salvar(Departamento model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
            {
                _rep.Add(model);
            }
        }

        public void Excluir(Departamento model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public IEnumerable<DepartamentoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem=true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Dep_Id as Id,");
            sb.AppendLine(" Dep_Codigo as Codigo,");
            sb.AppendLine(" Dep_Nome as Nome");
            sb.AppendLine(" FROM Departamento");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Dep_Id > 0");
            }

            if (ativo == "A")
                sb.AppendLine(" AND Dep_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Dep_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<DepartamentoConsulta>(sb.ToString());

            return lista;

        }

        public void Duplicar(Departamento model)
        {
            var modelTemp = _rep.context.Departamentos.AsNoTracking().First(x => x.Id == model.Id);
            modelTemp.Id = 0;
            modelTemp.Nome = model.Nome + "01";

            //=================================================================
            // email
            var Email = _rep.context.DepartamentoEmails.AsNoTracking().Where(x => x.DepartamentoId == model.Id).ToList();

            foreach (var item in Email)
            {
                item.Departamento = modelTemp;
                item.Id = 0;
                _rep.context.DepartamentoEmails.Add(item);
            }

            //=================================================================
            // Acesso

            var Acesso = _rep.context.DepartamentoAcessos.AsNoTracking().Where(x => x.DepartamentoId == model.Id).ToList();
            foreach (var item in Acesso)
            {
                item.Departamento = modelTemp;
                item.Id = 0;
                _rep.context.DepartamentoAcessos.Add(item);
            }

            Salvar(modelTemp);
        }

        public void AdicionarEmail(DepartamentoEmail model)
        {
            _rep.context.DepartamentoEmails.Add(model);
        }

        public void AlterarEmail(Departamento model, DepartamentoEmail email)
        {
            foreach (var item in model.DepartamentosEmail)
            {
                if (item.Id == email.Id)
                {
                    item.Email = email.Email;
                }
            }
        }

        public void ExcluirEmail(int id)
        {
            var model = _rep.context.DepartamentoEmails.First(x => x.Id == id);
            if (model != null)
                _rep.context.DepartamentoEmails.Remove(model);
        }

        public void AlterarAcesso(Departamento model, DepartamentoAcesso acesso)
        {
            foreach (var item in model.DepartamentoAcessos)
            {
                if (item.Id == acesso.Id)
                {
                    item.Editar = acesso.Editar;
                    item.Excluir = acesso.Excluir;
                    item.Incluir = acesso.Incluir;
                    item.Programa = acesso.Programa;
                    item.Relatorio = acesso.Relatorio;
                    item.Acesso = acesso.Acesso;
                }
            }
        }

        public void ExcluirItem(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Departamento_Email WHERE DepEm_Id in (" + ids + ")");
        }

        public void ExcluirItemDepartamentoAcesso(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Departamento_Acesso WHERE DepAc_Id in (" + ids + ")");
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Departamentos.Max<Departamento>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
