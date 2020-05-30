using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class ChamadoOcorrencia
    {
        public ChamadoOcorrencia()
        {
            ChamadoOcorrenciaColaboradores = new List<ChamadoOcorrenciaColaborador>();
        }

        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public string Documento { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int UsuarioId { get; set; }
        public int? UsuarioColab1 { get; set; }
        public int? UsuarioColab2 { get; set; }
        public int? UsuarioColab3 { get; set; }
        public string DescricaoTecnica { get; set; }
        public string DescricaoSolucao { get; set; }
        public string Anexo { get; set; }
        public double TotalHoras { get; set; }
        public string Versao { get; set; }

        public virtual Chamado Chamado { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ChamadoOcorrenciaColaborador> ChamadoOcorrenciaColaboradores { get; set; }

        /*
         para converter RichText para string sem formatação

        System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

        private void dataGridView1_CellFormatting(object sender,
                System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("NomeDaColuna"))
            {
                rtBox.Rtf = e.Value;
                e.Value = rtBox.Text;
                {
                }*/

    }

    public class ChamadoOcorrenciaConsulta
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int UsuarioId { get; set; }
        public int CodUsuario { get; set; }
        public string NomeUsuario { get; set; }
    }

    public class ProblemaSolucao
    {
        public int Id { get; set; }
        public int IdChamado { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string DescricaoSolucao { get; set; }
        public string DescricaoTecnica { get; set; }
        public string NomeUsuario { get; set; }
    }
}
