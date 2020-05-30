using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.EF
{
    public class RecadoEF
    {
        private readonly Repositorio<Recado> _rep;

        public RecadoEF()
        {
            _rep = new Repositorio<Recado>();
        }

        public Recado ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Excluir(Recado model)
        {
            _rep.Deletar(model);
        }

        public void Salvar(Recado model)
        {
            _rep.AddUpdate(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
