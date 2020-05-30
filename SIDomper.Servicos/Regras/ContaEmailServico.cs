using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using SIDomper.Servicos.Funcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class ContaEmailServico
    {
        private readonly ContaEmailEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public ContaEmailServico()
        {
            _rep = new ContaEmailEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.ContaEmail;
        }

        public IEnumerable<ContaEmailConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, ativo, contem);
        }

        public ContaEmail ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public ContaEmail Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";

            return _rep.ObterPorId(id);
        }

        public void Salvar(ContaEmail model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");
            if (string.IsNullOrWhiteSpace(model.Email))
                throw new Exception("Informe o Email!");
            if (string.IsNullOrWhiteSpace(model.Senha))
                throw new Exception("Informe a Senha!");
            if (string.IsNullOrWhiteSpace(model.SMTP))
                throw new Exception("Informe o SMTP!");
            if (model.Porta <= 0)
                throw new Exception("Informe a Porta!");

            _rep.Salvar(model);
            _rep.Commit();
        }

        public void EnviarEmail(int idUsuario, string destinatiario, string copiaOculta, string assunto, string texto, string arquivoAnexo, bool aviso=false)
        {
            if (idUsuario > 0)
            {
                var usuarioServico = new UsuarioServico();

                var usuario = usuarioServico.ObterPorId(idUsuario);
                if (usuario != null)
                {
                    if (usuario.ContaEmail != null)
                    {
                        var email = new Emails();

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

        public ContaEmail Novo(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new ContaEmail();
            model.Codigo = _rep.ProximoCodigo();
            model.Ativo = true;

            return model;
        }

        public ContaEmail Editar(int idUsuario, int id, ref bool permissao)
        {
            permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            return _rep.ObterPorId(id);
        }

        public void Excluir(int idUsuario, ContaEmail model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        public ContaEmail ObterPorCodigo(int codigo)
        {
            var model = _rep.ObterPorCodigo(codigo);

            if (model != null)
            {
                if (model.Ativo == false)
                    throw new Exception("Registro Inativo!");
            }
            return model;
        }

        public void Relatorio(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, EnProgramas.ContaEmail, EnTipoManutencao.Imprimir);
        }
    }
}
