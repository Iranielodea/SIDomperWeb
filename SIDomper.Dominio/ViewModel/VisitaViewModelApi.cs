using System;

namespace SIDomper.Dominio.ViewModel
{
    public class VisitaViewModelApi : BaseViewModel
    {
        public int Id { get; set; }
        public string Dcto { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string Contato { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public string Anexo { get; set; }
        public double TotalHoras { get; set; }
        public string FormaPagto { get; set; }
        public decimal Valor { get; set; }
        public string Versao { get; set; }

        public int CodUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int CodCliente { get; set; }
        public string NomeCliente { get; set; }
        public int CodTipo { get; set; }
        public string NomeTipo { get; set; }
        public int CodStatus { get; set; }
        public string NomeStatus { get; set; }
        public DateTime? DataAgendamento { get; set; }
        public string DescricaoAgendamento { get; set; }
    }

    public class VisitaConsultaViewModelApi
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Documento { get; set; }
        public string NomeCliente { get; set; }
        public string NomeFantasia { get; set; }
        public string NomeConsultor { get; set; }
    }

    public class VisitaFiltroViewModelApi
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
        public string Campo { get; set; }
        public string Texto { get; set; }
    }
}
