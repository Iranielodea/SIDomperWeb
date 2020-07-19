using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoContaEmail : IServicoContaEmail
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ContaEmailConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoContaEmail(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ContaEmailConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.ContaEmail;
        }

        public ContaEmail Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void EnviarEmail(int idUsuario, string destinatiario, string copiaOculta, string assunto, string texto, string arquivoAnexo, bool aviso = false)
        {
            var usuario = _uow.RepositorioUsuario.find(idUsuario);

            if (usuario != null && usuario.ContaEmail != null)
            {
                var email = new Email
                {
                    Porta = usuario.ContaEmail.Porta,
                    ArquivoAnexo = arquivoAnexo,
                    Assunto = assunto,
                    CopiaOculta = copiaOculta,
                    Destinatario = destinatiario,
                    Host = usuario.ContaEmail.SMTP,
                    MeuEmail = usuario.ContaEmail.Email,
                    Password = usuario.ContaEmail.Senha,
                    Texto = texto,
                    UserName = usuario.ContaEmail.Nome,
                    SSL = usuario.ContaEmail.AutenticarSSL
                };

                email.EnviarEmail();
            }
        }

        public void Excluir(ContaEmail model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioContaEmail.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ContaEmailConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" CtaEm_Id as Id,");
            sb.AppendLine(" CtaEm_Codigo as Codigo,");
            sb.AppendLine(" CtaEm_Nome as Nome,");
            sb.AppendLine(" CtaEm_Email as Email");
            sb.AppendLine(" FROM Conta_Email");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE CtaEm_Id > 0");
            }

            if (ativo == "A")
                sb.AppendLine(" AND CtaEm_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND CtaEm_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public ContaEmail Novo(int idUsuario)
        {
            var contaEmail = new ContaEmail();
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            contaEmail.Codigo = ProximoCodigo();
            contaEmail.Ativo = true;
            return contaEmail;
        }

        public ContaEmail ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioContaEmail.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Conta não Cadastrada!");
            return model;
        }

        public ContaEmail ObterPorId(int id)
        {
            return _uow.RepositorioContaEmail.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(ContaEmail model)
        {
            if (model.Codigo <= 0)
                _uow.Notificacao.Add("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (string.IsNullOrWhiteSpace(model.Email))
                _uow.Notificacao.Add("Informe o Email!");

            if (string.IsNullOrWhiteSpace(model.Senha))
                _uow.Notificacao.Add("Informe a Senha!");

            if (model.Porta <= 0)
                _uow.Notificacao.Add("Informe a Porta!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            _uow.RepositorioContaEmail.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioContaEmail.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
