using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF.Map
{
    public class DepartamentoMap : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoMap()
        {
            ToTable("Departamento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Dep_Id");
            Property(x => x.Codigo).HasColumnName("Dep_Codigo");
            Property(x => x.Nome).HasColumnName("Dep_Nome");
            Property(x => x.Ativo).HasColumnName("Dep_Ativo");
            Property(x => x.SolicitaAbertura).HasColumnName("Dep_SolicitaAbertura");
            Property(x => x.SolicitaAnalise).HasColumnName("Dep_SolicitaAnalise");
            Property(x => x.SolicitacaoOcorrenciaGeral).HasColumnName("Dep_SolicitaOcorGeral");
            Property(x => x.SolicitacaoOcorrenciaTecnica).HasColumnName("Dep_SolicitaOcorTecnica");
            Property(x => x.SolicitacaoStatus).HasColumnName("Dep_SolicitaStatus");
            Property(x => x.SolicitacaoQuadro).HasColumnName("Dep_SolicitaQuadro");
            Property(x => x.ChamadoAbertura).HasColumnName("Dep_ChamadoAbertura");
            Property(x => x.ChamadoStatus).HasColumnName("Dep_ChamadoStatus");
            Property(x => x.ChamadoQuadro).HasColumnName("Dep_ChamadoQuadro");
            Property(x => x.ChamadoOcorrencia).HasColumnName("Dep_ChamadoOcor");
            Property(x => x.AtividadeAbertura).HasColumnName("Dep_AtividadeAbertura");
            Property(x => x.AtividadeStatus).HasColumnName("Dep_AtividadeStatus");
            Property(x => x.AtividadeQuadro).HasColumnName("Dep_AtividadeQuadro");
            Property(x => x.AtividadeOcorrencia).HasColumnName("Dep_AtividadeOcor");
            Property(x => x.AgencamentoQuadro).HasColumnName("Dep_AgendamentoQuadro");
            Property(x => x.MostrarAnexos).HasColumnName("Dep_MostrarAnexos");
            Property(x => x.SolicitacaoOcorrenciaRegra).HasColumnName("Dep_SolicitaOcorRegra");
            Property(x => x.HoraInicial).HasColumnName("Dep_HoraAtendeInicial");
            Property(x => x.HoraFinal).HasColumnName("Dep_HoraAtendeFinal");
        }
    }
}
