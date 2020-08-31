using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System.Linq;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioDepartamento : RepositorioBaseEF<Departamento>, IRepositorioDepartamento
    {
        private readonly Contexto _contexto;

        public RepositorioDepartamento(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public string RetornarEmails(Departamento departamento)
        {
            string email = "";
            foreach (var item in departamento.DepartamentosEmail)
            {
                if (email == "")
                    email = email + item.Email;
                else
                    email = email + ";" + item.Email;
            }

            return email;
        }

        public Departamento Duplicar(Departamento model)
        {
            var modelTemp = _contexto.Departamentos.First(x => x.Id == model.Id);
            modelTemp.Id = 0;
            modelTemp.Nome = model.Nome + "01";

            //=================================================================
            // email
            var Email = _contexto.DepartamentoEmails.AsNoTracking().Where(x => x.DepartamentoId == model.Id).ToList();

            foreach (var item in Email)
            {
                item.Departamento = modelTemp;
                item.Id = 0;
                _contexto.DepartamentoEmails.Add(item);
            }

            //=================================================================
            // Acesso

            var Acesso = _contexto.DepartamentoAcessos.AsNoTracking().Where(x => x.DepartamentoId == model.Id).ToList();
            foreach (var item in Acesso)
            {
                item.Departamento = modelTemp;
                item.Id = 0;
                _contexto.DepartamentoAcessos.Add(item);
            }

            Salvar(modelTemp);

            return modelTemp;
        }

        public bool SolicitacaoPermissaoAnalise(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitaAnalise);
        }

        public bool SolicitacaoPermissaoOcorrenciaGeral(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoOcorrenciaGeral);
        }

        public bool SolicitacaoPermissaoOcorrenciaRegra(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoOcorrenciaRegra);
        }

        public bool SolicitacaoPermissaoOcorrenciaTecnica(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoOcorrenciaTecnica);
        }

        public bool SolicitacaoPermissaoQuadro(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoQuadro);
        }

        public bool PermissaoAbertura(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitaAbertura);
        }

        public bool MostrarAnexos(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.MostrarAnexos);
        }

        public bool SolicitacaoPermissaoStatus(Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            return (usuario.Departamento.SolicitacaoStatus);
        }
    }
}
