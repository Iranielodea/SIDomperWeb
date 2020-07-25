using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioContaEmail : RepositorioBaseEF<ContaEmail>, IRepositorioContaEmail
    {
        private readonly Contexto _contexto;

        public RepositorioContaEmail(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void EnviarEmail(int idUsuario, string destinatiario, string copiaOculta, string assunto, string texto, string arquivoAnexo, bool aviso = false)
        {
            if (idUsuario > 0)
            {
                var usuario = _contexto.Usuarios.Find(idUsuario);
                if (usuario != null)
                {
                    if (usuario.ContaEmail != null)
                    {
                        var email = new Email();

                        email.Porta = usuario.ContaEmail.Porta;
                        email.ArquivoAnexo = arquivoAnexo;
                        email.Assunto = assunto;
                        email.CopiaOculta = copiaOculta;
                        email.Destinatario = destinatiario;
                        email.Host = usuario.ContaEmail.SMTP;
                        email.MeuEmail = usuario.ContaEmail.Email;
                        email.Password = usuario.ContaEmail.Senha;
                        email.Texto = texto;
                        email.UserName = usuario.ContaEmail.Nome;
                        email.SSL = usuario.ContaEmail.AutenticarSSL;

                        email.EnviarEmail();
                    }
                }
            }
        }
    }
}
