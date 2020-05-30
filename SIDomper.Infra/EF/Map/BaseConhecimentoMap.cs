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
    public class BaseConhecimentoMap : EntityTypeConfiguration<BaseConhecimento>
    {
        public BaseConhecimentoMap()
        {
            ToTable("Base");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Bas_Id");
            Property(x => x.Data).HasColumnName("Bas_Data");
            Property(x => x.Nome).HasColumnName("Bas_Nome");
            Property(x => x.UsuarioId).HasColumnName("Bas_Usuario");
            Property(x => x.ProdutoId).HasColumnName("Bas_Produto");
            Property(x => x.ModuloId).HasColumnName("Bas_Modulo");
            Property(x => x.TipoId).HasColumnName("Bas_Tipo");
            Property(x => x.StatusId).HasColumnName("Bas_Status");
            Property(x => x.Descricao).HasColumnName("Bas_Descricao");
            Property(x => x.Anexo).HasColumnName("Bas_Anexo");

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.BaseConhecimentos)
                .HasForeignKey(x => x.UsuarioId);

            this.HasOptional(x => x.Produto)
                .WithMany(x => x.BaseConhecimentos)
                .HasForeignKey(x => x.ProdutoId);

            this.HasOptional(x => x.Modulo)
                .WithMany(x => x.BaseConhecimentos)
                .HasForeignKey(x => x.ModuloId);

            this.HasRequired(x => x.Tipo)
                .WithMany(x => x.BaseConhecimentos)
                .HasForeignKey(x => x.TipoId);

            this.HasRequired(x => x.Status)
                .WithMany(x => x.BaseConhecimentos)
                .HasForeignKey(x => x.StatusId);
        }
    }
}
