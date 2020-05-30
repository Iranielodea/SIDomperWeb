namespace SIDomper.Dominio.ViewModel
{
    public class CidadeViewModel : BaseViewModel
    {
        public CidadeViewModel()
        {
            Ativo = true;
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public bool Ativo { get; set; }
    }
}
