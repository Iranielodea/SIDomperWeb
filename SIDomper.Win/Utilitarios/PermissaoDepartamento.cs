using SIDomper.Apresentacao.App;
using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Win.Utilitarios
{
    public static class PermissaoDepartamento
    {
        public static List<UsuarioPermissaoDepartamentoViewModel> Listar { get; set; }

        public static List<UsuarioPermissaoDepartamentoViewModel> ListaPermissaoDepartamentos(string userName, string senha)
        {
            var appUsuario = new UsuarioApp();
            return appUsuario.ObterPermissaoPorDepartamento(userName, senha).ToList();
        }
    }
}
