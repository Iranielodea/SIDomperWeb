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
    public class AgendamentoMap : EntityTypeConfiguration<Agendamento>
    {
        public AgendamentoMap()
        {
            ToTable("Agendamento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Age_Id");
            Property(x => x.Data).HasColumnName("Age_Data");
            Property(x => x.Hora).HasColumnName("Age_Hora");
            Property(x => x.UsuarioId).HasColumnName("Age_Usuario");
            Property(x => x.ClienteId).HasColumnName("Age_Cliente");
            Property(x => x.Contato).HasColumnName("Age_Contato");
            Property(x => x.Programa).HasColumnName("Age_Programa");
            Property(x => x.TipoId).HasColumnName("Age_Tipo");
            Property(x => x.StatusId).HasColumnName("Age_Status");
            Property(x => x.Descricao).HasColumnName("Age_Descricao");
            Property(x => x.Motivo).HasColumnName("Age_Motivo");
            Property(x => x.VisitaId).HasColumnName("Age_Visita");
            Property(x => x.AtividadeId).HasColumnName("Age_Atividade");
            Property(x => x.NomeCliente).HasColumnName("Age_NomeCliente");

            this.HasRequired(x => x.Usuario)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.UsuarioId);

            this.HasRequired(x => x.Cliente)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.ClienteId);

            this.HasRequired(x => x.Tipo)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.TipoId);

            this.HasRequired(x => x.Status)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.StatusId);

            this.HasRequired(x => x.Visita)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.VisitaId);

            this.HasRequired(x => x.Chamado)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.AtividadeId);
        }
    }
}
