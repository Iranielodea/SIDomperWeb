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
    public class ClienteEmailMap : EntityTypeConfiguration<ClienteEmail>
    {
        public ClienteEmailMap()
        {
            ToTable("Cliente_Email");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("CliEm_Id");
            Property(x => x.ClienteId).HasColumnName("CliEm_Cliente");
            Property(x => x.Email).HasColumnName("CliEm_Email");
            Property(x => x.Notificar).HasColumnName("CliEm_Notificar");

            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.Emails)
                .HasForeignKey(t => t.ClienteId);
        }
    }
}
