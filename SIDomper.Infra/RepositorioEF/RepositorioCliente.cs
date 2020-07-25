using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioCliente : RepositorioBaseEF<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(Contexto contexto) : base(contexto)
        {
        }

        public string EmailsDoCliente(Cliente cliente)
        {
            if (cliente.Emails == null)
                return "";

            string email = "";
            foreach (var item in cliente.Emails)
            {
                if (item.Notificar)
                {
                    if (email == "")
                        email = email + item.Email;
                    else
                        email = email + ";" + item.Email;
                }
            }
            return email;
        }
    }
}
