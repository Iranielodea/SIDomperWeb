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
    public class RecadoMap : EntityTypeConfiguration<Recado>
    {
        public RecadoMap() 
        {
            ToTable("Recado");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Rec_Id");
            Property(x => x.Data).HasColumnName("Rec_Data");
            Property(x => x.Hora).HasColumnName("Rec_Hora");
            Property(x => x.UsuarioLctoId).HasColumnName("Rec_UsuarioLcto");
            Property(x => x.Nivel).HasColumnName("Rec_Nivel");
            Property(x => x.ClienteId).HasColumnName("Rec_Cliente");
            Property(x => x.RazaoSocial).HasColumnName("Rec_RazaoSocial");
            Property(x => x.Fantasia).HasColumnName("Rec_Fantasia");
            Property(x => x.Endereco).HasColumnName("Rec_Endereco");
            Property(x => x.Telefone).HasColumnName("Rec_Telefone");
            Property(x => x.Contato).HasColumnName("Rec_Contato");
            Property(x => x.UsuarioDestinoId).HasColumnName("Rec_UsuarioDestino");
            Property(x => x.TipoId).HasColumnName("Rec_Tipo");
            Property(x => x.StatusId).HasColumnName("Rec_Status");
            Property(x => x.DescricaoInicial).HasColumnName("Rec_DescricaoInicial");
            Property(x => x.DataFinal).HasColumnName("Rec_DataFinal");
            Property(x => x.HoraFinal).HasColumnName("Rec_HoraFinal");
            Property(x => x.DescricaoFinal).HasColumnName("Rec_DescricaoFinal");

            this.HasRequired(x => x.UsuarioLcto)
                .WithMany(x => x.RecadosLcto)
                .HasForeignKey(x => x.UsuarioLctoId);

            this.HasRequired(x => x.UsuarioDestino)
                .WithMany(x => x.RecadosDestino)
                .HasForeignKey(x => x.UsuarioDestinoId);

            this.HasOptional(x => x.Cliente)
                .WithMany(x => x.Recados)
                .HasForeignKey(x => x.ClienteId);

            this.HasOptional(x => x.Tipo)
                .WithMany(x => x.Recados)
                .HasForeignKey(x => x.TipoId);

            this.HasOptional(x => x.Status)
                .WithMany(x => x.Recados)
                .HasForeignKey(x => x.StatusId);
        }
    }
}
