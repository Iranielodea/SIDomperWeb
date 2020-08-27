using System;

namespace SIDomper.Dominio.ViewModel
{
    public class RecadoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int UsuarioLctoId { get; set; }
        public int? Nivel { get; set; }
        public int? ClienteId { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public int UsuarioDestinoId { get; set; }
        public int? TipoId { get; set; }
        public int? StatusId { get; set; }
        public string DescricaoInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public TimeSpan? HoraFinal { get; set; }
        public string DescricaoFinal { get; set; }

        public int CodigoUsuarioLcto { get; set; }
        public string NomeUsuarioLancamento { get; set; }
        public int CodigoUsuarioDest { get; set; }
        public string NomeUsuarioDestino { get; set; }
        public int? CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public int CodigoTipo { get; set; }
        public string NomeTipo { get; set; }
        public int CodigoStatus { get; set; }
        public string NomeStatus { get; set; }
        public string ModoAbrEnc { get; set; }
    }

    public class RecadoConsultaViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string NomeUsuarioLancamento { get; set; }
        public string NomeUsuarioDestino { get; set; }
        public string Nivel { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone { get; set; }
        public string NomeStatus { get; set; }
    }

    public class RecadoFiltroViewModel
    {
        public string Campo { get; set; }
        public string Texto { get; set; }
        public int IdUsuario { get; set; }
        public bool Contem { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string DataInicialDest { get; set; }
        public string DataFinalDest { get; set; }
        public string IdUsuarioLcto { get; set; }
        public string IdUsuarioDestino { get; set; }
        public string IdCliente { get; set; }
        public string IdTipo { get; set; }
        public string IdStatus { get; set; }
        public bool UsuarioADM { get; set; }
    }

    public class RecadoQuadroViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string NomeUsuarioLcto { get; set; }
        public string Nivel { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone { get; set; }
        public string NomeUsuarioDestino { get; set; }
        public string Tempo { get; set; }
    }
}
