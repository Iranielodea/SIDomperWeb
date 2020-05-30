namespace SIDomper.Dominio.Entidades
{
    public class ClienteModulo
    {
        public int Id { get; set; }
        public int ModuloId { get; set; }
        public int ClienteId { get; set; }
        public int? ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}