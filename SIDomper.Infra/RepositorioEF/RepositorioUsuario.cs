using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces.Repositorios;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.RepositorioEF
{
    public class RepositorioUsuario : RepositorioBaseEF<Usuario>, IRepositorioUsuario
    {
        private readonly Contexto _contexto;

        public RepositorioUsuario(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void ExcluirItem(string ids)
        {
            _contexto.Database.ExecuteSqlCommand("DELETE FROM Usuario_Permissao WHERE UsuP_Id in (" + ids + ")");
        }

        public string Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Usu_Id as Id,");
            sb.AppendLine(" Usu_Codigo as Codigo,");
            sb.AppendLine(" Usu_Nome as Nome,");
            sb.AppendLine(" Usu_Codigo as ContaEmail,");
            sb.AppendLine(" Usu_Email as Email");
            sb.AppendLine(" FROM Usuario");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Usu_Id > 0");
            }

            if (ativo == "A")
                sb.AppendLine(" AND Usu_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Usu_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            return sb.ToString();

        }

        public string Filtrar(UsuarioFiltro filtro)
        {
            string sTexto = "";

            sTexto = "'" + filtro.Texto + "'";
            if (filtro.Contem)
                sTexto = "'%" + filtro.Texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Usu_Id as Id,");
            sb.AppendLine(" Usu_Codigo as Codigo,");
            sb.AppendLine(" Usu_Nome as Nome,");
            sb.AppendLine(" Usu_Codigo as ContaEmail,");
            sb.AppendLine(" Usu_Email as Email");
            sb.AppendLine(" FROM Usuario");
            sb.AppendLine(" INNER JOIN Departamento ON Usu_Departamento = Dep_Id");
            sb.AppendLine(" LEFT JOIN Revenda ON Usu_Revenda = Rev_Id");
            sb.AppendLine(" LEFT JOIN Cliente ON Usu_Cliente = Cli_Id");

            if (!string.IsNullOrWhiteSpace(filtro.Texto))
                sb.AppendLine(" WHERE " + filtro.Campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Usu_Id > 0");
            }

            if (filtro.Ativo == "A")
                sb.AppendLine(" AND Usu_Ativo = 1");

            if (filtro.Ativo == "I")
                sb.AppendLine(" AND Usu_Ativo = 0");

            if (filtro.Id > 0)
                sb.AppendLine(" AND Usu_Id = " + filtro.Id);

            if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
                sb.AppendLine(" AND Usu_Cliente IN (" + filtro.IdCliente + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdDepartamento))
                sb.AppendLine(" AND Usu_Departamento IN (" + filtro.IdDepartamento + ")");

            if (!string.IsNullOrWhiteSpace(filtro.IdRevenda))
                sb.AppendLine(" AND Usu_Revenda IN (" + filtro.IdRevenda + ")");

            sb.AppendLine(" ORDER BY " + filtro.Campo);
            return sb.ToString();
        }

        public string PermissaoUsuario(int idUsuario)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            return sb.ToString();
        }

        public bool PermissaoAcesso(int idUsuario, EnProgramas enProgramas)
        {
            var sql = PermissaoSqlBase(idUsuario, enProgramas);
            var model = _contexto.Database.SqlQuery< UsuarioPermissaoDepartamento>(sql).FirstOrDefault();
            if (model.UsuarioADM)
                return true;

            return (model.Acesso);
        }

        public IEnumerable<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha)
        {
            //var sb = new StringBuilder();
            //sb.AppendLine("SELECT");
            //sb.AppendLine(" Usu_Id AS Id,");
            //sb.AppendLine(" DepAc_Programa AS Programa,");
            //sb.AppendLine(" DepAc_Acesso AS Acesso,");
            //sb.AppendLine(" DepAc_Incluir AS Incluir,");
            //sb.AppendLine(" DepAc_Editar AS Editar,");
            //sb.AppendLine(" DepAc_Excluir AS Excluir,");
            //sb.AppendLine(" DepAc_Relatorio AS Relatorio,");
            //sb.AppendLine(" Usu_Adm AS Adm");
            //sb.AppendLine(" FROM Usuario");
            //sb.AppendLine(" INNER JOIN Departamento ON Usu_Departamento = Dep_Id");
            //sb.AppendLine(" INNER JOIN Departamento_Acesso ON Dep_Id = DepAc_Departamento");
            //sb.AppendLine(" WHERE Usu_UserName = '" + userName + "'");
            //sb.AppendLine(" AND Usu_Password = '" + senha + "'");
            //sb.AppendLine(" and Usu_Ativo = 1");
            //sb.AppendLine(" and Dep_Ativo = 1");

            //return _contexto.Database.SqlQuery<UsuarioPermissaoDepartamento>(sb.ToString()).ToList();

            var query = from usu in _contexto.Usuarios
                        join dep in _contexto.Departamentos on usu.DepartamentoId equals dep.Id
                        join ace in _contexto.DepartamentoAcessos on dep.Id equals ace.DepartamentoId
                        where usu.UserName == userName && usu.Password == senha && usu.Ativo == true && dep.Ativo == true
                        select new
                        {
                            usu.Id,
                            ace.Programa,
                            ace.Acesso,
                            ace.Incluir,
                            ace.Editar,
                            ace.Excluir,
                            ace.Relatorio,
                            usu.Adm
                        };

            var lista = new List<UsuarioPermissaoDepartamento>();
            foreach (var item in query)
            {
                var model = new UsuarioPermissaoDepartamento()
                {
                    Acesso = item.Acesso,
                    Editar = item.Editar,
                    Excluir = item.Excluir,
                    IdPrograma = item.Programa,
                    IdUsuario = item.Id,
                    Incluir = item.Incluir,
                    Relatorio = item.Relatorio,
                    UsuarioADM = item.Adm
                };
                lista.Add(model);

            }
            return lista;
        }

        private string PermissaoSqlBase(int idUsuario, EnProgramas enProgramas)
        {
            var programa = (int)enProgramas;

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine(" Usu_Id AS Id,");
            sb.AppendLine(" DepAc_Programa AS Programa,");
            sb.AppendLine(" DepAc_Acesso AS Acesso,");
            sb.AppendLine(" DepAc_Incluir AS Incluir,");
            sb.AppendLine(" DepAc_Editar AS Editar,");
            sb.AppendLine(" DepAc_Excluir AS Excluir,");
            sb.AppendLine(" DepAc_Relatorio AS Relatorio,");
            sb.AppendLine(" Usu_Adm AS Adm");
            sb.AppendLine(" FROM Usuario");
            sb.AppendLine(" INNER JOIN Departamento ON Usu_Departamento = Dep_Id");
            sb.AppendLine(" INNER JOIN Departamento_Acesso ON Dep_Id = DepAc_Departamento");
            sb.AppendLine(" WHERE Usu_Id = " + idUsuario);
            sb.AppendLine(" AND DepAc_Programa = " + programa);
            return sb.ToString();
        }

        public bool PermissaoIncluir(int idUsuario, EnProgramas enProgramas)
        {
            var programa = (int)enProgramas;

            var sql = PermissaoSqlBase(idUsuario, enProgramas);
            var model = _contexto.Database.SqlQuery<UsuarioPermissaoDepartamento>(sql).FirstOrDefault();
            if (model.UsuarioADM)
                return true;

            return (model.Incluir);
        }

        public bool PermissaoEditar(int idUsuario, EnProgramas enProgramas)
        {
            var sql = PermissaoSqlBase(idUsuario, enProgramas);
            var model = _contexto.Database.SqlQuery<UsuarioPermissaoDepartamento>(sql).FirstOrDefault();
            if (model.UsuarioADM)
                return true;

            return (model.Editar);
        }

        public bool PermissaoExcluir(int idUsuario, EnProgramas enProgramas)
        {
            var sql = PermissaoSqlBase(idUsuario, enProgramas);
            var model = _contexto.Database.SqlQuery<UsuarioPermissaoDepartamento>(sql).FirstOrDefault();
            if (model.UsuarioADM)
                return true;

            return (model.Excluir);
        }

        public bool PermissaoRelatorio(int idUsuario, EnProgramas enProgramas)
        {
            var sql = PermissaoSqlBase(idUsuario, enProgramas);
            var model = _contexto.Database.SqlQuery<UsuarioPermissaoDepartamento>(sql).FirstOrDefault();
            if (model.UsuarioADM)
                return true;

            return (model.Relatorio);
        }

        public void ExcluirPermissao(int id)
        {
            var model = _contexto.UsuarioPermissoes.First(x => x.Id == id);
            if (model != null)
                _contexto.UsuarioPermissoes.Remove(model);
        }

        public void AdicionarPermissao(UsuarioPermissao model)
        {
            _contexto.UsuarioPermissoes.Add(model);
        }

        public bool HorarioUsoSistema(string userName, string senha, int idUsuario = 0)
        {
            bool resultado = true;
            Usuario usuario = new Usuario();

            if (idUsuario > 0)
                usuario = _contexto.Usuarios.FirstOrDefault(x => x.Id == idUsuario);
            else
            {
                usuario =_contexto.Usuarios.FirstOrDefault(x => x.UserName == userName);

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

        public UsuarioPermissao ObterPermissaoPorSigla(int idUsuario, string sigla)
        {
            return _contexto.UsuarioPermissoes.FirstOrDefault(x => x.UsuarioId == idUsuario && x.Sigla == sigla);
        }

        public void PermitirIncluir(int idUsuario, EnProgramas enProgramas)
        {
            if (!PermissaoIncluir(idUsuario, enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void PermitirEditar(int idUsuario, EnProgramas enProgramas, ref string mensagem)
        {
            mensagem = "OK";
            if (!PermissaoEditar(idUsuario, enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;
        }

        public void PermitirExcluir(int idUsuario, EnProgramas enProgramas)
        {
            if (!PermissaoExcluir(idUsuario, enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void PermitirRelatorio(int idUsuario, EnProgramas enProgramas)
        {
            if (!PermissaoRelatorio(idUsuario, enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }
    }
}
