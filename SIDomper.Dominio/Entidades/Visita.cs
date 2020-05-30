using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDomper.Dominio.Entidades
{
    public class Visita
    {
        public int Id { get; set; }

        [DisplayName("Documento")]
        public string Dcto { get; set; }

        [Required(ErrorMessage = "Informe a Data!")]
        public DateTime Data { get; set; }

        [DisplayName("Hora Início")]
        public TimeSpan HoraInicio { get; set; }

        [DisplayName("Hora Final")]
        public TimeSpan HoraFim { get; set; }

        [Required(ErrorMessage = "Informe o Cliente!")]
        public int ClienteId { get; set; }

        public int UsuarioId { get; set; }

        public string Contato { get; set; }

        [Required(ErrorMessage = "Informe o Tipo!")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "Informe o Status!")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Informe Descrição!")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public string Anexo { get; set; }

        public double TotalHoras { get; set; }

        [DisplayName("Forma de Pagto")]
        public string FormaPagto { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal Valor { get; set; }

        [DisplayName("Versão")]
        public string Versao { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Status Status { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }

        [NotMapped]
        public List<Tipo> ListaTipos { get; set; }
        [NotMapped]
        public List<Status> ListaStatus { get; set; }
        [NotMapped]
        public List<Cliente> ListaClientes { get; set; }
        [NotMapped]
        public List<Usuario> ListaUsuarios { get; set; }
    }

    public class VisitaConsulta
    {
        public int Id { get; set; }

        public DateTime DataD { get; set; }
        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        //public string Data { get; set; }

        public string Documento { get; set; }

        [DisplayName("Cliente")]
        public string NomeCliente { get; set; }

        [DisplayName("Fantasia")]
        public string NomeFantasia { get; set; }

        [DisplayName("Consultor")]
        public string NomeConsultor { get; set; }
    }

    public class VisitaFiltro
    {
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        public string DataInicial { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public string DataFinal { get; set; }

        public int ClienteId { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public int UsuarioId { get; set; }
        public int RevendaId { get; set; }
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
    }

    public class VisitaFiltroAPI
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string ClienteId { get; set; }
        public string TipoId { get; set; }
        public string StatusId { get; set; }
        public string UsuarioId { get; set; }
        public string RevendaId { get; set; }
        public string CidadeId { get; set; }
        public string Perfil { get; set; }
        public int Id { get; set; }
    }
}
