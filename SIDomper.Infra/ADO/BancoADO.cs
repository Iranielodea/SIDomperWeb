using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIDomper.Infra.ADO
{
    public class BancoADO : IDisposable
    {
        private readonly SqlConnection conexao;
        SqlDataReader dr;

        public BancoADO()
        {
            string conexaoSql = ConfigurationManager.ConnectionStrings["SIDomper"].ConnectionString;

            conexao = new SqlConnection(conexaoSql);
            AbrirConexao();
            //conexao.Open();
        }

        public void AbrirConexao()
        {
            if (conexao.State == ConnectionState.Closed)
                conexao.Open();
        }

        public SqlConnection RetornarConexao()
        {
            return conexao;
        }

        public void ExecutaComando(string strQuery)
        {
            var cmd = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ExecutaRetorno(string strQuery)
        {
            var cmd = new SqlCommand
            {
                CommandText = strQuery + "; SELECT CAST(scope_identity() AS int);",
                CommandType = CommandType.Text,
                Connection = conexao
            };

            try
            {
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RetornoReader(string strQry)
        {
            var cmd = new SqlCommand(strQry, conexao);
            cmd.CommandTimeout = 600;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RetornoReaderBool(string strQry)
        {
            var cmd = new SqlCommand(strQry, conexao);
            try
            {
                dr = cmd.ExecuteReader();
                return dr.Read();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public bool Read()
        {
            return dr.Read();
        }

        public void CloseReader()
        {
            dr.Close();
        }

        public int CampoInt(string valor)
        {
            try
            {
                return (Int32)dr[valor];
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int CampoInt32(string valor)
        {
            try
            {
                return Convert.ToInt32(dr[valor]);
            }
            catch
            {
                return 0;
            }
        }

        public string CampoStr(string valor)
        {
            try
            {
                return dr[valor].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool CampoBool(string valor)
        {
            try
            {
                return (bool)dr[valor];
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DateTime CampoData(string valor)
        {
            return Convert.ToDateTime(dr[valor]);
        }

        public string CampoHora(string valor)
        {
            string hora;
            hora = dr[valor].ToString();
            return hora.Substring(0, 5);
        }

        public Decimal CampoDecimal(string valor)
        {
            try
            {
                return Convert.ToDecimal(dr[valor]);
            }
            catch
            {
                return 0;
            }
        }
    }
}
