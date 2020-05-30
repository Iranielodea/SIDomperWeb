using SIDomper.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SIDomper.Infra.EF.Map
{
    public class FormaPagtoMap : EntityTypeConfiguration<FormaPagto>
    {
        public FormaPagtoMap()
        {
            ToTable("FormaPagto");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Fpg_Id");
            Property(x => x.Codigo).HasColumnName("Fpg_Codigo");
            Property(x => x.Nome).HasColumnName("Fpg_Nome");
            Property(x => x.Ativo).HasColumnName("Fpg_Ativo");
        }
    }
}
