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
    public class LicencaItemMap : EntityTypeConfiguration<LicencaItem>
    {
        public LicencaItemMap()
        {
            ToTable("Licenca_Itens");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("LicIte_Id");
            Property(x => x.Codigo).HasColumnName("LicIte_Codigo");
            Property(x => x.CnpjCpf).HasColumnName("LicIte_CNPJCPF");
            Property(x => x.DataLcto).HasColumnName("LicIte_DataLcto");
            Property(x => x.Licenca).HasColumnName("LicIte_Licenca");
            Property(x => x.DataUtilizacao).HasColumnName("LicIte_DataUtilizacao");
            Property(x => x.Situacao).HasColumnName("LicIte_Situacao");
            Property(x => x.Utilizada).HasColumnName("LicIte_Utilizada");
            Property(x => x.Cliente).HasColumnName("LicIte_Cliente");
        }
    }
}
