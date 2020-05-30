using System;

namespace SIDomper.Dominio.ViewModel
{
    public class FeriadoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
