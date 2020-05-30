using SIDomper.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SIDomper.Infra.EF.Map
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Cat_Id");
            Property(x => x.Codigo).HasColumnName("Cat_Codigo");
            Property(x => x.Nome).HasColumnName("Cat_Nome");
            Property(x => x.Ativo).HasColumnName("Cat_Ativo");
        }
    }
}
