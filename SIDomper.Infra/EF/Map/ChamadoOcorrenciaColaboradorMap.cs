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
    public class ChamadoOcorrenciaColaboradorMap : EntityTypeConfiguration<ChamadoOcorrenciaColaborador>
    {
        public ChamadoOcorrenciaColaboradorMap()
        {
            ToTable("Chamado_Ocorr_Colaborador");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ChaOCol_Id");
            Property(x => x.ChamadoOcorrenciaId).HasColumnName("ChaOCol_ChamadoOcorrencia");
            Property(x => x.UsuarioId).HasColumnName("ChaOCol_Usuario");
            Property(x => x.TotalHoras).HasColumnName("ChaOCol_TotalHoras");
            Property(x => x.HoraInicio).HasColumnName("ChaOCol_HoraInicio");
            Property(x => x.HoraFim).HasColumnName("ChaOCol_HoraFim");

            this.HasRequired(t => t.ChamadoOcorrencia)
                .WithMany(t => t.ChamadoOcorrenciaColaboradores)
                .HasForeignKey(t => t.ChamadoOcorrenciaId);

            this.HasRequired(t => t.Usuario)
                .WithMany(t => t.ChamadoOcorrenciaColaboradores)
                .HasForeignKey(t => t.UsuarioId);
        }
    }
}
