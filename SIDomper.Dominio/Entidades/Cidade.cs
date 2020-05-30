using System.Collections.Generic;

namespace SIDomper.Dominio.Entidades
{
    public class Cidade
    {
        public Cidade()
        {
            Clientes = new List<Cliente>();
            Orcamentos = new List<Orcamento>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
    }

    public class CidadeConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
    }
}
