using System.ComponentModel.DataAnnotations.Schema;

namespace SIDomper.Dominio.Entidades
{
    public class RevendaEmail
    {
        public int Id { get; set; }
        public int RevendaId { get; set; }
        public string Email { get; set; }

        public virtual Revenda Revenda { get; set; }
    }
}
