using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.EF
{
    public class PlanoBackupItemEF
    {
        private readonly Repositorio<PlanoBackupItem> _rep;

        public PlanoBackupItemEF()
        {
            _rep = new Repositorio<PlanoBackupItem>();
        }

        public PlanoBackupItem ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Salvar(PlanoBackupItem model)
        {
            if (model.Id == 0)
                _rep.Add(model);
        }

        public void Excluir(PlanoBackupItem model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
