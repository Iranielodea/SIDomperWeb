using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Infra.EF
{
    public static class ListasEstaticasEF
    {
        public static List<Parametro> ListarParametros()
        {
            var contexto = new DataBase.Contexto();
            return contexto.Parametros.ToList();
        }

        public static List<Usuario> ListarUsuarios()
        {
            var contexto = new DataBase.Contexto();
            return contexto.Usuarios.ToList();
        }
    }
}
