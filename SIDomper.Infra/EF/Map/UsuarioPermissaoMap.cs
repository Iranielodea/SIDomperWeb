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
    public class UsuarioPermissaoMap : EntityTypeConfiguration<UsuarioPermissao>
    {
        public UsuarioPermissaoMap()
        {
            ToTable("Usuario_Permissao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("UsuP_Id");
            Property(x => x.Sigla).HasColumnName("UsuP_Sigla");
            Property(x => x.UsuarioId).HasColumnName("UsuP_Usuario");

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.UsuariosPermissao)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
