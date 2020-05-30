using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class EscalaServico
    {
        private readonly EscalaEF _rep;

        public EscalaServico()
        {
            _rep = new EscalaEF();
        }

        public Escala ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<Escala> ListarPorData(DateTime data)
        {
            return _rep.ListarPorData(data);
        }

        public Escala ObterPorData(DateTime data)
        {
            return _rep.ObterPorData(data);
        }

        public void Salvar(Escala model)
        {
            double HoraInicio = Funcoes.Horas.HoraToDecimal(model.HoraInicio.ToString());
            double HoraFim = Funcoes.Horas.HoraToDecimal(model.HoraFim.ToString());
            model.TotalHoras = HoraFim - HoraInicio;

            _rep.Salvar(model);
            _rep.Commit();
        }

        public void Excluir(Escala model)
        {
            _rep.Excluir(model);
            _rep.Commit();
        }
    }
}
