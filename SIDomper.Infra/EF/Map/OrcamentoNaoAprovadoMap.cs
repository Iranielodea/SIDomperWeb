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
    public class OrcamentoNaoAprovadoMap : EntityTypeConfiguration<OrcamentoNaoAprovado>
    {
        public OrcamentoNaoAprovadoMap()
        {
            ToTable("Orcamento_NaoAprovado");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("OrcNAp_Id");
            Property(x => x.Descricao).HasColumnName("OrcNAp_Descricao");
            Property(x => x.OrcamentoId).HasColumnName("OrcNAp_Orcamento");
            Property(x => x.TipoId).HasColumnName("OrcNAp_Tipo");

            this.HasRequired(t => t.Orcamento)
                .WithMany(t => t.OrcamentoNaoAprovados)
                .HasForeignKey(t => t.OrcamentoId);

            this.HasRequired(t => t.Tipo)
                .WithMany(t => t.OrcamentoNaoAprovados)
                .HasForeignKey(t => t.TipoId);
        }
    }
}
