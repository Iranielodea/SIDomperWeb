﻿using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF.Map
{
    public class RamalMap : EntityTypeConfiguration<Ramal>
    {
        public RamalMap()
        {
            ToTable("Ramal");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Ram_Id");
            Property(x => x.Departamento).HasColumnName("Ram_Departamento");
        }
    }
}
