using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class Solicitacao
    {
        public Solicitacao()
        {
            SolicitacaoCronogramas = new List<SolicitacaoCronograma>();
            SolicitacaoOcorrencias = new List<SolicitacaoOcorrencia>();
            SolicitacaoStatus = new List<SolicitacaoStatus>();

            Data = DateTime.Now;
            Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            Nivel = 2;
        }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioAberturaId { get; set; }
        public int? ModuloId { get; set; }
        public int? ProdutoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? Nivel { get; set; }
        public string Versao { get; set; }
        public string Anexo { get; set; }
        public int? AnalistaId { get; set; }
        public int StatusId { get; set; }
        public int? TipoId { get; set; }
        public decimal? TempoPrevisto { get; set; }
        public DateTime? PrevisaoEntrega { get; set; }
        public int? DesenvolvedorId { get; set; }
        public string DescricaoLiberacao { get; set; }
        public int? UsuarioAtendeAtualId { get; set; }
        public string Contato { get; set; }
        public int? VersaoId { get; set; }
        public int? CategoriaId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario UsuarioAbertura { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Usuario UsuarioAnalista { get; set; }
        public virtual Status Status { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Usuario UsuarioDesenvolvedor { get; set; }
        public virtual Usuario UsuarioAtendeAtual { get; set; }
        public virtual Versao VersaoRelacao { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<SolicitacaoCronograma> SolicitacaoCronogramas { get; set; }
        public virtual ICollection<SolicitacaoOcorrencia> SolicitacaoOcorrencias { get; set; }
        public virtual ICollection<SolicitacaoStatus> SolicitacaoStatus { get; set; }
    }

    //public class SolicitacaoFiltro
    //{
    //    public int Id { get; set; }
    //    public string DataInicial { get; set; }
    //    public string DataFinal { get; set; }
    //    public string IdUsuarioAbertura { get; set; }
    //    public string IdCliente { get; set; }
    //    public string IdModulo { get; set; }
    //    public string IdProduto { get; set; }
    //    public string IdAnalista { get; set; }
    //    public string IdTipo { get; set; }
    //    public string IdDesenvolvedor { get; set; }
    //    public string IdOperador { get; set; }
    //    public string IdStatus { get; set; }
    //    public string Nivel { get; set; }
    //    public string IdVersao { get; set; }
    //    //public ClienteFiltro ClienteFiltro { get; set; }
    //}

    public class SolicitacaoConsulta
    {
        public int Id { get; set; }
        public string Versao { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Titulo { get; set; }
        public string Nivel { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Statusnome { get; set; }
        public int ClienteCodigo { get; set; }
        public string TipoNome { get; set; }
    }

    public class QuadroSolicitacao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int IdUsuarioAtendeAtual { get; set; }
        public string ClienteNome { get; set; }
        public string UsuarioNome { get; set; }
        public int IdStatus { get; set; }
        public int Nivel { get; set; }
        public String Quadro { get; set; }
    }
}
