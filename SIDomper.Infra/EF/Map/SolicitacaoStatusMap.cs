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
    public class SolicitacaoStatusMap : EntityTypeConfiguration<SolicitacaoStatus>
    {
        public SolicitacaoStatusMap()
        {
            ToTable("Solicitacao_Status");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("SSta_Id");
            Property(x => x.SolicitacaoId).HasColumnName("SSta_Solicitacao");
            Property(x => x.Data).HasColumnName("SSta_Data");
            Property(x => x.Hora).HasColumnName("SSta_Hora");
            Property(x => x.UsuarioId).HasColumnName("SSta_UsuarioOperacional");
            Property(x => x.StatusId).HasColumnName("SSta_Status");

            this.HasRequired(x => x.Solicitacao)
                .WithMany(x => x.SolicitacaoStatus)
                .HasForeignKey(x => x.SolicitacaoId);

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.SolicitacaoStatus)
                .HasForeignKey(x => x.UsuarioId);

            this.HasRequired(x => x.Status)
                .WithMany(x => x.SolicitacaoStatus)
                .HasForeignKey(x => x.StatusId);
        }
    }
}
