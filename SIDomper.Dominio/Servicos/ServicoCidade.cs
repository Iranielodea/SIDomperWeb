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
    public class ServicoCidade : IServicoCidade
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<CidadeConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoCidade(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<CidadeConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Cidade;
        }

        public Cidade Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Cidade model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioCidade.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<CidadeConsulta> Filtrar(string campo, string texto, bool? ativo, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();
            sb.AppendLine("SELECT Cid_Id as Id, Cid_Codigo as Codigo, Cid_Nome as Nome, Cid_UF as UF FROM Cidade");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Cid_Id > 0");
            }

            if (ativo == true)
                sb.AppendLine(" AND Cid_Ativo = 1");
            if (ativo == false)
                sb.AppendLine(" AND Cid_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public IQueryable<Cidade> Listar(string nome)
        {
            return _uow.RepositorioCidade.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public Cidade Novo(int idUsuario)
        {
            var cidade = new Cidade();
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            cidade.Codigo = ProximoCodigo();
            cidade.Ativo = true;
            return cidade;
        }

        public Cidade ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioCidade.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Cidade não Cadastrada!");
            return model;
        }

        public Cidade ObterPorId(int id)
        {
            return _uow.RepositorioCidade.find(id);
        }

        public void Salvar(Cidade model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            _uow.RepositorioCidade.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioCidade.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
