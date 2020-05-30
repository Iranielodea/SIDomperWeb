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
    public class RamalItemMap : EntityTypeConfiguration<RamalItem>
    {
        public RamalItemMap()
        {
            ToTable("Ramal_Itens");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("RamIt_Id");
            Property(x => x.RamalId).HasColumnName("RamIt_Ramal");
            Property(x => x.Nome).HasColumnName("RamIt_Nome");
            Property(x => x.Numero).HasColumnName("RamIt_Numero");

            this.HasRequired(x => x.Ramal)
                .WithMany(x => x.RamalItens)
                .HasForeignKey(x => x.RamalId);
        }
    }
}
