using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Prospect
    {
        public Prospect()
        {
            Orcamentos = new List<Orcamento>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Docto { get; set; }
        public string Enquadramento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public int UsuarioId { get; set; }
        public int RevendaId { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Revenda Revenda { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
    }
}
