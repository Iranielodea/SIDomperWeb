using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class ClienteEspecifiacaoEF
    {
        private readonly Repositorio<ClienteEspecifiacao> _rep;

        public ClienteEspecifiacaoEF()
        {
            _rep = new Repositorio<ClienteEspecifiacao>();
        }

        public ClienteEspecifiacao ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IEnumerable<ClienteEspecifiacaoConsulta> Filtrar(int idCliente)
        {
            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" CliEsp_Id as Id,");
            sb.AppendLine(" CliEsp_Item as Item,");
            sb.AppendLine(" CliEsp_Data as Data,");
            sb.AppendLine(" CliEsp_Nome as Nome");
            sb.AppendLine(" FROM Cliente_Especificacao");
            sb.AppendLine(" WHERE CliEsp_Cliente = " + idCliente);

            var lista = _rep.context.Database.SqlQuery<ClienteEspecifiacaoConsulta>(sb.ToString());

            return lista;
        }

        public void Excluir(ClienteEspecifiacao model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(ClienteEspecifiacao model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
            {
                _rep.Add(model);
            }
        }

        public int ProximoNumero()
        {
            try
            {
                return _rep.GetAll().Where(x => x.ClienteId == 1).Max(x => x.Item)  + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
