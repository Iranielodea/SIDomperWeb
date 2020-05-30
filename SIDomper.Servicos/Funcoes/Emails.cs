using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Funcoes
{
    public class Emails
    {
        public int Porta { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MeuEmail { get; set; }
        public string Destinatario { get; set; }
        public string CopiaOculta { get; set; }
        public string Texto { get; set; }
        public string Assunto { get; set; }
        public string ArquivoAnexo { get; set; }
        public bool SSL { get; set; }

        public bool EnviarEmail()
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mail = new MailMessage();
                //mail.IsBodyHtml = true;
                if (!string.IsNullOrEmpty(ArquivoAnexo))
                {
                    Attachment anexar = new Attachment(ArquivoAnexo);
                    mail.Attachments.Add(anexar);
                }

                // ignorar a porta do cadastro Conta_Email
                // deixar fixa a 587
                Porta = 587;

                //smtp.Host = "smtp.live.com";
                smtp.Host = Host;
                smtp.Port = Porta;
                Password = Password;
                //smtp.EnableSsl = false;
                smtp.EnableSsl = SSL;
                //smtp.UseDefaultCredentials = false;
                smtp.UseDefaultCredentials = false;
                //credinciais
                smtp.Credentials = new NetworkCredential(MeuEmail, Password);
                mail.From = new MailAddress(MeuEmail);
                //lista de Emails para copia ocultas
                if (!string.IsNullOrEmpty(CopiaOculta))
                {
                    var listaBcc = RetornarListaEmail(CopiaOculta);
                    foreach (var item in listaBcc)
                    {
                        mail.Bcc.Add(item);
                    }
                }
                //lista de Emails para destinatarios
                var listaDestinatario = RetornarListaEmail(Destinatario);
                foreach(var item in listaDestinatario)
                {
                    mail.To.Add(new MailAddress(item));
                }

                mail.Subject = Assunto;
                mail.Body = Texto;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        private List<string> RetornarListaEmail(string email)
        {
            string car = "";
            string em = "";
            int quantChar = email.Length;
            var lista = new List<string>();
            bool passou = false;

            for (int i = 0; i < quantChar; i++)
            {
                car = email.Substring(i, 1);
                if (car != ";")
                {
                    em = em + car;
                    passou = false;
                }
                else
                {
                    lista.Add(em);
                    passou = true;
                    em = "";
                }
            }

            if (passou == false)
                lista.Add(em);

            return lista;
        }
    }
}
