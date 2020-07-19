using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.ADO
{
    public class DepartamentoPermissaoADO
    {
        private SqlConnection conexao;

        public bool PermissaoUsuario(int idUsuario, int programa, string tipo)
        {
            var db = new BancoADO();
            try
            {
                conexao = db.RetornarConexao();

                db.Dispose();

                var cmd = new SqlCommand("Departamento_sp_Permissao", conexao);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
                cmd.Parameters.Add("@Programa", SqlDbType.Int);
                cmd.Parameters.Add("@TipoPermissao", SqlDbType.VarChar, 1);
                cmd.Parameters.Add("@Retorno", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.Parameters["@IdUsuario"].Value = idUsuario;
                cmd.Parameters["@Programa"].Value = programa;
                cmd.Parameters["@TipoPermissao"].Value = tipo;

                conexao.Close();
                conexao.Open();

                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(cmd.Parameters["@Retorno"].Value);
                conexao.Close();

                return (valor == 1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                db.Dispose();
                conexao.Close();
            }
        }
    }
}
