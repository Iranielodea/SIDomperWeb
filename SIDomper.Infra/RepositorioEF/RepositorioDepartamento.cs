using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioDepartamento : RepositorioBaseEF<Departamento>, IRepositorioDepartamento
    {
        private readonly Contexto _contexto;

        public RepositorioDepartamento(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Departamento Duplicar(Departamento model)
        {
            var modelTemp = _contexto.Departamentos.First(x => x.Id == model.Id);
            modelTemp.Id = 0;
            modelTemp.Nome = model.Nome + "01";

            //=================================================================
            // email
            var Email = _contexto.DepartamentoEmails.AsNoTracking().Where(x => x.DepartamentoId == model.Id).ToList();

            foreach (var item in Email)
            {
                item.Departamento = modelTemp;
                item.Id = 0;
                _contexto.DepartamentoEmails.Add(item);
            }

            //=================================================================
            // Acesso

            var Acesso = _contexto.DepartamentoAcessos.AsNoTracking().Where(x => x.DepartamentoId == model.Id).ToList();
            foreach (var item in Acesso)
            {
                item.Departamento = modelTemp;
                item.Id = 0;
                _contexto.DepartamentoAcessos.Add(item);
            }

            Salvar(modelTemp);

            return modelTemp;
        }
    }
}
