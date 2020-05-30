using System.Collections.Generic;

namespace SIDomper.Dominio.ViewModel
{
    public class RamalViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Departamento { get; set; }

        public virtual ICollection<RamalItensViewModel> RamalItens { get; set; }
    }

    public class RamalConsultaViewModel
    {
        public int Id { get; set; }
        public string Departamento { get; set; }
    }

    public class RamalItensViewModel
    {
        public int Id { get; set; }
        public int RamalId { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
    }
}
