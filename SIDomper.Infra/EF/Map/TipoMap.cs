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
    public class TipoMap: EntityTypeConfiguration<Tipo>
    {
        public TipoMap()
        {
            ToTable("Tipo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Tip_Id");
            Property(x => x.Codigo).HasColumnName("Tip_Codigo");
            Property(x => x.Nome).HasColumnName("Tip_Nome");
            Property(x => x.Ativo).HasColumnName("Tip_Ativo");
            Property(x => x.Programa).HasColumnName("Tip_Programa");
            Property(x => x.Conceito).HasColumnName("Tip_Conceito");
        }
    }
}
