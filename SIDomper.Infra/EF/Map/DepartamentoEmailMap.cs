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
    public class DepartamentoEmailMap : EntityTypeConfiguration<DepartamentoEmail>
    {
        public DepartamentoEmailMap()
        {

            ToTable("Departamento_Email");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("DepEm_Id");
            Property(x => x.DepartamentoId).HasColumnName("DepEm_Departamento");
            Property(x => x.Email).HasColumnName("DepEm_Email");

            this.HasRequired(t => t.Departamento)
                .WithMany(t => t.DepartamentosEmail)
                .HasForeignKey(t => t.DepartamentoId);
        }
    }
}
