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
    public class EscalaMap : EntityTypeConfiguration<Escala>
    {
        public EscalaMap()
        {
            ToTable("Escala");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Esc_Id");
            Property(x => x.Data).HasColumnName("Esc_Data");
            Property(x => x.UsuarioId).HasColumnName("Esc_Usuario");
            Property(x => x.HoraInicio).HasColumnName("Esc_HoraInicio");
            Property(x => x.HoraFim).HasColumnName("Esc_HoraFim");
            Property(x => x.TotalHoras).HasColumnName("Esc_TotalHoras");

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.Escalas)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
