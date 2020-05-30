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
    public class SolicitacaoMap : EntityTypeConfiguration<Solicitacao>
    {
        public SolicitacaoMap()
        {
            ToTable("Solicitacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Sol_Id");
            Property(x => x.Data).HasColumnName("Sol_Data");
            Property(x => x.Hora).HasColumnName("Sol_Hora");
            Property(x => x.ClienteId).HasColumnName("Sol_Cliente");
            Property(x => x.UsuarioAberturaId).HasColumnName("Sol_UsuarioAbertura");
            Property(x => x.ModuloId).HasColumnName("Sol_Modulo");
            Property(x => x.ProdutoId).HasColumnName("Sol_Produto");
            Property(x => x.Titulo).HasColumnName("Sol_Titulo");
            Property(x => x.Descricao).HasColumnName("Sol_Descricao");
            Property(x => x.Nivel).HasColumnName("Sol_Nivel");
            Property(x => x.Versao).HasColumnName("Sol_Versao");
            Property(x => x.Anexo).HasColumnName("Sol_Anexo");
            Property(x => x.AnalistaId).HasColumnName("Sol_Analista");
            Property(x => x.StatusId).HasColumnName("Sol_Status");
            Property(x => x.TipoId).HasColumnName("Sol_Tipo");
            Property(x => x.TempoPrevisto).HasColumnName("Sol_TempoPrevisto");
            Property(x => x.PrevisaoEntrega).HasColumnName("Sol_PrevisaoEntrega");
            Property(x => x.DesenvolvedorId).HasColumnName("Sol_Desenvolvedor");
            Property(x => x.DescricaoLiberacao).HasColumnName("Sol_DescricaoLiberacao");
            Property(x => x.UsuarioAtendeAtualId).HasColumnName("Sol_UsuarioAtendeAtual");
            Property(x => x.Contato).HasColumnName("Sol_Contato");
            Property(x => x.VersaoId).HasColumnName("Sol_VersaoId");
            Property(x => x.CategoriaId).HasColumnName("Sol_Categoria");

            this.HasRequired(x => x.Cliente)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.ClienteId);

            this.HasRequired(x => x.UsuarioAbertura)
                .WithMany(x => x.SolicitacoesUsuarioAbertura)
                .HasForeignKey(x => x.UsuarioAberturaId);

            this.HasOptional(x => x.Modulo)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.ModuloId);

            this.HasOptional(x => x.Produto)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.ProdutoId);

            this.HasOptional(x => x.UsuarioAnalista)
                .WithMany(x => x.SolicitacoesUsuarioAnalista)
                .HasForeignKey(x => x.AnalistaId);

            this.HasRequired(x => x.Status)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.StatusId);

            this.HasOptional(x => x.Tipo)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.TipoId);

            this.HasOptional(x => x.UsuarioDesenvolvedor)
                .WithMany(x => x.SolicitacoesUsuarioDesenvolvedor)
                .HasForeignKey(x => x.DesenvolvedorId);

            this.HasOptional(x => x.VersaoRelacao)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.VersaoId);

            this.HasOptional(x => x.Categoria)
                .WithMany(x => x.Solicitacoes)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}
