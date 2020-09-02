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
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Usu_Id");
            Property(x => x.Codigo).HasColumnName("Usu_Codigo");
            Property(x => x.Adm).HasColumnName("Usu_Adm");
            Property(x => x.Ativo).HasColumnName("Usu_Ativo");
            Property(x => x.ClienteId).HasColumnName("Usu_Cliente");
            Property(x => x.ContaEmailId).HasColumnName("Usu_ContaEmail");
            Property(x => x.DepartamentoId).HasColumnName("Usu_Departamento");
            Property(x => x.Email).HasColumnName("Usu_Email");
            Property(x => x.Nome).HasColumnName("Usu_Nome");
            Property(x => x.Notificar).HasColumnName("Usu_Notificar");
            Property(x => x.OnLine).HasColumnName("Usu_OnLine");
            Property(x => x.Password).HasColumnName("Usu_Password");
            Property(x => x.RevendaId).HasColumnName("Usu_Revenda");
            Property(x => x.UserName).HasColumnName("Usu_UserName");
            Property(x => x.Telefone).HasColumnName("Usu_Telefone");

            this.HasRequired(t => t.Departamento)
                .WithMany(x => x.Usuarios )
                .HasForeignKey(t => t.DepartamentoId);

            this.HasOptional(t => t.ContaEmail)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(t => t.ContaEmailId);

            this.HasOptional(t => t.Revenda)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(t => t.RevendaId);
        }
    }
}
