using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.ADO
{
    public class ClienteADO
    {
        public List<ClienteConsulta> Filtrar(int idUsuario, ClienteFiltro filtro, int modelo, string campo, string valor)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Cli_Id, Cli_Codigo, Cli_Nome, Cli_Fantasia, Cli_Dcto, Cli_Fone1, Cli_Enquadramento,");
            sb.AppendLine(" Usu_Nome, Rev_Nome");
            sb.AppendLine(" FROM Cliente");
            sb.AppendLine(" INNER JOIN Revenda ON Cli_Revenda = Rev_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Cli_Usuario = Usu_Id");
            sb.AppendLine(" WHERE Cli_Id IS NOT NULL");
            sb.AppendLine(" AND " + campo + " LIKE'%" + valor + "%'");

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

            if (!string.IsNullOrWhiteSpace(filtro.Versao))
                sb.AppendLine("  AND Cli_Versao = '" + filtro.Versao + "'");

            if (filtro.EmpresaVinculada == "S")
                sb.AppendLine("  AND Cli_EmpresaVinculada > 0");

            if (filtro.EmpresaVinculada == "N")
                sb.AppendLine(" AND ((Cli_EmpresaVinculada = 0) OR (Cli_EmpresaVinculada IS NULL))");

            if (modelo == 2)
            {
                if (filtro.ModuloId > 0)
                    sb.AppendLine(" AND CliMod_Modulo = " + filtro.ModuloId);

                if (filtro.ProdutoId > 0)
                    sb.AppendLine(" AND CliMod_Produto = " + filtro.ProdutoId);
            }
            else
            {
                if (filtro.ModuloId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Modulo = " + filtro.ModuloId + ")");
                }

                if (filtro.ProdutoId > 0)
                {
                    sb.AppendLine(" AND EXISTS(SELECT 1 FROM Cliente_Modulo ");
                    sb.AppendLine(" WHERE Cli_Id = CliMod_Cliente ");
                    sb.AppendLine("  AND CliMod_Produto = " + filtro.ProdutoId + ")");
                }
            }

            var lista = new List<ClienteConsulta>();

            using (var db = new BancoADO())
            {
                db.RetornoReader(sb.ToString());
                
                while (db.Read())
                {
                    var model = new ClienteConsulta
                    {
                        Documento = db.CampoStr("Cli_Dcto"),
                        Enquadramento = db.CampoStr("Cli_Enquadramento"),
                        Fantasia = db.CampoStr("Cli_Fantasia"),
                        Id = db.CampoInt32("Cli_Id"),
                        NomeConsultor = db.CampoStr("Usu_Nome"),
                        NomeRevenda = db.CampoStr("Rev_Nome"),
                        Razao = db.CampoStr("Cli_Nome"),
                        Telefone = db.CampoStr("Cli_Fone1"),
                        Versao = db.CampoStr("Cli_Versao")
                    };
                    lista.Add(model);
                }
                db.CloseReader();
            }
            return lista;
        }

        public List<Cliente> Listar(int idUsuario, string nome)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT");
            sb.AppendLine(" Cli_Id, Cli_Nome");
            sb.AppendLine(" FROM Cliente");
            sb.AppendLine(" INNER JOIN Revenda ON Cli_Revenda = Rev_Id");
            sb.AppendLine(" LEFT JOIN Usuario ON Cli_Usuario = Usu_Id");
            sb.AppendLine(" WHERE Cli_Id IS NOT NULL");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");
            sb.AppendLine(" AND Cli_Ativo = 1");

            sb.AppendLine(" AND Cli_Nome like '%" + nome + "%'");
            sb.AppendLine(" ORDER BY Cli_Nome");

            var lista = new List<Cliente>();

            using (var db = new BancoADO())
            {
                db.RetornoReader(sb.ToString());

                lista.Add(PreencherLista(lista, 0, ""));

                while (db.Read())
                {
                    lista.Add(PreencherLista(lista, db.CampoInt32("Cli_Id"), db.CampoStr("Cli_Nome")));
                }

                db.CloseReader();
            }
            return lista;
        }

        public void Salvar(Cliente model)
        {
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE Cliente SET");
            sb.AppendLine(" Cli_Versao = '" + model.Versao + "'");
            sb.AppendLine(" ,Cli_Latitude = '" + model.Latitude + "'");
            sb.AppendLine(" ,Cli_Longitude = '" + model.Longitude + "'");
            sb.AppendLine(" WHERE Cli_Id = " + model.Id);

            using (var db = new BancoADO())
            {
                db.ExecutaComando(sb.ToString());
            }
        }

        public void AtualizarVersao(int idCliente, string versao)
        {
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE Cliente SET");
            sb.AppendLine(" Cli_Versao = '" + versao + "'");
            sb.AppendLine(" WHERE Cli_Id = " + idCliente);

            using (var db = new BancoADO())
            {
                db.ExecutaComando(sb.ToString());
            }
        }

        private Cliente PreencherLista(List<Cliente> lista, int id, string nome)
        {
            var model = new Cliente { Id = id, Nome = nome, };
            return model;
        }
    }
}
