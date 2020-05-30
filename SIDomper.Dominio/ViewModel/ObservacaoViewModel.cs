namespace SIDomper.Dominio.ViewModel
{
    public class ObservacaoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public int? Programa { get; set; }
        public bool Padrao { get; set; }
        public string ObsEmail { get; set; }
        public bool EmailPadrao { get; set; }
    }

    public class ObservacaoConsultaViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
