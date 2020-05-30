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
    public class ParametroMap : EntityTypeConfiguration<Parametro>
    {
        public ParametroMap()
        {
            ToTable("Parametros");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Par_Id");
            Property(x => x.Codigo).HasColumnName("Par_Codigo");
            Property(x => x.Programa).HasColumnName("Par_Programa");
            Property(x => x.Nome).HasColumnName("Par_Nome");
            Property(x => x.Valor).HasColumnName("Par_Valor");
            Property(x => x.Observacao).HasColumnName("Par_Obs");
        }
    }
}
