using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Observacao
    {
        public Observacao()
        {
            Ativo = true;
            Padrao = false;
            EmailPadrao = false;
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public int? Programa { get; set; }
        public bool Padrao { get; set; }
        public string ObsEmail { get; set; }
        public bool EmailPadrao { get; set; }
    }

    public class ObservacaoConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
