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
    public class ProspectMap : EntityTypeConfiguration<Prospect>
    {
        public ProspectMap()
        {
            ToTable("Prospect");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Pros_Id");
            Property(x => x.Codigo).HasColumnName("Pros_Codigo");
            Property(x => x.Nome).HasColumnName("Pros_Nome");
            Property(x => x.Fantasia).HasColumnName("Pros_Fantasia");
            Property(x => x.Docto).HasColumnName("Pros_Docto");
            Property(x => x.Enquadramento).HasColumnName("Pros_Enquadramento");
            Property(x => x.Endereco).HasColumnName("Pros_Endereco");
            Property(x => x.Telefone).HasColumnName("Pros_Telefone");
            Property(x => x.Contato).HasColumnName("Pros_Contato");
            Property(x => x.UsuarioId).HasColumnName("Pros_Usuario");
            Property(x => x.RevendaId).HasColumnName("Pros_Revenda");
            Property(x => x.Ativo).HasColumnName("Pros_Ativo");

            this.HasRequired(t => t.Usuario)
                .WithMany(x => x.Prospects)
                .HasForeignKey(t => t.UsuarioId);

            this.HasRequired(t => t.Revenda)
                .WithMany(x => x.Prospects)
                .HasForeignKey(t => t.RevendaId);
        }
    }
}
