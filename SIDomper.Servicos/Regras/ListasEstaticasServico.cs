using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Servicos.Regras
{
    public static class ListasEstaticasServico
    {
        public static int IdUsuario { get; set; }

        private static List<Parametro> _parametros;
        private static List<Usuario> _usuarios;

        public static List<Parametro> ListarParametros()
        {
            if (_parametros == null)
            {
                _parametros = Infra.EF.ListasEstaticasEF.ListarParametros();
            }
            return _parametros;
        }

        public static List<Usuario> ListarUsuarios()
        {
            if (_usuarios == null)
            {
                _usuarios = Infra.EF.ListasEstaticasEF.ListarUsuarios();
            }
            return _usuarios;
        }

        public static bool Permissoes(int idUsuario, Dominio.Enumeracao.EnProgramas programa, Dominio.Enumeracao.EnTipoManutencao tipoManutencao)
        {
            //ListarUsuarios();

            int tipo = (int)tipoManutencao;
            int _programa = (int)programa;

            bool result = true;

            var lista = _usuarios.Find(x => x.Id == idUsuario);

            foreach (var dep in lista.Departamento.DepartamentoAcessos)
            {
                if (dep.Programa == _programa)
                {
                    switch (tipo)
                    {
                        case 1:
                            result = dep.Acesso;
                            break;
                        case 2:
                            result = dep.Incluir;
                            break;
                        case 3:
                            result = dep.Editar;
                            break;
                        case 4:
                            result = dep.Excluir;
                            break;
                        case 5:
                            result = dep.Relatorio;
                            break;
                    }
                }
            }
            return result;
        }

        public static bool PermissaoUsuarioSiglas(string sigla, int idUsuario)
        {
            ListarUsuarios();

            bool result = false;

            var lista = _usuarios.Find(x => x.Id == idUsuario);

            foreach (var item in lista.UsuariosPermissao)
            {
                if (item.Sigla == sigla)
                    result = true;
            }

            return result;
        }
    }
}
