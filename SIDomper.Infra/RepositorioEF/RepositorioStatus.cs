using System.Collections.Generic;
using System.Linq;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioStatus : RepositorioBaseEF<Status>, IRepositorioStatus
    {
        public RepositorioStatus(Contexto contexto) : base(contexto)
        {
        }

        public bool NotificarCliente(int statusId)
        {
            return base.GetAll().Any(x => x.Id == statusId && x.NotificarCliente);
        }

        public bool NotificarConsultor(int statusId)
        {
            return base.GetAll().Any(x => x.Id == statusId && x.NotificarConsultor);
        }

        public bool NotificarRevenda(int statusId)
        {
            return base.GetAll().Any(x => x.Id == statusId && x.NotificarRevenda);
        }

        public bool NotificarSupervisor(int statusId)
        {
            return base.GetAll().Any(x => x.Id == statusId && x.NotificarSupervisor);
        }

        public Status ObterPorCodigo(int codigo, EnStatus enStatus)
        {
            if (enStatus == EnStatus.Todos)
                return base.First(x => x.Codigo == codigo && x.Ativo == true);
            else
                return base.First(x => x.Codigo == codigo && x.Programa == (int)enStatus && x.Ativo == true);
        }

        public IEnumerable<Status> ObterPorPrograma(EnStatus enStatus)
        {
            return base.GetAll().Where(x => x.Programa == (int)enStatus);
        }
    }
}
