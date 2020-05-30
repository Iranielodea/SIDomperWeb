using System.Collections.Generic;

namespace SIDomper.Dominio.Entidades
{
    public class ContaEmail
    {
        public ContaEmail()
        {
            Usuarios = new List<Usuario>();
        }
        public int Id { get;set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SMTP { get; set; }
        public int Porta { get; set; }
        public bool Ativo { get; set; }
        public bool Autenticar { get; set; }
        public bool AutenticarSSL { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }

    public class ContaEmailConsulta
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
