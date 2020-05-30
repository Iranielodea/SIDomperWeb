﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.ViewModel
{
    public class DepartamentoViewModel : BaseViewModel
    {
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

        public virtual ICollection<DepartamentoAcessoViewModel> DepartamentoAcessos { get; set; }
        public virtual ICollection<DepartamentoEmailViewModel> DepartamentosEmail { get; set; }
    }

    public class DepartamentoConsultaViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }

    public class DepartamentoAcessoViewModel
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public int Programa { get; set; }
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
        public string DescricaoPrograma { get; set; }

        public bool ProgIncluir { get; set; }
        public bool ProgEditar { get; set; }
        public bool ProgExcluir { get; set; }
        public bool ProgRelatorio { get; set; }
    }

    public class DepartamentoEmailViewModel
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public string Email { get; set; }
    }
}
