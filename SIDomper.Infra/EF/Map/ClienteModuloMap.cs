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
    public class ClienteModuloMap : EntityTypeConfiguration<ClienteModulo>
    {
        public ClienteModuloMap()
        {
            ToTable("Cliente_Modulo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("CliMod_Id");
            Property(x => x.ClienteId).HasColumnName("CliMod_Cliente");
            Property(x => x.ModuloId).HasColumnName("CliMod_Modulo");
            Property(x => x.ProdutoId).HasColumnName("CliMod_Produto");

            this.HasRequired(t => t.Modulo)
                .WithMany(t => t.ClienteModulos)
                .HasForeignKey(t => t.ModuloId);

            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.ClienteModulos)
                .HasForeignKey(t => t.ClienteId);

            this.HasOptional(t => t.Produto)
                .WithMany(t => t.ClienteModulos)
                .HasForeignKey(t => t.ProdutoId);
        }
    }
}
