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
    public class ChamadoMap : EntityTypeConfiguration<Chamado>
    {
        public ChamadoMap()
        {
            ToTable("Chamado");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Cha_Id");
            Property(x => x.DataAbertura).HasColumnName("Cha_DataAbertura");
            Property(x => x.HoraAbertura).HasColumnName("Cha_HoraAbertura");
            Property(x => x.ClienteId).HasColumnName("Cha_Cliente");
            Property(x => x.UsuarioAberturaId).HasColumnName("Cha_UsuarioAbertura");
            Property(x => x.Contato).HasColumnName("Cha_Contato");
            Property(x => x.Nivel).HasColumnName("Cha_Nivel");
            Property(x => x.TipoId).HasColumnName("Cha_Tipo");
            Property(x => x.StatusId).HasColumnName("Cha_Status");
            Property(x => x.Descricao).HasColumnName("Cha_Descricao");
            Property(x => x.ModuloId).HasColumnName("Cha_Modulo");
            Property(x => x.ProdutoId).HasColumnName("Cha_Produto");
            Property(x => x.UsuarioAtendeAtualId).HasColumnName("Cha_UsuarioAtendeAtual");
            Property(x => x.HoraAtendeAtual).HasColumnName("Cha_HoraAtendeAtual");
            Property(x => x.TipoMovimento).HasColumnName("Cha_TipoMovimento");

            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.Chamados)
                .HasForeignKey(t => t.ClienteId);

            this.HasRequired(t => t.UsuarioAbertura)
                .WithMany(t => t.Chamados)
                .HasForeignKey(t => t.UsuarioAberturaId);

            this.HasRequired(t => t.Tipo)
                .WithMany(t => t.Chamados)
                .HasForeignKey(t => t.TipoId);

            this.HasRequired(t => t.Status)
                .WithMany(t => t.Chamados)
                .HasForeignKey(t => t.StatusId);

            this.HasOptional(t => t.Modulo)
                .WithMany(t => t.Chamados)
                .HasForeignKey(t => t.ModuloId);

            this.HasOptional(t => t.Produto)
                .WithMany(t => t.Chamados)
                .HasForeignKey(t => t.ProdutoId);

            //this.HasOptional(t => t.UsuarioAtendeAtual)
            //    .WithMany(t => t.Chamados)
            //    .HasForeignKey(t => t.UsuarioAtendeAtualId);
        }
    }
}
