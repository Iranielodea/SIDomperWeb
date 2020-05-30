using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class EscalaEF
    {
        private readonly Repositorio<Escala> _rep;

        public EscalaEF()
        {
            _rep = new Repositorio<Escala>();
        }

        public Escala ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IEnumerable<Escala> ListarPorData(DateTime data)
        {
            return _rep.Get(x => x.Data == data);
        }

        public Escala ObterPorData(DateTime data)
        {
            return _rep.First(x => x.Data == data);
        }

        public void Salvar(Escala model)
        {
            if (model.Id == 0)
                _rep.Add(model);
        }

        public void Excluir(Escala model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }
    }
}
