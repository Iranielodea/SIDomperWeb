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
    public class SolicitacaoCronogramaMap : EntityTypeConfiguration<SolicitacaoCronograma>
    {
        public SolicitacaoCronogramaMap()
        {
            ToTable("Solicitacao_Cronograma");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("SCro_Id");
            Property(x => x.SolicitacaoId).HasColumnName("SCro_Solicitacao");
            Property(x => x.UsuarioId).HasColumnName("SCro_UsuarioOperacional");
            Property(x => x.Data).HasColumnName("SCro_Data");
            Property(x => x.HoraInicio).HasColumnName("SCro_HoraInicio");
            Property(x => x.HoraFim).HasColumnName("SCro_HoraFim");

            this.HasRequired(x => x.Solicitacao)
                .WithMany(x => x.SolicitacaoCronogramas)
                .HasForeignKey(x => x.SolicitacaoId);

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.SolicitacaoCronogramas)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
