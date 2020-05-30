namespace SIDomper.Dominio.ViewModel
{
    public class ParametroViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public int? Programa { get; set; }
        public string Observacao { get; set; }
    }

    public class ParametroConsultaViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public int? Programa { get; set; }
    }
}
