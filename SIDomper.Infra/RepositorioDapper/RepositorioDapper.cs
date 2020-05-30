using Dapper;
using SIDomper.Dominio.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIDomper.Infra.RepositorioDapper
{
    public class RepositorioDapper<T> : IRepositoryReadOnly<T> where T : class 
    {
        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["SIDomper"].ConnectionString);
            }
        }

        public IEnumerable<T> GetAll(string instrucaoSql)
        {
            IDbConnection cn = Connection;
            try
            {
                cn.Open();
                return cn.Query<T>(instrucaoSql);
            }
            finally
            {
                cn.Close(); 
            }
        }
    }
}
