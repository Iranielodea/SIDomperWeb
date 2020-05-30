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
    public class OrcamentoEmailMap : EntityTypeConfiguration<OrcamentoEmail>
    {
        public OrcamentoEmailMap()
        {
            ToTable("Orcamento_Email");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("OrcEm_Id");
            Property(x => x.OrcamentoId).HasColumnName("OrcEm_Orcamento");
            Property(x => x.Email).HasColumnName("OrcEm_Email");

            this.HasRequired(t => t.Orcamento)
                .WithMany(t => t.OrcamentoEmails)
                .HasForeignKey(t => t.OrcamentoId);
        }
    }
}
