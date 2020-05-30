using SIDomper.Dominio.Entidades;
using System.Collections.Generic;

namespace SIDomper.Dominio.ViewModel
{
    public class VisitaViewModel
    {
        public VisitaViewModel()
        {
            Visita Visita = new Visita();
            Usuario Usuario = new Usuario();
            Cliente Cliente = new Cliente();
            Tipo Tipo = new Tipo();
            Status Status = new Status();
            Filtro = new VisitaFiltro();
            VisitaConsulta = new VisitaConsulta();
            ListaConsulta = new List<VisitaConsulta>();
            Campos = new List<VisitaCamposPesquisaViewModel>();
        }
        public VisitaConsulta VisitaConsulta { get; set; }
        public Visita Visita { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public Tipo Tipo { get; set; }
        public Status Status { get; set; }
        public string Campo { get; set; }
        public string Texto { get; set; }
        public VisitaFiltro Filtro { get; set; }
        public ICollection<VisitaConsulta> ListaConsulta {get; set; }
        public List<VisitaCamposPesquisaViewModel> Campos { get; set; }
    }

    public class VisitaCamposPesquisaViewModel
    {
        public string Campo { get; set; }
        public string Descricao { get; set; }
    }
}
