using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SIDomper.Dominio.Entidades;

namespace SIDomper.Infra.EF.Map
{
    public class DepartamentoAcessoMap : EntityTypeConfiguration<DepartamentoAcesso>
    {
        public DepartamentoAcessoMap()
        {
            ToTable("Departamento_Acesso");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("DepAc_Id");
            Property(x => x.DepartamentoId).HasColumnName("DepAc_Departamento");
            Property(x => x.Programa).HasColumnName("DepAc_Programa");
            Property(x => x.Acesso).HasColumnName("DepAc_Acesso");
            Property(x => x.Incluir).HasColumnName("DepAc_Incluir");
            Property(x => x.Editar).HasColumnName("DepAc_Editar");
            Property(x => x.Excluir).HasColumnName("DepAc_Excluir");
            Property(x => x.Relatorio).HasColumnName("DepAc_Relatorio");
            this.Ignore(x => x.DescricaoPrograma);

            this.HasRequired(x => x.Departamento)
                .WithMany(x => x.DepartamentoAcessos)
                .HasForeignKey(x => x.DepartamentoId);
        }
    }
}
