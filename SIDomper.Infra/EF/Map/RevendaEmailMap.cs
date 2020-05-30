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
    public class RevendaEmailMap : EntityTypeConfiguration<RevendaEmail>
    {
        public RevendaEmailMap()
        {
            ToTable("Revenda_Email");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("RevEm_Id");
            Property(x => x.RevendaId).HasColumnName("RevEm_Revenda");
            Property(x => x.Email).HasColumnName("RevEm_Email");

            this.HasRequired(t => t.Revenda)
                .WithMany(t => t.RevendaEmails)
                .HasForeignKey(t => t.RevendaId);
        }
    }
}
