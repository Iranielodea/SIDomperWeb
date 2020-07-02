using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Constantes;
using SIDomper.Infra.ADO;
using SIDomper.Infra.EF;
using SIDomper.Dominio.Enumeracao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class UsuarioServico
    {
        private readonly UsuarioEF _rep;
        private readonly EnProgramas _tipoPrograma;

        public UsuarioServico()
        {
            _rep = new UsuarioEF();
            _tipoPrograma = EnProgramas.Usuario;
        }

        public Usuario ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Usuario ObterPorIdNull(int? id)
        {
            return _rep.ObterPorIdNull(id);
        }

        public IEnumerable<UsuarioConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, ativo, contem);
        }

        public IEnumerable<UsuarioConsulta> Filtrar(UsuarioFiltro filtro)
        {
            return _rep.Filtrar(filtro);
        }

        public Usuario Novo(int idUsuario)
        {
            PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);

            var model = new Usuario();
            model.Ativo = true;

            return model;
        }

        public Usuario Editar(int idUsuario, int id, ref bool permissao)
        {
            permissao = PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            var model = _rep.ObterPorId(id);
            if (model != null)
                model.Clientes.FirstOrDefault(x => x.Id == model.ClienteId);
            return model;
        }

        public void Excluir(int idUsuario, Usuario model)
        {
            PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        public Usuario ObterPorCodigo(int codigo, bool valida = true)
        {
            var model = _rep.ObterPorCodigo(codigo);

            if (model != null)
            {
                if (valida)
                {
                    if (model.Ativo == false)
                        throw new System.Exception("Registro Inativo!");
                }
            }
            return model;
        }

        public void Relatorio(int idUsuario)
        {
            PermissaoMensagem(idUsuario, EnProgramas.Usuario, EnTipoManutencao.Imprimir);
        }

        public Usuario ObterPorUsuario(string userName, string senha)
        {
            return RetornarUsuarioValido(userName, senha);
            //var model = _rep.ObterPorUsuario(userName);

            //if (model == null)
            //    throw new Exception("Usuário não Cadastrado!");

            //if (model.Password != senha)
            //    throw new Exception("Senha Inválida!");

            //if (model.Ativo == false)
            //    throw new Exception("Usuário Inativo!");

            //if (!HorarioUsoSistema(userName, senha))
            //    throw new Exception(Mensagem.MensagemHorarioAcessoSistema);

            //return model;
        }

        private Usuario RetornarUsuarioValido(string userName, string senha)
        {
            var model = _rep.ObterPorUsuario(userName);

            if (model == null)
                throw new Exception("Usuário não Cadastrado!");

            if (model.Password != senha)
                throw new Exception("Senha Inválida!");

            if (model.Ativo == false)
                throw new Exception("Usuário Inativo!");

            if (!HorarioUsoSistema(userName, senha))
                throw new Exception(Mensagem.MensagemHorarioAcessoSistema);

            return model;
        }

        public List<UsuarioPermissaoDepartamento> ObterPermissaoPorUsuario(string userName, string senha)
        {
            var usuario = RetornarUsuarioValido(userName, senha);

            return _rep.ObterPermissao(userName, senha);
        }

        public bool HorarioUsoSistema(string userName, string senha, int idUsuario = 0)
        {
            bool resultado = true;
            Usuario usuario = new Usuario();

            if (idUsuario > 0)
                usuario = _rep.ObterPorId(idUsuario);
            else
            {
                usuario = _rep.ObterPorUsuario(userName);
                if (usuario != null)
                {
                    if (usuario.Password != senha)
                        throw new Exception("Usuário não cadastrado!");
                }
            }

            if (usuario != null)
            {
                if (usuario.Departamento.HoraInicial != null && usuario.Departamento.HoraFinal != null)
                {
                    TimeSpan horaAtual = DateTime.Now.TimeOfDay;

                    if (horaAtual >= usuario.Departamento.HoraInicial && horaAtual <= usuario.Departamento.HoraFinal)
                        resultado = true;
                    else
                        resultado = false;
                }
            }
            return resultado;
        }

        public string EmailDoUsuario(Usuario usuario)
        {
            if (usuario.ContaEmail != null)
                return usuario.ContaEmail.Email;
            else
                return "";
        }

        internal bool PermissaoUsuario(object enumPrograma)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar(string nome)
        {
            return _rep.ListarUsuarios(nome).ToList();
        }

        public void AdicionarPermissao(UsuarioPermissao model)
        {
            _rep.AdicionarPermissao(model);
        }

        public void ExcluirPermissao(int id)
        {
            _rep.ExcluirPermissao(id);
        }

        public void PermissaoMensagem(int idUsuario, EnProgramas enumPrograma, EnTipoManutencao enumTipoManutencao)
        {
            if (!PermissaoUsuario(idUsuario, enumPrograma, enumTipoManutencao))
                throw new Exception("Usuário sem permissão!");
        }

        public bool PermissaoUsuario(int idUsuario, EnProgramas enumPrograma, EnTipoManutencao enumTipoManutencao)
        {
            int programa = (int)enumPrograma;
            string tipoManutencao = "";

            switch(enumTipoManutencao)
            {
                case EnTipoManutencao.Acessar:
                    tipoManutencao = "A";
                    break;

                case EnTipoManutencao.Incluir:
                    tipoManutencao = "N";
                    break;

                case EnTipoManutencao.Editar:
                    tipoManutencao = "E";
                    break;

                case EnTipoManutencao.Excluir:
                    tipoManutencao = "X";
                    break;
            }

            if (tipoManutencao == "N")
                return PermissaoIncluir(idUsuario, programa, tipoManutencao);
            else if (tipoManutencao == "A")
                return PermissaoAcesso(idUsuario, programa, tipoManutencao);
            else if (tipoManutencao == "E")
                return PermissaoEditar(idUsuario, programa, tipoManutencao);
            else if (tipoManutencao == "X")
                return PermissaoExcluir(idUsuario, programa, tipoManutencao);
            else
                return PermissaoRelatorio(idUsuario, programa, tipoManutencao);
        }

        private bool PermissaoAcesso(int idUsuario, int programa, string tipoManutencao)
        {
            var db = new DepartamentoPermissaoADO();
            return db.PermissaoUsuario(idUsuario, programa, tipoManutencao);
        }

        private bool PermissaoIncluir(int idUsuario, int programa, string tipoManutencao)
        {
            var db = new DepartamentoPermissaoADO();
            return db.PermissaoUsuario(idUsuario, programa, tipoManutencao);
        }

        private bool PermissaoEditar(int idUsuario, int programa, string tipoManutencao)
        {
            var db = new DepartamentoPermissaoADO();
            return db.PermissaoUsuario(idUsuario, programa, tipoManutencao);
        }

        private bool PermissaoExcluir(int idUsuario, int programa, string tipoManutencao)
        {
            var db = new DepartamentoPermissaoADO();
            return db.PermissaoUsuario(idUsuario, programa, tipoManutencao);
        }

        private bool PermissaoRelatorio(int idUsuario, int programa, string tipoManutencao)
        {
            var db = new DepartamentoPermissaoADO();
            return db.PermissaoUsuario(idUsuario, programa, tipoManutencao);
        }

        public void Salvar(Usuario model)
        {
            try
            {
                if (model.Codigo <= 0)
                    throw new Exception("É obrigatório o código");

                if (string.IsNullOrWhiteSpace(model.Nome))
                    throw new Exception("É obrigatório o nome");

                if (string.IsNullOrWhiteSpace(model.UserName))
                    throw new Exception("É obrigatório o usuário");

                if (string.IsNullOrWhiteSpace(model.Password))
                    throw new Exception("É obrigatório a senha");

                if (string.IsNullOrWhiteSpace(model.Email))
                    throw new Exception("É obrigatório o email");

                if (model.DepartamentoId <= 0)
                    throw new Exception("É obrigatório o departamento");

                if (model.Id == 0)
                    _rep.Salvar(model);
                else
                {
                    var usuario = _rep.ObterPorId(model.Id);
                    if (usuario == null)
                        usuario = new Usuario();

                    AlterarPermissao(usuario, model);
                    ExcluirPermissao(usuario, model);

                    usuario.Adm = model.Adm;
                    usuario.Ativo = model.Ativo;
                    usuario.ClienteId = model.ClienteId;
                    usuario.Codigo = model.Codigo;
                    usuario.ContaEmailId = model.ContaEmailId;
                    usuario.DepartamentoId = model.DepartamentoId;
                    usuario.Email = model.Email;
                    usuario.Nome = model.Nome;
                    usuario.Notificar = model.Notificar;
                    usuario.OnLine = model.OnLine;
                    usuario.Password = model.Password;
                    usuario.RevendaId = model.RevendaId;
                    usuario.UserName = model.UserName;

                    _rep.Salvar(usuario);
                }
                _rep.Commit();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void AlterarPermissao(Usuario usuario, Usuario model)
        {
            foreach (var item in model.UsuariosPermissao)
            {
                if (string.IsNullOrWhiteSpace(item.Sigla))
                    throw new Exception("Informe a sigla!");

                if (item.Id == 0)
                    usuario.UsuariosPermissao.Add(item);
                else
                {
                    var temp = usuario.UsuariosPermissao.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Sigla = item.Sigla;
                    }
                }
            }
        }

        private void ExcluirPermissao(Usuario usuario, Usuario model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in usuario.UsuariosPermissao)
            {
                var dados = model.UsuariosPermissao.FirstOrDefault(x => x.Id == itemBanco.Id);
                if (dados == null)
                {
                    if (itemBanco.Id > 0)
                    {
                        if (i == 1)
                            idDelecao += itemBanco.Id;
                        else
                            idDelecao += "," + itemBanco.Id;
                        i++;
                    }
                }
            }

            if (idDelecao != "")
                _rep.ExcluirItem(idDelecao);
        }

        private int ProximoCodigo()
        {
            try
            {
                return _rep.RetornarTodos().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
