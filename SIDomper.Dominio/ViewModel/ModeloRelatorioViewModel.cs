namespace SIDomper.Dominio.ViewModel
{
    public class ModeloRelatorioViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public int? IdRevenda { get; set; }
        public int? CodigoRevenda { get; set; }
        public string NomeRevenda { get; set; }
    }

    public class ModeloRelatorioConsultaViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
