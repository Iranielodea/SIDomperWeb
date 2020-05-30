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
    public class ChamadoStatusMap : EntityTypeConfiguration<ChamadoStatus>
    {
        public ChamadoStatusMap()
        {
            ToTable("Chamado_Status");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ChSta_Id");
            Property(x => x.ChamadoId).HasColumnName("ChSta_Chamado");
            Property(x => x.Data).HasColumnName("ChSta_Data");
            Property(x => x.StatusId).HasColumnName("ChSta_Status");
            Property(x => x.UsuarioId).HasColumnName("ChSta_Usuario");
            Property(x => x.Hora).HasColumnName("ChSta_Hora");

            this.HasRequired(t => t.Chamado)
                .WithMany(t => t.ChamadosStatus)
                .HasForeignKey(t => t.ChamadoId);

            this.HasRequired(t => t.Status)
                .WithMany(t => t.ChamadosStatus)
                .HasForeignKey(t => t.StatusId);

            this.HasRequired(t => t.Usuario)
               .WithMany(t => t.ChamadosStatus)
               .HasForeignKey(t => t.UsuarioId);
        }
    }
}
