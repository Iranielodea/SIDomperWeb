using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDomper.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            Clientes = new List<Cliente>();
            Visitas = new List<Visita>();
            Prospects = new List<Prospect>();
            Orcamentos = new List<Orcamento>();
            OrcamentoOcorrencias = new List<OrcamentoOcorrencia>();
            UsuariosPermissao = new List<UsuarioPermissao>();
            Chamados = new List<Chamado>();
            ChamadosUsuarioAtendeAtual = new List<Chamado>();
            ChamadosStatus = new List<ChamadoStatus>();
            ChamadoOcorrencias = new List<ChamadoOcorrencia>();
            ChamadoOcorrenciaColaboradores = new List<ChamadoOcorrenciaColaborador>();
            ClienteEspecifiacoes = new List<ClienteEspecifiacao>();
            SolicitacoesUsuarioAbertura = new List<Solicitacao>();
            SolicitacoesUsuarioAnalista = new List<Solicitacao>();
            SolicitacoesUsuarioDesenvolvedor = new List<Solicitacao>();
            SolicitacoesUsuarioAtendeAtual = new List<Solicitacao>();
            Versoes = new List<Versao>();
            SolicitacaoCronogramas = new List<SolicitacaoCronograma>();
            SolicitacaoOcorrencias = new List<SolicitacaoOcorrencia>();
            SolicitacaoStatus = new List<SolicitacaoStatus>();
            Agendamentos = new List<Agendamento>();
            BaseConhecimentos = new List<BaseConhecimento>();
            Escalas = new List<Escala>();
            RecadosLcto = new List<Recado>();
            RecadosDestino = new List<Recado>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }

        [Required(ErrorMessage ="Informe o Usuário!")]
        public string UserName { get; set; }
        [DisplayName("Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        public string Password { get; set; }
        public bool Adm { get; set; }
        public bool Ativo { get; set; }
        public int? ContaEmailId { get; set; }
        public int DepartamentoId { get; set; }
        public string Email { get; set; }
        public int? RevendaId { get; set; }
        public int? ClienteId { get; set; }
        public bool OnLine { get; set; }
        public bool Notificar { get; set; }

        public virtual ContaEmail ContaEmail { get; set; }
        public virtual Departamento Departamento  { get; set; }
        public virtual Revenda Revenda { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Visita> Visitas { get; set; }
        public virtual ICollection<Prospect> Prospects { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        public virtual ICollection<OrcamentoOcorrencia> OrcamentoOcorrencias { get; set; }
        public virtual ICollection<UsuarioPermissao> UsuariosPermissao { get; set; }
        public virtual ICollection<ChamadoStatus> ChamadosStatus { get; set; }
        public virtual ICollection<ChamadoOcorrencia> ChamadoOcorrencias { get; set; }
        public virtual ICollection<ChamadoOcorrenciaColaborador> ChamadoOcorrenciaColaboradores { get; set; }
        public virtual ICollection<ClienteEspecifiacao> ClienteEspecifiacoes { get; set; }
        public virtual ICollection<Solicitacao> SolicitacoesUsuarioAbertura { get; set; }
        public virtual ICollection<Solicitacao> SolicitacoesUsuarioAnalista { get; set; }
        public virtual ICollection<Solicitacao> SolicitacoesUsuarioDesenvolvedor{ get; set; }
        public virtual ICollection<Solicitacao> SolicitacoesUsuarioAtendeAtual { get; set; }
        public virtual ICollection<Versao> Versoes { get; set; }
        public virtual ICollection<SolicitacaoCronograma> SolicitacaoCronogramas { get; set; }
        public virtual ICollection<SolicitacaoOcorrencia> SolicitacaoOcorrencias { get; set; }
        public virtual ICollection<SolicitacaoStatus> SolicitacaoStatus { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<BaseConhecimento> BaseConhecimentos { get; set; }
        public virtual ICollection<Escala> Escalas { get; set; }
        public virtual ICollection<Recado> RecadosLcto { get; set; }
        public virtual ICollection<Recado> RecadosDestino { get; set; }

        //[InverseProperty("UsuarioAbertura")]
        public virtual ICollection<Chamado> Chamados { get; set; }

        //[InverseProperty("UsuarioAtendeAtual")]
        public virtual ICollection<Chamado> ChamadosUsuarioAtendeAtual { get; set; }
    }

    public class UsuarioConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int ContaEmail { get; set; }
        public string Email { get; set; }
    }

    public class UsuarioPermissaoDepartamento
    {
        public int IdUsuario { get; set; }
        public int IdPrograma { get; set; }
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
        public bool UsuarioADM { get; set; }
    }

    public class UsuarioFiltro
    {
        public int Id { get; set; }
        public string Campo { get; set; }
        public string Texto { get; set; }
        public string IdRevenda { get; set; }
        public string IdCliente { get; set; }
        public string IdDepartamento { get; set; }
        public string Ativo { get; set; }
        public bool Contem { get; set; }
    }
}
