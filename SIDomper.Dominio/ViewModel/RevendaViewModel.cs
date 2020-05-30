using System.Collections.Generic;

namespace SIDomper.Dominio.ViewModel
{
    public class RevendaViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<RevendaEmailViewModel> RevendaEmails { get; set; }
    }

    public class RevendaConsultaViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }

    public class RevendaEmailViewModel
    {
        public int Id { get; set; }
        public int RevendaId { get; set; }
        public string Email { get; set; }
        public virtual RevendaViewModel RevendaViewModel { get; set; }
    }
}
