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
    public class VersaoMap : EntityTypeConfiguration<Versao>
    {
        public VersaoMap()
        {
            ToTable("Versao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Ver_Id");
            Property(x => x.DataInicio).HasColumnName("Ver_DataInicio");
            Property(x => x.DataLiberacao).HasColumnName("Ver_DataLiberacao");
            Property(x => x.Descricao).HasColumnName("Ver_Descricao");
            Property(x => x.UsuarioId).HasColumnName("Ver_Usuario");
            Property(x => x.TipoId).HasColumnName("Ver_Tipo");
            Property(x => x.StatusId).HasColumnName("Ver_Status");
            Property(x => x.VersaoStr).HasColumnName("Ver_Versao");
            Property(x => x.ProdutoId).HasColumnName("Ver_Produto");

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.Versoes)
                .HasForeignKey(x => x.UsuarioId);

            this.HasRequired(x => x.Tipo)
                .WithMany(x => x.Versoes)
                .HasForeignKey(x => x.TipoId);

            this.HasRequired(x => x.Status)
                .WithMany(x => x.Versoes)
                .HasForeignKey(x => x.StatusId);
            this.HasOptional(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.ProdutoId);
        }
    }
}
