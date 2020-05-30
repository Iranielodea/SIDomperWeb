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
    public class SolicitacaoOcorrenciaMap : EntityTypeConfiguration<SolicitacaoOcorrencia>
    {
        public SolicitacaoOcorrenciaMap()
        {
            ToTable("Solicitacao_Ocorrencia");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("SOcor_Id");
            Property(x => x.SolicitacaoId).HasColumnName("SOcor_Solicitacao");
            Property(x => x.UsuarioId).HasColumnName("SOcor_UsuarioOperacional");
            Property(x => x.Data).HasColumnName("SOcor_Data");
            Property(x => x.Hora).HasColumnName("SOcor_Hora");
            Property(x => x.Descricao).HasColumnName("SOcor_Descricao");
            Property(x => x.TipoId).HasColumnName("SOcor_Tipo");
            Property(x => x.Classificacao).HasColumnName("SOcor_Classificacao");
            Property(x => x.Anexo).HasColumnName("SOcor_anexo");

            this.HasRequired(x => x.Solicitacao)
                .WithMany(x => x.SolicitacaoOcorrencias)
                .HasForeignKey(x => x.SolicitacaoId);

            this.HasRequired(x => x.Usuario)
               .WithMany(x => x.SolicitacaoOcorrencias)
               .HasForeignKey(x => x.UsuarioId);

            this.HasRequired(x => x.Tipo)
               .WithMany(x => x.SolicitacaoOcorrencias)
               .HasForeignKey(x => x.TipoId);
        }
    }
}
