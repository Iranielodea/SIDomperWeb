using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.EF
{
    public class VersaoEF
    {
        private readonly Repositorio<Versao> _rep;

        public VersaoEF()
        {
            _rep = new Repositorio<Versao>();
        }

        public Versao ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Excluir(Versao model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Versao model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);
        }
    }
}
