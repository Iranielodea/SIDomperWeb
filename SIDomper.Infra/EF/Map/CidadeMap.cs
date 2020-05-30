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
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidade");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Cid_Id");
            Property(x => x.Codigo).HasColumnName("Cid_Codigo");
            Property(x => x.Nome).HasColumnName("Cid_Nome");
            Property(x => x.Ativo).HasColumnName("Cid_Ativo");
            Property(x => x.UF).HasColumnName("Cid_UF");
        }
    }
}
