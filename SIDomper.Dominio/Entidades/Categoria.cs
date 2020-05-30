using System.Collections;
using System.Collections.Generic;

namespace SIDomper.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria()
        {
            Solicitacoes = new List<Solicitacao>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
    }

    public class CategoriaConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
