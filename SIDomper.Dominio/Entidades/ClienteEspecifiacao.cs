using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class ClienteEspecifiacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Item { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public string Anexo { get; set; }
        public string Nome { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

    public class ClienteEspecifiacaoConsulta
    {
        public int Id { get; set; }
        public int Item { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
    }
}
