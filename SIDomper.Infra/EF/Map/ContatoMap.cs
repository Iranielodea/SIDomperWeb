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
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Cont_Id");
            Property(x => x.ClienteId).HasColumnName("Cont_Cliente");
            Property(x => x.OrcamentoId).HasColumnName("Cont_Orcamento");
            Property(x => x.Nome).HasColumnName("Cont_Nome");
            Property(x => x.Fone1).HasColumnName("Cont_Fone1");
            Property(x => x.Fone2).HasColumnName("Cont_Fone2");
            Property(x => x.Departamento).HasColumnName("Cont_Depto");
            Property(x => x.Email).HasColumnName("Cont_Email");

            this.HasOptional(t => t.Orcamento)
                .WithMany(t => t.Contatos)
                .HasForeignKey(t => t.OrcamentoId);

            this.HasOptional(t => t.Cliente)
                .WithMany(t => t.Contatos)
                .HasForeignKey(t => t.ClienteId);
        }
    }
}
