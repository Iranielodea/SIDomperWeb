using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SIDomper.Dominio.Entidades;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF.Map
{
    public class OrcamentoOcorrenciaMap : EntityTypeConfiguration<OrcamentoOcorrencia>
    {
        public OrcamentoOcorrenciaMap()
        {
            ToTable("Orcamento_Ocorrencia");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("OrcOco_Id");
            Property(x => x.Data).HasColumnName("OrcOco_Data");
            Property(x => x.Descricao).HasColumnName("OrcOco_Descricao");
            Property(x => x.OrcamentoId).HasColumnName("OrcOco_Orcamento");
            Property(x => x.UsuarioId).HasColumnName("OrcOco_Usuario");

            this.HasRequired(x => x.Orcamento)
                .WithMany(x => x.OrcamentoOcorrencias)
                .HasForeignKey(x => x.OrcamentoId);

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.OrcamentoOcorrencias)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
