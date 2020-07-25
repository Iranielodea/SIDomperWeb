using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioTipo : RepositorioBaseEF<Tipo>, IRepositorioTipo
    {
        public RepositorioTipo(Contexto contexto) : base(contexto)
        {
        }

        public Tipo RetornarTipoAgendamento()
        {
            return base.First(x => x.Codigo == 30);
        }

        public Tipo RetornarUmRegistro(EnumChamado enumChamado)
        {
            var model = new Tipo();
            if (enumChamado == EnumChamado.Chamado)
                model = base.First(x => x.Programa == (int)EnTipos.Chamado && x.Ativo == true);
            else
                model = base.First(x => x.Programa == (int)EnTipos.Atividade && x.Ativo == true);

            return model;
        }

        public Tipo RetornarUmRegistroPrograma(EnTipos enTipos)
        {
            int tipo = (int)enTipos;
            return base.First(x => x.Programa == tipo && x.Ativo == true);
        }
    }
}
