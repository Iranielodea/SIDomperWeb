using System;

namespace SIDomper.Dominio.ViewModel
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public string Contato { get; set; }
        public int Programa { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public string Motivo { get; set; }
        public int? VisitaId { get; set; }
        public int? AtividadeId { get; set; }
        public string NomeCliente { get; set; }
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoTipo { get; set; }
        public string NomeTipo { get; set; }
        public int CodigoStatus { get; set; }
        public string NomeStatus { get; set; }
    }

    public class AgendamentoConsultaViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string TipoNome { get; set; }
        public string UsuarioNome { get; set; }
        public string StatusNome { get; set; }
    }

    public class AgendamentoQuadroViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string UsuarioNome { get; set; }
        public string StatusNome { get; set; }
    }

    public class AgendamentoFiltroViewModel
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string IdUsuario { get; set; }
        public string IdCliente { get; set; }
        public string IdTipo { get; set; }
        public string IdStatus { get; set; }
    }
}
