using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.RepositorioDapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ClienteEF
    {
        private readonly Repositorio<Cliente> _rep;
        private readonly RepositorioDapper<ClienteConsulta> _repositorioDapper;

        public ClienteEF()
        {
            _rep = new Repositorio<Cliente>();
            _repositorioDapper = new RepositorioDapper<ClienteConsulta>();
        }

        public Cliente ObterPorId(int id)
        {
            return _rep.First(x => x.Id == id);
        }

        public Cliente ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public void Excluir(Cliente model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Cliente model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);

            _rep.Commit();
        }

        public void SalvarAPI(Cliente model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);
        }

        public void ExcluirItem(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Contato WHERE Cont_Id in (" + ids + ")");
        }

        public void ExcluirEmail(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Cliente_Email WHERE CliEm_Id in (" + ids + ")");
        }

        public void ExcluirModulos(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Cliente_Modulo WHERE CliMod_Id in (" + ids + ")");
        }

        public List<ClienteConsulta> Filtrar(int idUsuario, ClienteFiltro filtro, int modelo, string campo, string valor, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + valor + "%'";
            if (contem)
                sTexto = "'%" + valor + "%'";

            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Cli_Codigo as Codigo");
            sb.AppendLine(",Cli_Perfil as Perfil");
            sb.AppendLine(",Cli_Versao as Versao");
            sb.AppendLine(",Cli_Id as Id");
            sb.AppendLine(",cli_Fantasia as Fantasia");
            sb.AppendLine(",cli_Nome as Razao");
            sb.AppendLine(",cli_Dcto as Documento");
            sb.AppendLine(",Cli_Fone1 as Telefone");
            sb.AppendLine(",Cli_Enquadramento as Enquadramento");
            sb.AppendLine(",Usu_Nome as NomeConsultor, Rev_Nome");
            sb.AppendLine(",Rev_Nome as NomeRevenda");
            sb.AppendLine(" FROM Cliente");
            sb.AppendLine(" INNER JOIN Revenda ON Cli_Revenda = Rev_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Cli_Usuario = Usu_Id");
            sb.AppendLine(" WHERE Cli_Id IS NOT NULL");
            sb.AppendLine(" AND " + campo + " LIKE " + sTexto);

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            if (filtro.Ativo != "T")
            {
                if (filtro.Ativo == "A")
                    sb.AppendLine(" AND Cli_Ativo = 1");
                else
                    sb.AppendLine(" AND Cli_Ativo = 0");
            }

            if (filtro.UsuarioId > 0)
                sb.AppendLine("  AND Cli_Usuario =" + filtro.UsuarioId);

            if (filtro.RevendaId > 0)
                sb.AppendLine("  AND Cli_Revenda =" + filtro.RevendaId);

            if (!string.IsNullOrEmpty(filtro.FiltroIdUsuario))
                sb.AppendLine("  AND Cli_Usuario in (" + filtro.FiltroIdUsuario + ")");

            if (filtro.Restricao < 2)
            {
                if (filtro.Restricao == 0)
                    sb.AppendLine("  AND Cli_Restricao = 1");

                if (filtro.Restricao == 1)
                    sb.AppendLine("  AND Cli_Restricao = 0");
            }

            if (filtro.Id > 0)
                sb.AppendLine("  AND Cli_Id =" + filtro.Id);

            if (!string.IsNullOrWhiteSpace(filtro.Enquadramento))
                sb.AppendLine("  AND Cli_Enquadramento = '" + filtro.Enquadramento + "'");

            if (filtro.CidadeId > 0)
                sb.AppendLine("  AND Cli_Cidade =" + filtro.CidadeId);

            if (!string.IsNullOrEmpty(filtro.FiltroIdCidade))
                sb.AppendLine("  AND Cli_Cidade in (" + filtro.FiltroIdCidade + ")");

            if (!string.IsNullOrWhiteSpace(filtro.Versao))
                sb.AppendLine("  AND Cli_Versao = '" + filtro.Versao + "'");

            if (filtro.EmpresaVinculada == "S")
                sb.AppendLine("  AND Cli_EmpresaVinculada > 0");

            if (filtro.EmpresaVinculada == "N")
                sb.AppendLine(" AND ((Cli_EmpresaVinculada = 0) OR (Cli_EmpresaVinculada IS NULL))");

            if (!string.IsNullOrWhiteSpace(filtro.Perfil))
                sb.AppendLine(" AND Cli_Perfil = '" + filtro.Perfil + "'");

            if (modelo == 2)
            {
                if (filtro.ModuloId > 0)
                    sb.AppendLine(" AND CliMod_Modulo = " + filtro.ModuloId);

                if (!string.IsNullOrEmpty(filtro.filtroIdModulo))
                    sb.AppendLine("  AND CliMod_Modulo in (" + filtro.filtroIdModulo + ")");

                if (filtro.ProdutoId > 0)
                    sb.AppendLine(" AND CliMod_Produto = " + filtro.ProdutoId);

                if (!string.IsNullOrEmpty(filtro.FiltroIdProduto))
                    sb.AppendLine("  AND CliMod_Produto in (" + filtro.FiltroIdProduto + ")");
            }
            else
            {
                if (filtro.ModuloId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Modulo = " + filtro.ModuloId + ")");
                }

                if (!string.IsNullOrEmpty(filtro.filtroIdModulo))
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Modulo IN (" + filtro.filtroIdModulo + "))");
                }

                if (filtro.ProdutoId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Produto = " + filtro.ProdutoId + ")");
                }

                if (!string.IsNullOrEmpty(filtro.FiltroIdProduto))
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Produto in (" + filtro.FiltroIdProduto + "))");
                }
            }
            sb.AppendLine(" ORDER BY " + campo);

            return _repositorioDapper.GetAll(sb.ToString()).ToList();
        }

        public void AtualizarVersao(int idCliente, string versao)
        {
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE Cliente SET");
            sb.AppendLine(" Cli_Versao = '" + versao + "'");
            sb.AppendLine(" WHERE Cli_Id = " + idCliente);

            _rep.context.Database.ExecuteSqlCommand(sb.ToString());
        }

        public void AdicionarEmail(ClienteEmail model)
        {
            _rep.context.ClientesEmail.Add(model);
        }

        public void AlterarEmail(Cliente model, ClienteEmail email)
        {
            foreach (var item in model.Emails)
            {
                if (item.Id == email.Id)
                {
                    item.Email = email.Email;
                }
            }
        }

        public void ExcluirEmail(int id)
        {
            var model = _rep.context.ClientesEmail.First(x => x.Id == id);
            if (model != null)
                _rep.context.ClientesEmail.Remove(model);
        }

        public void AdicionarModulo(ClienteModulo model)
        {
            _rep.context.ClientesModulos.Add(model);
        }

        public void AlterarModulo(Cliente model, ClienteModulo modulo)
        {
            foreach (var item in model.ClienteModulos)
            {
                if (item.Id == modulo.Id)
                {
                    item.ModuloId = modulo.ModuloId;
                    item.ProdutoId = modulo.ProdutoId;
                }
            }
        }

        public void ExcluirModulo(int id)
        {
            var model = _rep.context.ClientesModulos.First(x => x.Id == id);
            if (model != null)
                _rep.context.ClientesModulos.Remove(model);
        }

        public Cliente BuscarPorId(int id)
        {
            using (var rep = new Repositorio<Cliente>())
            {
                return rep.context.Clientes.Include("Cidade").First(x => x.Id == id);
            }
        }

        public int ProximoCodigo()
        {
            try
            {
                return _rep.context.Clientes.Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
