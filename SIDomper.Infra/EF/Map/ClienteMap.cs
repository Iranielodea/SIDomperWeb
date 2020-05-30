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
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Cli_Id");
            Property(x => x.Codigo).HasColumnName("Cli_Codigo");
            Property(x => x.Nome).HasColumnName("Cli_Nome");
            Property(x => x.Fantasia).HasColumnName("Cli_Fantasia");
            Property(x => x.Dcto).HasColumnName("Cli_Dcto");
            Property(x => x.Enquadramento).HasColumnName("Cli_Enquadramento");
            Property(x => x.Endereco).HasColumnName("Cli_Endereco");
            Property(x => x.Telefone).HasColumnName("Cli_Telefone");
            Property(x => x.Contato).HasColumnName("Cli_Contato");
            Property(x => x.RevendaId).HasColumnName("Cli_Revenda");
            Property(x => x.Ativo).HasColumnName("Cli_Ativo");
            Property(x => x.Restricao).HasColumnName("Cli_Restricao");
            Property(x => x.UsuarioId).HasColumnName("Cli_Usuario");
            Property(x => x.Versao).HasColumnName("Cli_Versao");
            Property(x => x.Logradouro).HasColumnName("Cli_Logradouro");
            Property(x => x.Bairro).HasColumnName("Cli_Bairro");
            Property(x => x.CEP).HasColumnName("Cli_CEP");
            Property(x => x.CidadeId).HasColumnName("Cli_Cidade");
            Property(x => x.Fone1).HasColumnName("Cli_Fone1");
            Property(x => x.Fone2).HasColumnName("Cli_Fone2");
            Property(x => x.Celular).HasColumnName("Cli_Celular");
            Property(x => x.OutroFone).HasColumnName("Cli_FoneOutro");
            Property(x => x.ContatoFinanceiro).HasColumnName("Cli_ContatoFinanceiro");
            Property(x => x.FoneContatoFinanceiro).HasColumnName("Cli_ContatoFinanceiroFone");
            Property(x => x.ContatoCompraVenda).HasColumnName("Cli_ContatoCompraVenda");
            Property(x => x.FoneContatoCompraVenda).HasColumnName("Cli_ContatoCompraVendaFone");
            Property(x => x.IE).HasColumnName("Cli_IE");
            Property(x => x.RepresentanteLegal).HasColumnName("Cli_RepreLegal");
            Property(x => x.CPFRepresentanteLegal).HasColumnName("Cli_RepreLegalCPF");
            Property(x => x.EmpresaVinculada).HasColumnName("Cli_EmpresaVinculada");
            Property(x => x.Latitude).HasColumnName("Cli_Latitude");
            Property(x => x.Longitude).HasColumnName("Cli_Longitude");
            Property(x => x.Perfil).HasColumnName("Cli_Perfil");

            this.HasRequired(t => t.Revenda)
                .WithMany(t => t.Clientes)
                .HasForeignKey(t => t.RevendaId);

            this.HasOptional(t => t.Cidade)
                .WithMany(t => t.Clientes)
                .HasForeignKey(t => t.CidadeId);

            this.HasOptional(t => t.Usuario)
               .WithMany(t => t.Clientes)
               .HasForeignKey(t => t.UsuarioId);
        }
    }
}
