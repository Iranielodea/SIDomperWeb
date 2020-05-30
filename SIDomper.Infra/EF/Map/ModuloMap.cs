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
    public class ModuloMap : EntityTypeConfiguration<Modulo>
    {
        public ModuloMap()
        {
            ToTable("Modulo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Mod_Id");
            Property(x => x.Codigo).HasColumnName("Mod_Codigo");
            Property(x => x.Nome).HasColumnName("Mod_Nome");
            Property(x => x.Ativo).HasColumnName("Mod_Ativo");
        }
    }
}
