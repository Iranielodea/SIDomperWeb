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
    public class OrcamentoMap : EntityTypeConfiguration<Orcamento>
    {
        public OrcamentoMap()
        {
            ToTable("Orcamento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Orc_Id");
            Property(x => x.Numero).HasColumnName("Orc_Numero");
            Property(x => x.Data).HasColumnName("Orc_Data");
            Property(x => x.UsuarioId).HasColumnName("Orc_Usuario");
            Property(x => x.ProspectId).HasColumnName("Orc_Prospect");
            Property(x => x.Observacao).HasColumnName("Orc_Observacao");
            Property(x => x.ObservacaoEmail).HasColumnName("Orc_ObservacaoEmail");
            Property(x => x.ClienteId).HasColumnName("Orc_Cliente");
            Property(x => x.Situacao).HasColumnName("Orc_Situacao");
            Property(x => x.FormaPagtoId).HasColumnName("Orc_FormaPagto");
            Property(x => x.RazaoSocial).HasColumnName("Orc_RazaoSocial");
            Property(x => x.Fantasia).HasColumnName("Orc_Fantasia");
            Property(x => x.Endereco).HasColumnName("Orc_Endereco");
            Property(x => x.Telefone).HasColumnName("Orc_Telefone");
            Property(x => x.Contato).HasColumnName("Orc_Contato");
            Property(x => x.Dcto).HasColumnName("Orc_Dcto");
            Property(x => x.TipoId).HasColumnName("Orc_Tipo");
            Property(x => x.SubTipo).HasColumnName("Orc_SubTipo");
            Property(x => x.EmailEnviado).HasColumnName("Orc_EmailEnviado");
            Property(x => x.DataSituacao).HasColumnName("Orc_DataSituacao");
            Property(x => x.Logradouro).HasColumnName("Orc_Logradouro");
            Property(x => x.Bairro).HasColumnName("Orc_Bairro");
            Property(x => x.CEP).HasColumnName("Orc_CEP");
            Property(x => x.CidadeId).HasColumnName("Orc_Cidade");
            Property(x => x.Enquadramento).HasColumnName("Orc_Enquadramento");
            Property(x => x.Fone1).HasColumnName("Orc_Fone1");
            Property(x => x.Fone2).HasColumnName("Orc_Fone2");
            Property(x => x.Celular).HasColumnName("Orc_Celular");
            Property(x => x.OutroFone).HasColumnName("Orc_FoneOutro");
            Property(x => x.ContatoFinanceiro).HasColumnName("Orc_ContatoFinanceiro");
            Property(x => x.FoneContatoFinanceiro).HasColumnName("Orc_ContatoFinanceiroFone");
            Property(x => x.ContatoCompraVenda).HasColumnName("Orc_ContatoCompraVenda");
            Property(x => x.FoneContatoCompraVenda).HasColumnName("Orc_ContatoCompraVendaFone");
            Property(x => x.IE).HasColumnName("Orc_IE");
            Property(x => x.RepresentanteLegal).HasColumnName("Orc_RepreLegal");
            Property(x => x.CPFRespresentanteLegal).HasColumnName("Orc_RepreLegalCPF");

            this.HasRequired(t => t.Usuario)
                .WithMany(x => x.Orcamentos)
                .HasForeignKey(t => t.UsuarioId);

            this.HasOptional(t => t.Prospect)
                .WithMany(x => x.Orcamentos)
                .HasForeignKey(t => t.ProspectId);

            this.HasOptional(t => t.Cliente)
                .WithMany(x => x.Orcamentos)
                .HasForeignKey(t => t.ClienteId);

            this.HasRequired(t => t.FormaPagto)
                .WithMany(x => x.Orcamentos)
                .HasForeignKey(t => t.FormaPagtoId);

            this.HasRequired(t => t.Tipo)
                .WithMany(x => x.Orcamentos)
                .HasForeignKey(t => t.TipoId);

            this.HasOptional(t => t.Cidade)
                .WithMany(x => x.Orcamentos)
                .HasForeignKey(t => t.CidadeId);
        }
    }
}
