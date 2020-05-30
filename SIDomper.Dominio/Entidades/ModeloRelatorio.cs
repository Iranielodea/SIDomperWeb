namespace SIDomper.Dominio.Entidades
{
    public class ModeloRelatorio
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public int? IdRevenda { get; set; }

        public virtual Revenda Revenda { get; set; }
    }

    public class ModeloRelatorioConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
