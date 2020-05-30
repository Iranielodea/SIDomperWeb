namespace SIDomper.Dominio.Entidades
{
    public class Parametro
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public int? Programa { get; set; }
        public string Observacao { get; set; }
    }

    public class ParametroConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public int? Programa { get; set; }
    }
}
