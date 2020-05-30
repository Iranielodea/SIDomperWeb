namespace SIDomper.Dominio.Entidades
{
    public class OrcamentoItemModulo
    {
        public int Id { get; set; }
        public int OrcamentoItemId { get; set; }
        public int ModuloId { get; set; }
        public string Descricao { get; set; }

        public virtual OrcamentoItem  OrcamentoItem { get; set; }
        public virtual Modulo Modulo { get; set; }
    }
}
