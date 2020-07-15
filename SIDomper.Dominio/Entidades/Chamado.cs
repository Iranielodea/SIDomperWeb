using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDomper.Dominio.Entidades
{
    public class Chamado
    {
        public Chamado()
        {
            ChamadosStatus = new List<ChamadoStatus>();
            ChamadoOcorrencias = new List<ChamadoOcorrencia>();
            Agendamentos = new List<Agendamento>();
            DataAbertura = DateTime.Now.Date;
            HoraAbertura = TimeSpan.Parse(DateTime.Now.ToString("hh:mm"));
            TipoMovimento = 1; // chamado 2 - atividade

            //TODO: ver outras properiedades para inicializar
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

        [NotMapped]
        public bool UsaAplicativo { get; set; } = false;

        public virtual Cliente Cliente { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Status Status { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual ICollection<ChamadoStatus> ChamadosStatus { get; set; }
        public virtual ICollection<ChamadoOcorrencia> ChamadoOcorrencias { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }

        public virtual Usuario UsuarioAbertura { get; set; }
        public virtual Usuario UsuarioAtendeAtual { get; set; }
    }

    public class ChamadoConsulta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeSpan HoraAbertura { get; set; }
        public string NomeStatus { get; set; }
        public int IdStatus { get; set; }
        public string NomeTipo { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Nivel { get; set; }
        public string NomeUsuario { get; set; }
    }

    public class ChamadoFiltro
    {
        public ChamadoFiltro()
        {
            Revenda = new Revenda();
            Modulo = new Modulo();
            clienteFiltro = new ClienteFiltro();
        }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string IdUsuarioAbertura { get; set; }
        public string IdCliente { get; set; }
        public string idTipo { get; set; }
        public string IdStatus { get; set; }
        public int Id { get; set; }
        public int TipoMovimento { get; set; }
        public string IdModulo { get; set; }
        public string IdRevenda { get; set; }

        public Revenda Revenda { get; set; }
        public Modulo Modulo { get; set; }
        public ClienteFiltro clienteFiltro { get; set; }
    }

    public class Quadro
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

    public class QuadroEF
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeSpan HoraAbertura { get; set; }
        public string NomeCliente { get; set; }
        public int Nivel { get; set; }
        public string NomeTipo { get; set; }
        public string NomeUsuario { get; set; }
        public string Tempo { get; set; }
        public string NivelDescricao { get; set; }
        public int UsuarioAtendeAtualId { get; set; }
        public int CodigoStatus { get; set; }
        public int CodigoCliente { get; set; }
        public TimeSpan UltimaHora { get; set; }
        public TimeSpan HoraAtendeAtual { get; set; }
        public DateTime UltimaData { get; set; }
        public int CodigoParametro { get; set; }
        public string QuadroTela { get; set; }
    }

    public class ChamadoAnexo
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
}
