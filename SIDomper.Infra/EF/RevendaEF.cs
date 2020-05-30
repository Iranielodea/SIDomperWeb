using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class RevendaEF
    {
        private readonly Repositorio<Revenda> _rep;

        public RevendaEF()
        {
            _rep = new Repositorio<Revenda>();
        }

        public Revenda ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public Revenda ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public IQueryable<Revenda> ListarRevenda(string nome)
        {
            return _rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public IEnumerable<RevendaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Rev_Id as Id,");
            sb.AppendLine(" Rev_Codigo as Codigo,");
            sb.AppendLine(" Rev_Nome as Nome");
            sb.AppendLine(" FROM Revenda");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Rev_Id > 0");
            }

            if (ativo == "A")
                sb.AppendLine(" AND Rev_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Rev_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            var lista = _rep.context.Database.SqlQuery<RevendaConsulta>(sb.ToString());

            return lista;

        }

        public void Excluir(Revenda model)
        {
            _rep.Deletar(model);
        }

        public void AlterarEmail(Revenda model, RevendaEmail email)
        {
            if (string.IsNullOrWhiteSpace(email.Email))
                throw new Exception("Informe o email!");
            if (email.RevendaId == 0)
                throw new Exception("Informe a revenda!");

            var RevendaEmail = model.RevendaEmails.First(x => x.Id == email.Id);
            RevendaEmail.Revenda = email.Revenda;
            RevendaEmail.Email = email.Email;
        }

        public void ExcluirEmail(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Revenda_Email WHERE RevEm_Id in (" + ids + ")");
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Revenda model)
        {
            if (model.Id > 0)
            {
                _rep.Update(model);
            }
            else
            {
                _rep.Add(model);
            }
        }

        private void SalvarRevendaEmail(Revenda model)
        {
            foreach (var itemNovo in model.RevendaEmails)
            {
                if (string.IsNullOrWhiteSpace(itemNovo.Email))
                    throw new Exception("Informe o email!");
            }

            if (model.Id > 0)
            {
                var dadosBanco = _rep.context.RevendaEmails.Where(x => x.RevendaId == model.Id);
                foreach (var item in dadosBanco)
                {
                    var dadosModel = model.RevendaEmails.FirstOrDefault(x => x.Id == item.Id && x.Id > 0);
                    if (dadosModel != null)
                    {
                        item.Email = dadosModel.Email;
                    }
                    else
                    {
                        _rep.context.RevendaEmails.Remove(item);
                    }
                }
            }
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Revendas.Max<Revenda>(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
