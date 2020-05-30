using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class UsuarioApp
    {
        public UsuarioViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "usuario?novo={0}&idUsuario={1}";
            return new Operacao<UsuarioViewModel>().First(string.Format(url, "", idUsuario));
        }

        public UsuarioPermissaoDepartamentoViewModel[] ObterPermissaoPorDepartamento(string userName, string senha)
        {
            string url = Constantes.URL + "/Usuario?userName={0}&senha={1}&permissaoDep={2}";
            return new Operacao<UsuarioPermissaoDepartamentoViewModel>().GetAll(string.Format(url, userName, senha, "A"));
        }

        public UsuarioViewModel ObterPorId(int id)
        {
            //string url = Constantes.URL + "usuario/{0}?idUsuario={1}";
            string url = Constantes.URL + "usuario/{0}";
            return new Operacao<UsuarioViewModel>().First(string.Format(url, id));
        }

        public UsuarioViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "usuario/{0}?idUsuario={1}";
            return new Operacao<UsuarioViewModel>().First(string.Format(url, id, idUsuario));
        }

        public UsuarioViewModel ObterPorCodigo(int codigo)
        {
            string url = Constantes.URL + "usuario/?codigo={0}";
            return new Operacao<UsuarioViewModel>().First(string.Format(url, codigo));
        }

        public UsuarioViewModel ObterPorUsuario(string userName, string senha)
        {
            string url = Constantes.URL + "Usuario?login={0}&senha={1}";
            return new Operacao<UsuarioViewModel>().First(string.Format(url, userName, senha));
        }

        //public UsuarioConsultaViewModel[] Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        //{
        //    string url = Constantes.URL + "Usuario?campo={0}&texto={1}&ativo={2}&contem={3}";
        //    return new Operacao<UsuarioConsultaViewModel>().GetAll(string.Format(url, campo, texto, ativo, contem));
        //}

        public UsuarioViewModel Salvar(UsuarioViewModel model)
        {
            string URI = Constantes.URL + "usuario";

            if (model.Id == 0)
                return new Operacao<UsuarioViewModel>().Insert(URI, model);
            else
                return new Operacao<UsuarioViewModel>().Update(URI, model);
        }

        public UsuarioViewModel Excluir(int id, int idUsuario)
        {            
            string url = Constantes.URL + "usuario/{0}?idUsuario={1}";
            return new Operacao<UsuarioViewModel>().Delete(string.Format(url, id, idUsuario));
        }

        public UsuarioConsultaViewModel[] Filtrar(UsuarioFiltroViewModel filtro)
        {            
            string url = Constantes.URL + "usuario?pesquisar={0}";
            return new Operacao<UsuarioConsultaViewModel>().ObjetoToJSon(string.Format(url, ""), filtro);
        }
    }
}
