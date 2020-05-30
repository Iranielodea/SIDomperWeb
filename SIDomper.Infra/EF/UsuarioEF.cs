using SIDomper.Dominio.Entidades;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class UsuarioEF
    {
        private readonly Repositorio<Usuario> _rep;

        public UsuarioEF()
        {
            _rep = new Repositorio<Usuario>();
        }

        public IEnumerable<UsuarioConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
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
            var lista = _rep.context.Database.SqlQuery<UsuarioConsulta>(sb.ToString());

            return lista;

        }

        public IEnumerable<UsuarioConsulta> Filtrar(UsuarioFiltro filtro)
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
                sb.AppendLine(" AND Usu_Revenda IN (" + filtro.IdRevenda+ ")");

            sb.AppendLine(" ORDER BY " + filtro.Campo);
            var lista = _rep.context.Database.SqlQuery<UsuarioConsulta>(sb.ToString());

            return lista;
        }

        public Usuario ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public Usuario ObterPorIdNull(int? id)
        {
            return _rep.find(id);
        }

        public Usuario ObterPorUsuario(string userName)
        {
            var model = new Usuario();
            model = _rep.First(x => x.UserName == userName);

            return model;
        }

        public List<UsuarioPermissaoDepartamento> ObterPermissao(string userName, string senha)
        {
            var query = from usu in _rep.context.Usuarios
                        join dep in _rep.context.Departamentos on usu.DepartamentoId equals dep.Id
                        join ace in _rep.context.DepartamentoAcessos on dep.Id equals ace.DepartamentoId
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

        public IQueryable<Usuario> ListarUsuarios(string nome)
        {
            return _rep.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public Usuario ObterPorCodigo(int codigo)
        {
            return _rep.First(x => x.Codigo == codigo);
        }

        public void Excluir(Usuario model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(Usuario model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
            {
                _rep.Add(model);
            }
        }

        public void AdicionarPermissao(UsuarioPermissao model)
        {
            _rep.context.UsuarioPermissoes.Add(model);
        }

        public void ExcluirPermissao(int id)
        {
            var model = _rep.context.UsuarioPermissoes.First(x => x.Id == id);
            if (model != null)
                _rep.context.UsuarioPermissoes.Remove(model);
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

        public IQueryable<Usuario> RetornarTodos()
        {
            return _rep.GetAll();
        }

        public void ExcluirItem(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Usuario_Permissao WHERE UsuP_Id in (" + ids + ")");
        }
    }
}
