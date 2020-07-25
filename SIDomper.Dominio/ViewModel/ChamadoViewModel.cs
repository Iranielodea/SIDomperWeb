using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.ViewModel
{
    public class ChamadoViewModel : BaseViewModel
    {
        public ChamadoViewModel()
        {
            ChamadoOcorrencias = new List<ChamadoOcorrenciaViewModel>();
            ChamadosStatus = new List<ChamadoStatusViewModel>();
        }

        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeSpan HoraAbertura { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioAberturaId { get; set; }
        public string Contato { get; set; }
        public int Nivel { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public int? ModuloId { get; set; }
        public int? ProdutoId { get; set; }
        public int? UsuarioAtendeAtualId { get; set; }
        public TimeSpan? HoraAtendeAtual { get; set; }
        public int TipoMovimento { get; set; }
        public int CodUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int CodCliente { get; set; }
        public string NomeCliente { get; set; }
        public int CodModulo { get; set; }
        public string NomeModulo { get; set; }
        public int CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public int CodTipo { get; set; }
        public string NomeTipo { get; set; }
        public int CodStatus { get; set; }
        public string NomeStatus { get; set; }
        public bool UsuarioPermissaoAlterarDataHora { get; set; }
        public string Versao { get; set; }
        public int Origem { get; set; }

        public string NomeFantasia { get; set; }
        public string NomeRevenda { get; set; }
        public string NomeConsultor { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular { get; set; }
        public string OutroFone { get; set; }
        public string ContatoFinanceiro { get; set; }
        public string ContatoCompraVenda { get; set; }
        public bool UsuarioAdm { get; set; }
        public bool PermissaoAlterarOcorrenciaChamado { get; set; }
        public bool PermissaoExcluirOcorrenciaChamado { get; set; }
        public bool PermissaoAlterarOcorrenciaAtividade { get; set; }
        public bool PermissaoExcluirOcorrenciaAtividade { get; set; }

        public virtual ICollection<ChamadoOcorrenciaViewModel> ChamadoOcorrencias { get; set; }
        public virtual ICollection<ChamadoStatusViewModel> ChamadosStatus { get; set; }        

        public int OcorrenciaRetornarMenorId()
        {
            try
            {
                int id = ChamadoOcorrencias.Min(x => x.Id);
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

    public class ChamadoConsultaViewModel
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeSpan HoraAbertura { get; set; }
        public string Nivel { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string NomeTipo { get; set; }
        public string NomeStatus { get; set; }
        public string NomeUsuario { get; set; }
    }

    public class ChamadoFiltroViewModel
    {
        public ChamadoFiltroViewModel()
        {
            Revenda = new Revenda();
            Modulo = new Modulo();
            ClienteFiltro = new ClienteFiltro();
        }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string IdUsuarioAbertura { get; set; }
        public string IdCliente { get; set; }
        public string IdTipo { get; set; }
        public string IdStatus { get; set; }
        public int Id { get; set; }
        public int TipoMovimento { get; set; }
        public string IdModulo { get; set; }
        public string IdRevenda { get; set; }
        public string Campo { get; set; }
        public string Texto { get; set; }

        public Revenda Revenda { get; set; }
        public Modulo Modulo { get; set; }
        public ClienteFiltro ClienteFiltro { get; set; }
    }

    public class ChamadoOcorrenciaViewModel : BaseViewModel
    {
        public ChamadoOcorrenciaViewModel()
        {
            ChamadoOcorrenciaColaboradores = new List<ChamadoOcorrColaboradorViewModel>();
        }
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public string Documento { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public int UsuarioId { get; set; }
        public int? UsuarioColab1 { get; set; }
        public int? UsuarioColab2 { get; set; }
        public int? UsuarioColab3 { get; set; }
        public string DescricaoTecnica { get; set; }
        public string DescricaoSolucao { get; set; }
        public string Anexo { get; set; }
        public double TotalHoras { get; set; }
        public string Versao { get; set; }
        public int CodUsuario { get; set; }
        public string NomeUsuario { get; set; }

        public virtual ICollection<ChamadoOcorrColaboradorViewModel> ChamadoOcorrenciaColaboradores { get; set; }
    }

    public class ChamadoOcorrenciaConsultaViewModel :BaseViewModel
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

    public class ChamadoOcorrColaboradorViewModel
    {
        public int Id { get; set; }
        public int ChamadoOcorrenciaId { get; set; }
        public int UsuarioId { get; set; }
        public double TotalHoras { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public int CodUsuario { get; set; }
        public string NomeUsuario { get; set; }
    }

    public class ChamadoStatusViewModel
    {
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string NomeStatus { get; set; }
        public string NomeUsuario { get; set; }
        public string HoraTela { get; set; }
    }

    public class ChamadoAnexoViewModel
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeSpan HoraAbertura { get; set; }
        public string Contato { get; set; }
        public string NomeCliente { get; set; }
        public string DoctoOcorrencia { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string NomeAnexo { get; set; }
    }

    public class ProblemaSolucaoViewModel
    {
        public int Id { get; set; }
        public int IdChamado { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string DescricaoSolucao { get; set; }
        public string DescricaoTecnica { get; set; }
        public string NomeUsuario { get; set; }
    }

    public class QuadroViewModelChamado
    {
        public int Id { get; set; }
        public string DataAbertura { get; set; }
        public string HoraAbertura { get; set; }
        public string NomeCliente { get; set; }
        public string Nivel { get; set; }
        public string NomeTipo { get; set; }
        public string NomeUsuario { get; set; }
        public string Tempo { get; set; }
        public string NivelDescricao { get; set; }
        public int UsuarioAtendeAtualId { get; set; }
        public int CodigoStatus { get; set; }
        public int CodigoCliente { get; set; }
        public string UltimaHora { get; set; }
        public string HoraAtendeAtual { get; set; }
        public string UltimaData { get; set; }
        public string CodigoParametro { get; set; }
        public string QuadroTela { get; set; }
    }

    public class ChamadoAplicativoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public string Contato { get; set; }
        public string DescricaoProblema { get; set; }
        public string DescricaoSolucao { get; set; }
    }

    public class ChamadoAplicativoInputViewModel
    {
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Descricao { get; set; }
    }

    public class ChamadoAplicativoResultadoOutPutViewModel
    {
        public string Resultado { get; set; } = "OK";
    }

}
