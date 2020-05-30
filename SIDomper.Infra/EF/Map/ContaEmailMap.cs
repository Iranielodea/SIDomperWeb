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
    public class ContaEmailMap : EntityTypeConfiguration<ContaEmail>
    {
        public ContaEmailMap()
        {
            ToTable("Conta_Email");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("CtaEm_Id");
            Property(x => x.Codigo).HasColumnName("CtaEm_Codigo");
            Property(x => x.Nome).HasColumnName("CtaEm_Nome");
            Property(x => x.Email).HasColumnName("CtaEm_Email");
            Property(x => x.Senha).HasColumnName("CtaEm_Senha");
            Property(x => x.SMTP).HasColumnName("CtaEm_SMTP");
            Property(x => x.Porta).HasColumnName("CtaEm_Porta");
            Property(x => x.Ativo).HasColumnName("CtaEm_Ativo");
            Property(x => x.Autenticar).HasColumnName("CtaEm_Autenticar");
            Property(x => x.AutenticarSSL).HasColumnName("CtaEm_AutenticarSSL");
        }
    }
}
