using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoModulo : IServicoModulo
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ModuloConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoModulo(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ModuloConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Modulo;
        }

        public Modulo Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Modulo model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioModulo.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ModuloConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Mod_Id as Id,");
            sb.AppendLine(" Mod_Codigo as Codigo,");
            sb.AppendLine(" Mod_Nome as Nome");
            sb.AppendLine(" FROM Modulo");

            if (idCliente > 0)
                sb.AppendLine("INNER JOIN Cliente_Modulo ON CliMod_Modulo = Mod_Id");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Mod_Id > 0");

            if (idCliente > 0)
                sb.AppendLine(" AND CliMod_Cliente = " + idCliente);

            if (ativo == "A")
                sb.AppendLine(" AND Mod_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Mod_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);

            var lista = _repositoryReadOnly.GetAll(sb.ToString());

            return lista;
        }

        public IQueryable<Modulo> ListarModulo(string nome)
        {
            return _uow.RepositorioModulo.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public Modulo Novo(int idUsuario)
        {
            var modulo = new Modulo();
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            modulo.Codigo = ProximoCodigo();
            modulo.Ativo = true;
            return modulo;
        }

        public Modulo ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioModulo.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Módulo não Cadastrado");
            if (model.Ativo == false)
                throw new Exception("Módulo Inativo!");
            return model;
        }

        public Modulo ObterPorId(int id)
        {
            return _uow.RepositorioModulo.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Modulo model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            _uow.RepositorioModulo.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioModulo.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
