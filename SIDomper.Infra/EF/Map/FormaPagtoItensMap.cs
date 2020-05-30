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
    public class FormaPagtoItensMap : EntityTypeConfiguration<FormaPagtoItens>
    {
        public FormaPagtoItensMap()
        {
            ToTable("FormaPagto_Item");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("FpgIte_Id");
            Property(x => x.Dias).HasColumnName("FpgIte_Dias");
            Property(x => x.FormaPagtoId).HasColumnName("FpgIte_FormaPagto");
            Property(x => x.Observacao).HasColumnName("FpgIte_Obs");

            this.HasRequired(t => t.FormaPagto)
                .WithMany(t => t.FormaPagtoItens)
                .HasForeignKey(t => t.FormaPagtoId);
        }
    }
}
