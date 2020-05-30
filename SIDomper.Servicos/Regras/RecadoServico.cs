using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Infra.EF;
using SIDomper.Infra.RepositorioDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Servicos.Regras
{
    public class RecadoServico
    {
        private readonly RecadoEF _rep;
        private readonly UsuarioServico _repUsuario;
        private readonly EnProgramas _tipoPrograma;
        private readonly StatusServico _statusServico;
        private readonly RecadoRepositorioDapper _recadoRepositorioDapper;

        public RecadoServico()
        {
            _rep = new RecadoEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Recado;
            _statusServico = new StatusServico();
            _recadoRepositorioDapper = new RecadoRepositorioDapper();
        }

        public Recado Novo(int usuarioId)
        {
            _repUsuario.PermissaoMensagem(usuarioId, _tipoPrograma, EnTipoManutencao.Incluir);

            var ServicoParametro = new ParametroServico();
            var ServicoStatus = new StatusServico();
            var ServicoTipo = new TipoServico();

            var parametro = ServicoParametro.ObterPorParametro(43, 0);

            var model = new Recado();
            model.Data = DateTime.Now.Date;
            model.Hora = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            model.Nivel = 2;

            model.UsuarioLcto = _repUsuario.ObterPorId(usuarioId);
            model.Status = ServicoStatus.ObterPorCodigo(Convert.ToInt32(parametro.Valor));
            model.Tipo = ServicoTipo.RetornarUmRegistroPrograma(EnTipos.Recado);

            return model;
        }

        public Recado ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<RecadoConsultaViewModel> Filtrar(RecadoFiltroViewModel filtro)
        {
            return _recadoRepositorioDapper.Filtrar(filtro).ToList();
        }

        public void Excluir(int idUsuario, Recado model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        private void Validar(Recado model)
        {
            if (string.IsNullOrEmpty(model.RazaoSocial))
                throw new Exception("Informe a Razão Social!");

            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo!");

            if (model.UsuarioLctoId == 0)
                throw new Exception("Informe o Usuário Lançamento!");

            if (model.UsuarioDestinoId == 0)
                throw new Exception("Informe o Usuário Destino!");

            if (model.StatusId == 0)
                throw new Exception("Informe o Status!");

            if (string.IsNullOrEmpty(model.DescricaoInicial))
                throw new Exception("Informe a Descrição Inicial!");

            if (!string.IsNullOrEmpty(model.DescricaoInicial))
            {
                if (model.Data > model.DataFinal)
                    throw new Exception("Data do Lançamento maior que Data do Encerramento!");

                var ServicoParametro = new ParametroServico();
                var parametro = ServicoParametro.ObterPorParametro(44, 0);
                if (parametro == null || string.IsNullOrEmpty(parametro.Valor))
                    throw new Exception("Informe o Status de Enceramento dos Recados nos parâmetros do Sistema!");

                if (model.ModoAbrEnc == "E" && string.IsNullOrEmpty(model.DescricaoFinal))
                    throw new Exception("Informe a Descrição Final!");

                if (model.ModoAbrEnc == "E")
                {
                    var status = _statusServico.ObterPorCodigo(Convert.ToInt32(parametro.Valor));
                    if (status != null)
                        model.StatusId = status.Id;
                }
            }
        }

        public void Salvar(Recado model)
        {
            Validar(model);

            _rep.Salvar(model);
            _rep.Commit();

            // TODO: tirar o comentario
            //EnviarEmailAoSalvar(model);
        }

        public Recado Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao;
            var model = new Recado();
            model = _rep.ObterPorId(id);

            var Usuario = _repUsuario.ObterPorId(idUsuario);
            if (Usuario.Adm)
            {
                permissao = true;
                permissaoMensagem = "OK";
            }
            else
            {
                permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
                permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            }
            return model;
        }

        private void EnviarEmailAoSalvar(Recado model)
        {
            if(string.IsNullOrEmpty(model.ModoAbrEnc))
            {
                if (string.IsNullOrEmpty(model.DescricaoFinal))
                    model.ModoAbrEnc = "A";
                else
                    model.ModoAbrEnc = "E";
            }

            if (model.ModoAbrEnc == "A")
                EnviarEmail(model.UsuarioLctoId, model.UsuarioDestinoId, model.Id);
            else
                EnviarEmail(model.UsuarioDestinoId, model.UsuarioLctoId, model.Id);
        }

        private void EnviarEmail(int idUsuarioOrigem, int idUsuarioDestino, int id)
        {
            if (id == 0 || idUsuarioOrigem == 0 || idUsuarioDestino == 0)
                return;

            string assunto = "Domper Recado - " + id.ToString("000000");

            var ServicoUsuario = new UsuarioServico();
            var usuario = ServicoUsuario.ObterPorId(idUsuarioDestino);
            string email = usuario.Email;

            if (!string.IsNullOrWhiteSpace(email))
            {
                ContaEmailServico conta = new ContaEmailServico();

                var model = ObterPorId(id);
                if (model != null)
                    conta.EnviarEmail(idUsuarioDestino, email, "", assunto, TextoEmail(model), "");
            }
        }

        private string TextoEmail(Recado model)
        {
            string ModoAbrEnc = "E";
            string status = " (Encerrado)";

            if (string.IsNullOrWhiteSpace(model.DescricaoFinal))
            {
                ModoAbrEnc = "A";
                status = " (Aberto)";
            }

            var sb = new StringBuilder();
            sb.AppendLine("Recado Sistema Domper: " + status);
            sb.AppendLine("Id: " + model.Id.ToString("000000"));
            sb.AppendLine("Data: " + model.Data.ToString() + " Hora: " + model.Hora.ToString());
            sb.AppendLine("Usuário Lcto: " + model.UsuarioLcto.Nome);
            sb.AppendLine("Nínvel: " + model.Nivel.ToString());
            sb.AppendLine("Razão Social: " + model.Cliente.Nome);
            sb.AppendLine("Endereco: " + model.Cliente.Endereco);
            sb.AppendLine("Telefone: " + model.Cliente.Telefone);
            sb.AppendLine("Contato: " + model.Contato);
            sb.AppendLine("Usuário Destino: " + model.UsuarioDestino.Nome);
            sb.AppendLine("Tipo: " + model.Tipo.Nome);
            sb.AppendLine("Status: " + model.Status.Nome);
            sb.AppendLine("Descrição:");
            sb.AppendLine(model.DescricaoInicial);

            if (ModoAbrEnc == "E")
                sb.AppendLine("Descrição Encerramento: " + model.DescricaoFinal);

            return sb.ToString();
        }
    }
}
