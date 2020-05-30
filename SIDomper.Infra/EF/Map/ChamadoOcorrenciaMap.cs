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
    public class ChamadoOcorrenciaMap : EntityTypeConfiguration<ChamadoOcorrencia>
    {
        public ChamadoOcorrenciaMap()
        {
            ToTable("Chamado_Ocorrencia");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ChOco_Id");
            Property(x => x.ChamadoId).HasColumnName("ChOco_Chamado");
            Property(x => x.Documento).HasColumnName("ChOco_Docto");
            Property(x => x.Data).HasColumnName("ChOco_Data");
            Property(x => x.HoraInicio).HasColumnName("ChOco_HoraInicio");
            Property(x => x.HoraFim).HasColumnName("ChOco_HoraFim");
            Property(x => x.UsuarioId).HasColumnName("ChOco_Usuario");
            Property(x => x.UsuarioColab1).HasColumnName("ChOco_UsuarioColab1");
            Property(x => x.UsuarioColab2).HasColumnName("ChOco_UsuarioColab2");
            Property(x => x.UsuarioColab3).HasColumnName("ChOco_UsuarioColab3");
            Property(x => x.DescricaoTecnica).HasColumnName("ChOco_DescricaoTecnica");
            Property(x => x.DescricaoSolucao).HasColumnName("ChOco_DescricaoSolucao");
            Property(x => x.Anexo).HasColumnName("ChOco_Anexo");
            Property(x => x.TotalHoras).HasColumnName("ChOco_TotalHoras");
            Property(x => x.Versao).HasColumnName("ChOco_Versao");

            this.HasRequired(t => t.Chamado)
                .WithMany(t => t.ChamadoOcorrencias)
                .HasForeignKey(t => t.ChamadoId);

            this.HasRequired(t => t.Usuario)
                .WithMany(t => t.ChamadoOcorrencias)
                .HasForeignKey(t => t.UsuarioId);
        }
    }
}
