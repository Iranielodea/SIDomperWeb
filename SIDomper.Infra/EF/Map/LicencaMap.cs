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
    public class LicencaMap : EntityTypeConfiguration<Licenca>
    {
        public LicencaMap()
        {
            ToTable("Licenca");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Lic_Id");
            Property(x => x.Codigo).HasColumnName("Lic_Codigo");
            Property(x => x.CnpjCpf).HasColumnName("Lic_CNPJCPF");
            Property(x => x.Empresa).HasColumnName("Lic_Empresa");
            Property(x => x.QtdeEstacao).HasColumnName("Lic_QtdeEstacao");
            Property(x => x.QtdeUsuario).HasColumnName("Lic_QtdeUsuario");
            Property(x => x.IPExterno).HasColumnName("Lic_IPExterno");
            Property(x => x.DataAtualizacao).HasColumnName("Lic_DataAtualizacao");
            Property(x => x.Build).HasColumnName("Lic_Build");
            Property(x => x.IPLocal).HasColumnName("Lic_IPLocal");
            Property(x => x.Cliente).HasColumnName("Lic_Cliente");
        }
    }
}
