using System;
using System.Collections.Generic;

namespace SIDomper.Dominio.Entidades
{
    public class Departamento
    {
        public Departamento()
        {
            DepartamentosEmail = new List<DepartamentoEmail>();
            Usuarios = new List<Usuario>();
            DepartamentoAcessos = new List<DepartamentoAcesso>();
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public bool SolicitaAbertura { get; set; }
        public bool SolicitaAnalise { get; set; }
        public bool SolicitacaoOcorrenciaGeral { get; set; }
        public bool SolicitacaoOcorrenciaTecnica { get; set; }
        public bool SolicitacaoOcorrenciaRegra { get; set; }
        public bool SolicitacaoStatus { get; set; }
        public bool SolicitacaoQuadro { get; set; }
        public bool ChamadoAbertura { get; set; }
        public bool ChamadoStatus { get; set; }
        public bool ChamadoQuadro { get; set; }
        public bool ChamadoOcorrencia { get; set; }
        public bool AtividadeAbertura { get; set; }
        public bool AtividadeStatus { get; set; }
        public bool AtividadeQuadro { get; set; }
        public bool AtividadeOcorrencia { get; set; }
        public bool AgencamentoQuadro { get; set; }
        public bool MostrarAnexos { get; set; }
        public TimeSpan? HoraInicial { get; set; }
        public TimeSpan? HoraFinal { get; set; }

        public virtual ICollection<DepartamentoEmail> DepartamentosEmail { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<DepartamentoAcesso> DepartamentoAcessos { get; set; }
    }

    public class DepartamentoConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
