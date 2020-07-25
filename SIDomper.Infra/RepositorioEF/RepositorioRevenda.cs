using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioRevenda : RepositorioBaseEF<Revenda>, IRepositorioRevenda
    {
        public RepositorioRevenda(Contexto contexto) : base(contexto)
        {
        }

        public string RetornarEmails(Revenda model)
        {
            string email = "";
            foreach (var item in model.RevendaEmails)
            {
                if (email == "")
                    email = item.Email;
                else
                    email = email + ";" + item.Email;
            }
            return email;
        }
    }
}
