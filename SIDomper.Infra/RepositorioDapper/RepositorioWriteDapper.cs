using Dapper;
using SIDomper.Dominio.Interfaces;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIDomper.Infra.RepositorioDapper
{
    public class RepositorioWriteDapper : IRepositoryWriteOnly
    {
        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["SIDomper"].ConnectionString);
            }
        }

        public int Insert(string instrucaoSql, object entity)
        {
            try
            {
                Connection.Open();
                int id = Connection.ExecuteScalar<int>(instrucaoSql, entity);
                return id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public void Update(string instrucaoSql, object entity)
        {
            try
            {
                Connection.Open();
                Connection.Execute(instrucaoSql, entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        // exemplo:
        //public T Insert(string instrucaoSql)
        //{

        //    string insertUserSql = @"INSERT INTO dbo.[User](Username, Phone, Email)
        //                VALUES(@Username, @Phone, @Email); SELECT CAST(SCOPE_IDENTITY() as int)";

        //    Connection.ExecuteScalar<T>(insertUserSql new { })
        //}
    }
}
