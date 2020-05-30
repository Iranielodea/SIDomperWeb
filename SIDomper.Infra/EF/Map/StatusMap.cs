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
    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            ToTable("Status");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Sta_Id");
            Property(x => x.Codigo).HasColumnName("Sta_Codigo");
            Property(x => x.Nome).HasColumnName("Sta_Nome");
            Property(x => x.Ativo).HasColumnName("Sta_Ativo");
            Property(x => x.Programa).HasColumnName("Sta_Programa");
            Property(x => x.NotificarCliente).HasColumnName("Sta_NotificarCliente");
            Property(x => x.NotificarSupervisor).HasColumnName("Sta_NotificarSupervisor");
            Property(x => x.NotificarConsultor).HasColumnName("Sta_NotificarConsultor");
            Property(x => x.NotificarRevenda).HasColumnName("Sta_NotificarRevenda");
            Property(x => x.Conceito).HasColumnName("Sta_Conceito");
        }
    }
}
