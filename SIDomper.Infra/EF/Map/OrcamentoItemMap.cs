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
    public class OrcamentoItemMap : EntityTypeConfiguration<OrcamentoItem>
    {
        public OrcamentoItemMap()
        {
            ToTable("Orcamento_Item");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("OrcIte_Id");
            Property(x => x.Descricao).HasColumnName("OrcIte_Descricao");
            Property(x => x.OrcamentoId).HasColumnName("OrcIte_Orcamento");
            Property(x => x.ProdutoId).HasColumnName("OrcIte_Produto");
            Property(x => x.StatusId).HasColumnName("OrcIte_Status");
            Property(x => x.TipoId).HasColumnName("OrcIte_Tipo");
            Property(x => x.ValorDescontoImpl).HasColumnName("OrcIte_ValorDescImpl");
            Property(x => x.ValorDescontoMensal).HasColumnName("OrcIte_ValorDescMensal");
            Property(x => x.ValorLicencaImpl).HasColumnName("OrcIte_ValorLicencaImpl");
            Property(x => x.ValorLicencaMensal).HasColumnName("OrcIte_ValorLicencaMensal");

            this.HasRequired(t => t.Orcamento)
                .WithMany(t => t.OrcamentoItens)
                .HasForeignKey(t => t.OrcamentoId);

            this.HasRequired(t => t.Produto)
                .WithMany(t => t.OrcamentoItens)
                .HasForeignKey(t => t.ProdutoId);

            this.HasOptional(t => t.Tipo)
                .WithMany(t => t.OrcamentoItens)
                .HasForeignKey(t => t.TipoId);

            this.HasOptional(t => t.Status)
                .WithMany(t => t.OrcamentoItens)
                .HasForeignKey(t => t.StatusId);
        }
    }
}
