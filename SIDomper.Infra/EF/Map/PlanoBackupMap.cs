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
    public class PlanoBackupMap : EntityTypeConfiguration<PlanoBackup>
    {
        public PlanoBackupMap()
        {
            ToTable("PlanoBackup");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Plb_Id");
            Property(x => x.Destino).HasColumnName("Plb_Destino");
            Property(x => x.Domingo).HasColumnName("Plb_Domingo");
            Property(x => x.Segunda).HasColumnName("Plb_Segunda");
            Property(x => x.Terca).HasColumnName("Plb_Terca");
            Property(x => x.Quarta).HasColumnName("Plb_Quarta");
            Property(x => x.Quinta).HasColumnName("Plb_Quinta");
            Property(x => x.Sexta).HasColumnName("Plb_Sexta");
            Property(x => x.Sabado).HasColumnName("Plb_Sabado");
            Property(x => x.Ativo).HasColumnName("Plb_Ativo");
            Property(x => x.DataUltimoBackup).HasColumnName("Plb_DataUltimoBackup");
        }
    }
}
