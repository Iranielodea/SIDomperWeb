using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SIDomper.Dominio.Entidades;

namespace SIDomper.Infra.EF.Map
{
    public class OrcamentoVencimentoMap : EntityTypeConfiguration<OrcamentoVencimento>
    {
        public OrcamentoVencimentoMap()
        {
            ToTable("Orcamento_Vectos");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("OrcVect_Id");
            Property(x => x.Data).HasColumnName("OrcVect_Data");
            Property(x => x.Descricao).HasColumnName("OrcVect_Descricao");
            Property(x => x.OrcamentoId).HasColumnName("OrcVect_Orcamento");
            Property(x => x.Parcela).HasColumnName("OrcVect_Parcela");
            Property(x => x.Valor).HasColumnName("OrcVect_Valor");

            this.HasRequired(x => x.Orcamento)
                .WithMany(x => x.OrcamentoVencimentos)
                .HasForeignKey(x => x.OrcamentoId);
        }
    }
}
