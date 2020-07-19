using SIDomper.Apresentacao.Comum;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Apresentacao.App
{
    public class TipoApp
    {
        public TipoViewModel Novo(int idUsuario)
        {
            string url = Constantes.URL + "tipo/Novo?idUsuario={0}";
            return new Operacao<TipoViewModel>().First(string.Format(url, idUsuario));
        }

        public TipoViewModel ObterPorId(int id)
        {
            string url = Constantes.URL + "tipo/ObterPorId?id={0}";
            return new Operacao<TipoViewModel>().First(string.Format(url, id));
        }

        public TipoViewModel Editar(int id, int idUsuario)
        {
            string url = Constantes.URL + "tipo/Editar?id={0}&idUsuario={1}";
            return new Operacao<TipoViewModel>().First(string.Format(url, id, idUsuario));
        }

        public TipoViewModel ObterPorCodigo(int codigo, EnTipos enTipos)
        {
            string url = Constantes.URL + "tipo/ObterPorCodigoTipo?codigo={0}&enTipos={1}";
            //string url = Constantes.URL + "tipo/?codigo={0}";
            return new Operacao<TipoViewModel>().First(string.Format(url, codigo, (int)enTipos));
        }

        public TipoConsultaViewModel[] Filtrar(string campo, string texto, EnTipos tipo, string ativo = "A", bool contem = true)
        {
            string sContem = "0";
            if (contem)
                sContem = "1";

            string url = Constantes.URL + "tipo/Filtrar?campo={0}&texto={1}&enTipos={2}&ativo={3}&contem={4}";
            string resultado = string.Format(url, campo, texto, (int)tipo, ativo, sContem);
            return new Operacao<TipoConsultaViewModel>().GetAll(resultado);
        }

        public TipoViewModel Salvar(TipoViewModel model)
        {
            string URI = Constantes.URL + "tipo";

            if (model.Id == 0)
                return new Operacao<TipoViewModel>().Insert(URI, model);
            else
                return new Operacao<TipoViewModel>().Update(URI, model);
        }

        public TipoViewModel Excluir(int id, int idUsuario)
        {
            string url = Constantes.URL + "tipo/{0}?idUsuario={1}";
            return new Operacao<TipoViewModel>().Delete(string.Format(url, id, idUsuario));
        }
    }
}
