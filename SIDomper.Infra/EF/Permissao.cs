using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class Permissao
    {
        public bool PermissaoUsuario(int idUsuario, int programa, string tipo)
        {
            var idUsuarioPar = new SqlParameter
            {
                ParameterName = "IdUsuario",
                Value = idUsuario
            };

            var programaPar = new SqlParameter
            {
                ParameterName = "Programa",
                Value = programa
            };

            var tipoPermissaoPar = new SqlParameter
            {
                ParameterName = "TipoPermissao",
                Value = tipo
            };

            var retornoPar = new SqlParameter
            {
                ParameterName = "Retorno",
                Value = 0,
                Direction = System.Data.ParameterDirection.Output
            };

            var ctx = new Contexto();
            var resultado = ctx.Database.SqlQuery<Usuario>("Departamento_sp_Permissao @IdUsuario, @Programa, @TipoPermissao, @Retorno out",
                idUsuarioPar,
                programaPar,
                tipoPermissaoPar,
                retornoPar);

            var res = (int)retornoPar.Value;

            return (res == 1);

            //var res = (bool)retornoPar.Value;

            //return res;
        }
    }
}
