using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class FormaPagto
    {
        public FormaPagto()
        {
            FormaPagtoItens = new List<FormaPagtoItens>();
            Orcamentos = new List<Orcamento>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<FormaPagtoItens> FormaPagtoItens { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
    }
}
