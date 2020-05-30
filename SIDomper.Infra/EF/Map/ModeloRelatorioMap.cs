using SIDomper.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SIDomper.Infra.EF.Map
{
    public class ModeloRelatorioMap : EntityTypeConfiguration<ModeloRelatorio>
    {
        public ModeloRelatorioMap()
        {
            ToTable("Modelo_Relatorio");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ModR_Id");
            Property(x => x.Codigo).HasColumnName("ModR_Codigo");
            Property(x => x.Descricao).HasColumnName("ModR_Descricao");
            Property(x => x.Arquivo).HasColumnName("ModR_Arquivo");
            Property(x => x.IdRevenda).HasColumnName("ModR_Revenda");

            this.HasOptional(t => t.Revenda)
                .WithMany()
                .HasForeignKey(t => t.IdRevenda);
        }
    }
}
