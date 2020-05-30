using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class DepartamentoEmail
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public string Email { get; set; }

        public virtual Departamento Departamento { get; set; }
    }
}
