using System.Collections.Generic;

namespace SIDomper.Dominio.ViewModel
{
    public class ChamadoQuadroViewModel : BaseViewModel
    {
        public List<QuadroViewModelChamado> Quadro1 { get; set; }
        public List<QuadroViewModelChamado> Quadro2 { get; set; }
        public List<QuadroViewModelChamado> Quadro3 { get; set; }
        public List<QuadroViewModelChamado> Quadro4 { get; set; }
        public List<QuadroViewModelChamado> Quadro5 { get; set; }
        public List<QuadroViewModelChamado> Quadro6 { get; set; }
        public string Titulo1 { get; set; }
        public string Titulo2 { get; set; }
        public string Titulo3 { get; set; }
        public string Titulo4 { get; set; }
        public string Titulo5 { get; set; }
        public string Titulo6 { get; set; }
        public int CodigoStatusQuadro1 { get; set; }
        public int CodigoStatusQuadro2 { get; set; }
        public int CodigoStatusQuadro3 { get; set; }
        public int CodigoStatusQuadro4 { get; set; }
        public int CodigoStatusQuadro5 { get; set; }
        public int CodigoStatusQuadro6 { get; set; }
        public int StatusChamadoAtendimentoCodigo { get; set; }
    }
}
