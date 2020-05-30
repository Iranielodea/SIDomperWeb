using System.Collections.Generic;

namespace SIDomper.Dominio.Entidades
{
    public class Revenda
    {
        public Revenda()
        {
            RevendaEmails = new List<RevendaEmail>();
            Usuarios = new List<Usuario>();
            Clientes = new List<Cliente>();
            Prospects = new List<Prospect>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<RevendaEmail> RevendaEmails { get; set; }
        public virtual ICollection<Cliente> Clientes{ get; set; }
        public virtual ICollection<Prospect> Prospects { get; set; }
    }

    public class RevendaConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
