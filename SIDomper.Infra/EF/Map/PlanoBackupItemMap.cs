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
    public class PlanoBackupItemMap : EntityTypeConfiguration<PlanoBackupItem>
    {
        public PlanoBackupItemMap()
        {
            ToTable("PlanoBackupItens");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("PlbIte_Id");
            Property(x => x.PlanoBackupId).HasColumnName("PlbIte_PlanoBackup");
            Property(x => x.Hora).HasColumnName("PlbIte_Hora");
            Property(x => x.Status).HasColumnName("PlbIte_Status");

            this.HasRequired(x => x.PlanoBackup)
                .WithMany(x => x.PlanoBackupItens)
                .HasForeignKey(x => x.PlanoBackupId);
        }
    }
}
