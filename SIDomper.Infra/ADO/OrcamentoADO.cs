using SIDomper.Dominio.Entidades;
using SIDomper.Infra.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.ADO
{
    public class OrcamentoADO
    {
        public List<OrcamentoConsulta> Filtrar(int idUsuario, OrcamentoFiltro filtro, string campo, string texto)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("Orc_Data,");
            sb.AppendLine("Orc_Id,");
            sb.AppendLine("Orc_Numero,");
            sb.AppendLine("Orc_Situacao,");
            sb.AppendLine("Orc_RazaoSocial,");
            sb.AppendLine("Orc_EmailEnviado,");
            sb.AppendLine("Pros_Nome, ");
            sb.AppendLine("Usu_Nome, ");
            sb.AppendLine("Cli_Codigo, ");
            sb.AppendLine("Cli_Nome ");
            sb.AppendLine("FROM Orcamento");
            sb.AppendLine("LEFT JOIN Prospect ON Orc_Prospect = Pros_Id   ");
            sb.AppendLine("LEFT JOIN Usuario ON Orc_Usuario = Usu_Id   ");
            sb.AppendLine("LEFT JOIN Cliente ON Orc_Cliente = Cli_Id   ");
            sb.AppendLine("LEFT JOIN Cidade ON Orc_Cidade = Cid_Id   ");
            sb.AppendLine("LEFT JOIN Tipo ON Orc_Tipo = Tip_Id ");
            sb.AppendLine(" WHERE Orc_Id IS NOT NULL");
            sb.AppendLine(" AND " + campo + " like '%" + texto + "%'");

            sb.AppendLine(Filtro(idUsuario, filtro));

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            if (!PermissaoOrcamentoUsuario(idUsuario))
                sb.AppendLine(" AND Orc_Usuario = " + idUsuario);

            var lista = new List<OrcamentoConsulta>();
            using (var db = new BancoADO())
            {
                db.RetornoReader(sb.ToString());

                while (db.Read())
                {
                    var model = new OrcamentoConsulta();

                    string emailEnviado = "Não";
                    if (db.CampoBool("Orc_EmailEnviado"))
                        emailEnviado = "Sim";

                    model.EmailEnviado = emailEnviado;
                    model.Data = db.CampoData("Orc_Data").ToString("dd/MM/yyyy");
                    model.NomeCliente = db.CampoStr("Cli_Nome");
                    model.NomeUsuario = db.CampoStr("Usu_Nome");
                    model.Numero = db.CampoInt32("Orc_Numero");
                    model.Id = db.CampoInt32("Orc_Id");
                    model.Situacao = db.CampoStr("Orc_Situacao");

                    lista.Add(model);
                }
                db.CloseReader();
            }
            return lista;
        }

        private string Filtro(int idUsuario, OrcamentoFiltro filtro)
        {
            var sb = new StringBuilder();

            if (filtro.DataInicial != null)
                sb.AppendLine(" AND Orc_Data >= " + Funcoes.DataIngles(filtro.DataInicial));
            if (filtro.DataFinal != null)
                sb.AppendLine(" AND Orc_Data <= " + Funcoes.DataIngles(filtro.DataFinal));
            if (filtro.DataSituacaoInicial != null)
                sb.AppendLine(" AND Orc_DataSituacao >= " + Funcoes.DataIngles(filtro.DataSituacaoInicial));
            if (filtro.DataSituacaoFinal != null)
                sb.AppendLine(" AND Orc_DataSituacao <= " + Funcoes.DataIngles(filtro.DataSituacaoFinal));
            if (filtro.CidadeId > 0)
                sb.AppendLine(" AND Orc_Cidade = " + filtro.CidadeId);
            if (filtro.ClienteId > 0)
                sb.AppendLine(" AND Orc_Cliente <= " + filtro.ClienteId);
            if (filtro.EmailEnviado == "S")
                sb.AppendLine(" AND Orc_EmailEnviado = 1");
            if (filtro.EmailEnviado == "N")
                sb.AppendLine(" AND Orc_EmailEnviado = 0");
            if (filtro.Situacao > 0)
                sb.AppendLine(" AND Orc_Situacao = " + filtro.Situacao);
            if (filtro.SubTipo > 0)
                sb.AppendLine(" AND Orc_SubTipo = " + filtro.SubTipo);
            if (filtro.TipoId > 0)
                sb.AppendLine(" AND Orc_Tipo = " + filtro.TipoId);
            if (filtro.UsuarioId > 0)
                sb.AppendLine(" AND Orc_Usuario = " + filtro.UsuarioId);
            if (filtro.Numero > 0)
                sb.AppendLine(" AND Orc_Numero = " + filtro.Numero);

            return sb.ToString();
        }

        private bool PermissaoOrcamentoUsuario(int idUsuario)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT UsuP_Id, Usu_Adm ");
            sb.AppendLine("FROM Usuario_Permissao");
            sb.AppendLine("INNER JOIN Usuario ON UsuP_Usuario = Usu_Id");
            sb.AppendLine("WHERE UsuP_Usuario = " + idUsuario);
            sb.AppendLine("AND UsuP_Sigla = 'Lib_Orcamento_Usuario'");

            int adm = 0;
            int id = 0;

            using (var db = new BancoADO())
            {
                db.RetornoReader(sb.ToString());
                if (db.Read())
                {
                    adm = db.CampoInt32("Usu_Adm");
                    id = db.CampoInt32("UsuP_Id");
                }
                db.CloseReader();
            }

            if (adm == 1)
                return true;

            return (id > 0);
        }
    }
}
