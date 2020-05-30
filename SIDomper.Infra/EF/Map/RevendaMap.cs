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
    public class RevendaMap : EntityTypeConfiguration<Revenda>
    {
        public RevendaMap()
        {
            ToTable("Revenda");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Rev_Id");
            Property(x => x.Codigo).HasColumnName("Rev_Codigo");
            Property(x => x.Ativo).HasColumnName("Rev_Ativo");
            Property(x => x.Nome).HasColumnName("Rev_Nome");
        }
    }
}
