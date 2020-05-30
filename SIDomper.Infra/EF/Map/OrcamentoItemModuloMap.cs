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
    public class OrcamentoItemModuloMap : EntityTypeConfiguration<OrcamentoItemModulo>
    {
        public OrcamentoItemModuloMap()
        {
            ToTable("Orcamento_Item_Modulo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("OrcIteMod_Id");
            Property(x => x.Descricao).HasColumnName("OrcIteMod_Descricao");
            Property(x => x.ModuloId).HasColumnName("OrcIteMod_Modulo");
            Property(x => x.OrcamentoItemId).HasColumnName("OrcIteMod_OrcamentoItem");

            this.HasRequired(t => t.OrcamentoItem)
               .WithMany(x => x.OrcamentoItemModulos)
               .HasForeignKey(t => t.OrcamentoItemId);

            this.HasRequired(t => t.Modulo)
               .WithMany(x => x.OrcamentoItemModulos)
               .HasForeignKey(t => t.ModuloId);
        }
    }
}
