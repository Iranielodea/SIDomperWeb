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
    public class VisitaMap : EntityTypeConfiguration<Visita>
    {
        public VisitaMap()
        {
            ToTable("Visita");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Vis_Id");
            Property(x => x.Dcto).HasColumnName("Vis_Dcto");
            Property(x => x.Data).HasColumnName("Vis_Data");
            Property(x => x.HoraInicio).HasColumnName("Vis_HoraInicio");
            Property(x => x.HoraFim).HasColumnName("Vis_HoraFim");
            Property(x => x.ClienteId).HasColumnName("Vis_Cliente");
            Property(x => x.UsuarioId).HasColumnName("Vis_Usuario");
            Property(x => x.Contato).HasColumnName("Vis_Contato");
            Property(x => x.TipoId).HasColumnName("Vis_Tipo");
            Property(x => x.StatusId).HasColumnName("Vis_Status");
            Property(x => x.Descricao).HasColumnName("Vis_Descricao");
            Property(x => x.Anexo).HasColumnName("Vis_Anexo");
            Property(x => x.TotalHoras).HasColumnName("Vis_TotalHoras");
            Property(x => x.FormaPagto).HasColumnName("Vis_FormaPagto");
            Property(x => x.Valor).HasColumnName("Vis_Valor");
            Property(x => x.Versao).HasColumnName("Vis_Versao");
            Property(x => x.Latitude).HasColumnName("Vis_Latitude");
            Property(x => x.Longitude).HasColumnName("Vis_Longitude");

            this.HasRequired(t => t.Cliente)
               .WithMany(t => t.Visitas)
               .HasForeignKey(t => t.ClienteId);

            this.HasRequired(t => t.Usuario)
               .WithMany(t => t.Visitas)
               .HasForeignKey(t => t.UsuarioId);

            this.HasRequired(t => t.Tipo)
               .WithMany(t => t.Visitas)
               .HasForeignKey(t => t.TipoId);

            this.HasRequired(t => t.Status)
               .WithMany(t => t.Visitas)
               .HasForeignKey(t => t.StatusId);
        }
    }
}
