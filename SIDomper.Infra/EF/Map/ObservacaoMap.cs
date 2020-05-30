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
    public class ObservacaoMap : EntityTypeConfiguration<Observacao>
    {
        public ObservacaoMap()
        {
            ToTable("Observacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Obs_Id");
            Property(x => x.Codigo).HasColumnName("Obs_Codigo");
            Property(x => x.Descricao).HasColumnName("Obs_Descricao");
            Property(x => x.Ativo).HasColumnName("Obs_Ativo");
            Property(x => x.Nome).HasColumnName("Obs_Nome");
            Property(x => x.Programa).HasColumnName("Obs_Programa");
            Property(x => x.Padrao).HasColumnName("Obs_Padrao");
            Property(x => x.ObsEmail).HasColumnName("Obs_ObsEmail");
            Property(x => x.EmailPadrao).HasColumnName("Obs_EmailPadrao");
        }
    }
}
