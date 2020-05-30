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
    public class ClienteEspecificacaoMap : EntityTypeConfiguration<ClienteEspecifiacao>
    {
        public ClienteEspecificacaoMap()
        {
            ToTable("Cliente_Especificacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("CliEsp_Id");
            Property(x => x.Anexo).HasColumnName("CliEsp_Anexo");
            Property(x => x.ClienteId).HasColumnName("CliEsp_Cliente");
            Property(x => x.Data).HasColumnName("CliEsp_Data");
            Property(x => x.Descricao).HasColumnName("CliEsp_Descricao");
            Property(x => x.Item).HasColumnName("CliEsp_Item");
            Property(x => x.Nome).HasColumnName("CliEsp_Nome");
            Property(x => x.UsuarioId).HasColumnName("CliEsp_Usuario");

            this.HasRequired(x => x.Cliente)
                .WithMany(x => x.ClienteEspecifiacoes)
                .HasForeignKey(x => x.ClienteId);

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.ClienteEspecifiacoes)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
