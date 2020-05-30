namespace SIDomper.Dominio.Entidades
{
    public class OrcamentoEmail
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public string Email { get; set; }

        public virtual Orcamento Orcamento { get; set; }
    }
}
