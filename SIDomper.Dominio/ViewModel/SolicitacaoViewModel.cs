using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.ViewModel
{
    public class SolicitacaoViewModel : BaseViewModel
    {
        public SolicitacaoViewModel()
        {
            SolicitacaoCronogramas = new List<SolicitacaoCronogramaViewModel>();
            SolicitacaoOcorrencias = new List<SolicitacaoOcorrenciaViewModel>();
            SolicitacaoStatus = new List<SolicitacaoStatusViewModel>();
            SolicitacaoPermissaoViewModel = new SolicitacaoPermissaoViewModel();
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

        public int ClienteCodigo { get; set; }
        public string ClienteNome { get; set; }
        public int UsuarioAberturaCodigo { get; set; }
        public string UsuarioAberturaNome { get; set; }
        public int? ModuloCodigo { get; set; }
        public string ModuloNome { get; set; }
        public int? ProdutoCodigo { get; set; }
        public string ProdutoNome { get; set; }
        public int? AnalistaCodigo { get; set; }
        public string AnalistaNome { get; set; }
        public int StatusCodigo { get; set; }
        public string StatusNome { get; set; }
        public int? TipoCodigo { get; set; }
        public string TipoNome { get; set; }
        public int? DesenvolvedorCodigo { get; set; }
        public string DesenvolvedorNome { get; set; }
        public string VersaoDescricao { get; set; }
        public int? CategoriaCodigo { get; set; }
        public string CategoriaNome { get; set; }

        public virtual SolicitacaoPermissaoViewModel SolicitacaoPermissaoViewModel { get; set; }
        public virtual ICollection<SolicitacaoCronogramaViewModel> SolicitacaoCronogramas { get; set; }
        public virtual ICollection<SolicitacaoOcorrenciaViewModel> SolicitacaoOcorrencias { get; set; }
        public virtual ICollection<SolicitacaoStatusViewModel> SolicitacaoStatus { get; set; }

        public int CronogramaRetornarMenorId()
        {
            try
            {
                int id = SolicitacaoCronogramas.Min(x => x.Id);
                if (id > 0)
                    id = 0;
                id--;
                return id;
            }
            catch
            {
                return -1;
            }
        }

        public int OcorrenciaRetornarMenorId()
        {
            try
            {
                int id = SolicitacaoOcorrencias.Min(x => x.Id);
                if (id > 0)
                    id = 0;
                id--;
                return id;
            }
            catch
            {
                return -1;
            }
        }
    }

    public class SolicitacaoFiltroViewModel
    {
        public int Id { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string IdUsuarioAbertura { get; set; }
        public string IdCliente { get; set; }
        public string IdModulo { get; set; }
        public string IdProduto { get; set; }
        public string IdAnalista { get; set; }
        public string IdTipo { get; set; }
        public string IdDesenvolvedor { get; set; }
        public string IdOperador { get; set; }
        public string IdStatus { get; set; }
        public string Nivel { get; set; }
        public string IdVersao { get; set; }
    }

    public class SolicitacaoConsultaViewModel
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

    public class SolicitacaoQuadroViewModel : BaseViewModel
    {
        public SolicitacaoQuadroViewModel()
        {
            Titulos = new TitulosQuadroViewModel();
        }
        public TitulosQuadroViewModel Titulos { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro1 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro2 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro3 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro4 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro5 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro6 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro7 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro8 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro9 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro10 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro11 { get; set; }
        public List<QuadroSolicitacaoViewModel> Quadro12 { get; set; }
    }

    public class TitulosQuadroViewModel
    {
        public string Titulo1 { get; set; }
        public string Titulo2 { get; set; }
        public string Titulo3 { get; set; }
        public string Titulo4 { get; set; }
        public string Titulo5 { get; set; }
        public string Titulo6 { get; set; }
        public string Titulo7 { get; set; }
        public string Titulo8 { get; set; }
        public string Titulo9 { get; set; }
        public string Titulo10 { get; set; }
        public string Titulo11 { get; set; }
        public string Titulo12 { get; set; }
    }

    public class QuadroSolicitacaoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int IdUsuarioAtendeAtual { get; set; }
        public string ClienteNome { get; set; }
        public string UsuarioNome { get; set; }
        public int IdStatus { get; set; }
        public int Nivel { get; set; }
        public String Quadro { get; set; }
        public int Aberta { get; set; }
        public string Perfil { get; set; }
    }

    public class SolicitacaoCronogramaViewModel
    {
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? Data { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
    }

    public class SolicitacaoOcorrenciaViewModel
    {
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descricao { get; set; }
        public int? TipoId { get; set; }
        public int Classificacao { get; set; }
        public string Anexo { get; set; }
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
    }

    public class SolicitacaoStatusViewModel
    {
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public int StatusId { get; set; }
        public TimeSpan? Hora { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeStatus { get; set; }
        public string HoraStr { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual StatusViewModel Status { get; set; }
    }

    public class SolicitacaoPermissaoViewModel
    {
        public bool PermissaoAbertura { get; set; }
        public bool PermissaoAnalise { get; set; }
        public bool PermissaoOcorrenciaGeral { get; set; }
        public bool PermissaoOcorrenciaTecnica { get; set; }
        public bool PermissaoOcorrenciaRegra { get; set; }
        public bool PermissaoStatus { get; set; }
        public bool PermissaoTempo { get; set; }
        public bool PermissaoQuadro { get; set; }
        public bool PermissaoConfTempoGeral { get; set; }
        public bool MostrarAnexos { get; set; }
        public string CaminhoAnexos { get; set; }
    }
}
